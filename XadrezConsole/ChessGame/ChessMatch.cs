using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;
using XadrezConsole.Board.Exceptions;


namespace XadrezConsole.ChessGame
{
    internal class ChessMatch
    {
        public Tabuleiro Tab { get; private set; }
        public int Turn { get; private set; }
        public Cor CurrentPlayer { get; private set; }
        public bool EndGame { get; private set; }
        private HashSet<Peca> Pieces;
        private HashSet<Peca> Captured;
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Tab = new Tabuleiro(8, 8);
            Turn = 1;
            CurrentPlayer = Cor.White;
            EndGame = false;
            Pieces = new HashSet<Peca>();
            Captured = new HashSet<Peca>();
            ColocarPecas();
            Check = false;  
        }

        public Peca MakeMovement(Posicao origin, Posicao target)
        {
            Peca p = Tab.RetirarPeca(origin);
            p.IncreaseNumMovements();
            Peca pecaCapturada = Tab.RetirarPeca(target);
            Tab.ColocarPeca(p, target);
            if (pecaCapturada != null)
            {
                Captured.Add(pecaCapturada);
            }
            //#Castling(small)
            if (p is King && target.Column == origin.Column + 2)
            {
                Posicao originR = new Posicao(origin.Row, origin.Column + 3);
                Posicao targetR = new Posicao(origin.Row, origin.Column + 1);
                Peca R = Tab.RetirarPeca(originR);
                R.IncreaseNumMovements();
                Tab.ColocarPeca(R, targetR);

            }
            //#Castling(bigger)
            if (p is King && target.Column == origin.Column - 2)
            {
                Posicao originR = new Posicao(origin.Row, origin.Column - 4);
                Posicao targetR = new Posicao(origin.Row, origin.Column - 1);
                Peca R = Tab.RetirarPeca(originR);
                R.IncreaseNumMovements();
                Tab.ColocarPeca(R, targetR);

            }
            return pecaCapturada;
        }

