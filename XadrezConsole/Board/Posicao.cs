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
        public int Row { get; set; }
        public int Column { get; set; }

        public Posicao() 
        {
        }

        public Posicao(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return Row + ", " + Column;
        }
    }
}
