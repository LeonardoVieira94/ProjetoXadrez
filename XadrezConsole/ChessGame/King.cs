using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.ChessGame
{
    internal class King : Peca
    {
        public King(Cor color, Tabuleiro tab) : base(color, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
