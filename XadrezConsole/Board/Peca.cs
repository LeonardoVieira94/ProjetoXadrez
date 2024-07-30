using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Board
{
    internal class Peca
    {
        public Posicao Posicao { get; set; }

        public Cor Color { get; protected set; }

        public int NumMovements { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Cor color, Tabuleiro tab)
        {
            Posicao = null;
            Color = color;
            Tab = tab;
            NumMovements = 0;
        }
    }
}
