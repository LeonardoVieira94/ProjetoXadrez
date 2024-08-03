using System;
using System.Collections.Generic;
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

        public ChessMatch()
        {
            Tab = new Tabuleiro(8, 8);
            Turn = 1;
            CurrentPlayer = Cor.White;
            EndGame = false;
            ColocarPecas();
        }

        public void MakeMovement(Posicao origin, Posicao target)
        {
            Peca p = Tab.RetirarPeca(origin);
            p.IncrementNumMovements();
            Peca pecaCapturada = Tab.RetirarPeca(target);
            Tab.ColocarPeca(p, target);
        }

        public void MakePlay(Posicao origin, Posicao target)
        {
            MakeMovement(origin, target);
            Turn++;
            ChangePlayer();
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


        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Tower(Cor.White, Tab), new ChessPosition('c', 1).ToPosition());
            Tab.ColocarPeca(new Tower(Cor.White, Tab), new ChessPosition('c', 2).ToPosition());
            Tab.ColocarPeca(new Tower(Cor.White, Tab), new ChessPosition('d', 2).ToPosition());
            Tab.ColocarPeca(new Tower(Cor.White, Tab), new ChessPosition('e', 1).ToPosition());
            Tab.ColocarPeca(new Tower(Cor.White, Tab), new ChessPosition('e', 2).ToPosition());
            Tab.ColocarPeca(new King(Cor.White, Tab), new ChessPosition('d', 1).ToPosition());

            Tab.ColocarPeca(new Tower(Cor.Black, Tab), new ChessPosition('c', 7).ToPosition());
            Tab.ColocarPeca(new Tower(Cor.Black, Tab), new ChessPosition('c', 8).ToPosition());
            Tab.ColocarPeca(new Tower(Cor.Black, Tab), new ChessPosition('d', 7).ToPosition());
            Tab.ColocarPeca(new Tower(Cor.Black, Tab), new ChessPosition('e', 7).ToPosition());
            Tab.ColocarPeca(new Tower(Cor.Black, Tab), new ChessPosition('e', 8).ToPosition());
            Tab.ColocarPeca(new King(Cor.Black, Tab), new ChessPosition('d', 8).ToPosition());

        }
    }
}