        public void MakePlay(Posicao origin, Posicao target)
        {
            Peca capturedPiece = MakeMovement(origin, target);
            if (InCheck(CurrentPlayer))
            {
                UnmakePlay(origin, target, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (InCheck(Rival(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (CheckMateTest(Rival(CurrentPlayer)))
            {
                EndGame = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
        }

        public void UnmakePlay(Posicao origin, Posicao target, Peca capturedPiece)
        {
            Peca p = Tab.RetirarPeca(target);
            p.DecreaseNumMovements();
            if (capturedPiece != null)
            {
                Tab.ColocarPeca(capturedPiece, target);
                Captured.Remove(capturedPiece);
            }
            Tab.ColocarPeca(p, origin);

            //#Castling(small)
            if (p is King && target.Column == origin.Column + 2)
            {
                Posicao originR = new Posicao(origin.Row, origin.Column + 3);
                Posicao targetR = new Posicao(target.Row, target.Column + 1);
                Peca R = Tab.RetirarPeca(targetR);
                R.DecreaseNumMovements();
                Tab.ColocarPeca(R, originR);

            }

            //#Castling(bigger)
            if (p is King && target.Column == origin.Column - 2)
            {
                Posicao originR = new Posicao(origin.Row, origin.Column - 4);
                Posicao targetR = new Posicao(target.Row, target.Column - 1);
                Peca R = Tab.RetirarPeca(targetR);
                R.DecreaseNumMovements();
                Tab.ColocarPeca(R, originR);

            }
        }

        public void CheckOriginPosition(Posicao pos) 
        {
            if (Tab.Peca(pos) == null)
            {
                throw new BoardException("There is no piece on this position!");
            }
            if (CurrentPlayer != Tab.Peca(pos).Color)
            {
                throw new BoardException("You need to choose your piece color!");
            }
            if (!Tab.Peca(pos).IfPossibleMovements())
            {
                throw new BoardException("There's no possible movement!");

            }
        }
        public void CheckTargetPosition(Posicao origin, Posicao target)
        {
            if (!Tab.Peca(origin).CanMoveTo(target))
            {
                throw new BoardException("Invalid target position! ");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Cor.White)
            {
                CurrentPlayer = Cor.Black;
            }
            else
            {
                CurrentPlayer = Cor.White;
            }
        }

        public HashSet<Peca> CapturedPiece (Cor color)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> GamePieces(Cor color)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPiece(color));
            return aux;
        }

        private Cor Rival(Cor color)
        {
            if (color == Cor.White) 
            {
                return Cor.Black;
            }
            else
            {
                return Cor.White;
            }
        }

        private Peca King(Cor color)
        {
            foreach (Peca x in GamePieces(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool InCheck(Cor color)
        {
            Peca K = King(color);
            if (K == null)
            {
                throw new BoardException("There's no king on the board");
            }
            foreach (Peca x in GamePieces(Rival(color))) 
            {
                bool[,] mat = x.PossibleMovements();
                if (mat[K.Posicao.Row, K.Posicao.Column])
                {
                    return true;
                }               
            }
            return false;
        }

        public bool CheckMateTest(Cor color)
        {
            if (!InCheck(color))
            {
                return false;
            }
            foreach (Peca x in GamePieces(color))
            {
                bool[,] mat = x.PossibleMovements();
                for (int i = 0; i < Tab.Rows; i++)
                {
                    for (int j = 0; j < Tab.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origin = x.Posicao;
                            Posicao target = new Posicao(i, j);
                            Peca capturedPiece = MakeMovement(origin, target );
                            bool testCheck = InCheck(color);
                            UnmakePlay(origin, target, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }

                        }
                    }
                }

            }
            return true;

        }


        public void PutNewPiece(char column, int row, Peca piece)
        {
            Tab.ColocarPeca(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }
        private void ColocarPecas()
        {
            PutNewPiece('a', 1, new Rook(Cor.White, Tab));
            PutNewPiece('b', 1, new Horse(Cor.White, Tab));
            PutNewPiece('c', 1, new Bishop(Cor.White, Tab));
            PutNewPiece('d', 1, new Queen(Cor.White, Tab));
            PutNewPiece('e', 1, new King(Cor.White, Tab, this));
            PutNewPiece('f', 1, new Bishop(Cor.White, Tab));
            PutNewPiece('g', 1, new Horse(Cor.White, Tab));
            PutNewPiece('h', 1, new Rook(Cor.White, Tab));
            PutNewPiece('a', 2, new Pawn(Cor.White, Tab, this));
            PutNewPiece('b', 2, new Pawn(Cor.White, Tab, this));
            PutNewPiece('c', 2, new Pawn(Cor.White, Tab, this));
            PutNewPiece('d', 2, new Pawn(Cor.White, Tab, this));
            PutNewPiece('e', 2, new Pawn(Cor.White, Tab, this));
            PutNewPiece('f', 2, new Pawn(Cor.White, Tab, this));
            PutNewPiece('g', 2, new Pawn(Cor.White, Tab, this));
            PutNewPiece('h', 2, new Pawn(Cor.White, Tab, this));

            PutNewPiece('a', 8, new Rook(Cor.Black, Tab));
            PutNewPiece('b', 8, new Horse(Cor.Black, Tab));
            PutNewPiece('c', 8, new Bishop(Cor.Black, Tab));
            PutNewPiece('d', 8, new Queen(Cor.Black, Tab));
            PutNewPiece('e', 8, new King(Cor.Black, Tab, this));
            PutNewPiece('f', 8, new Bishop(Cor.Black, Tab));
            PutNewPiece('g', 8, new Horse(Cor.Black, Tab));
            PutNewPiece('h', 8, new Rook(Cor.Black, Tab));
            PutNewPiece('a', 7, new Pawn(Cor.Black, Tab, this));
            PutNewPiece('b', 7, new Pawn(Cor.Black, Tab, this));
            PutNewPiece('c', 7, new Pawn(Cor.Black, Tab, this));
            PutNewPiece('d', 7, new Pawn(Cor.Black, Tab, this));
            PutNewPiece('e', 7, new Pawn(Cor.Black, Tab, this));
            PutNewPiece('f', 7, new Pawn(Cor.Black, Tab, this));
            PutNewPiece('g', 7, new Pawn(Cor.Black, Tab, this));
            PutNewPiece('h', 7, new Pawn(Cor.Black, Tab, this));




        }
    }
}
