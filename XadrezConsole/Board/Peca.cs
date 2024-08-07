using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.Board
{
    abstract class Peca
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

        public void IncreaseNumMovements()
        {
            NumMovements++;
        }

        public void DecreaseNumMovements()
        {
            NumMovements--;
        }

        public bool IfPossibleMovements()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < Tab.Rows; i++)
            {
                for (int j = 0; j < Tab.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanMoveTo(Posicao pos) 
        {
            return PossibleMovements()[pos.Row, pos.Column];
        }

        public abstract bool[,] PossibleMovements();
        
    }
}
