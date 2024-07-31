using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;

namespace XadrezConsole.ChessGame
{
    internal class ChessPosition
    {       
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessPosition()
        {
        }

        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Posicao ToPosition ()
        {
            return new Posicao(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}
