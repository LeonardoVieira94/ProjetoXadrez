using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace XadrezConsole.Board.Exceptions
{
    internal class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
        }
        
    }
}
