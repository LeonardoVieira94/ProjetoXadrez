using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;


namespace XadrezConsole.ChessGame
{
    internal class ChessMatch
    {
        public Tabuleiro Tab { get; private set; }
        private int Turn;
        private Cor CurrentPlayer;
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
