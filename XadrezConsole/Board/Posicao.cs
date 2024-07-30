using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Board
{
    internal class Posicao
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Posicao() 
        {
        }

        public Posicao(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }
    }
}
