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

            Turn++;
            ChangePlayer();
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


        public void PutNewPiece(char column, int row, Peca piece)
        {
            Tab.ColocarPeca(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }
        private void ColocarPecas()
        {
            PutNewPiece('c', 1, new Tower(Cor.White, Tab));
            PutNewPiece('c', 2, new Tower(Cor.White, Tab));
            PutNewPiece('d', 2, new Tower(Cor.White, Tab));
            PutNewPiece('e', 2, new Tower(Cor.White, Tab));
            PutNewPiece('e', 1, new Tower(Cor.White, Tab));
            PutNewPiece('d', 1, new King(Cor.White, Tab));

            PutNewPiece('c', 7, new Tower(Cor.Black, Tab));
            PutNewPiece('c', 8, new Tower(Cor.Black, Tab));
            PutNewPiece('d', 7, new Tower(Cor.Black, Tab));
            PutNewPiece('e', 7, new Tower(Cor.Black, Tab));
            PutNewPiece('e', 8, new Tower(Cor.Black, Tab));
            PutNewPiece('d', 8, new King(Cor.Black, Tab));


            

        }
    }
}
