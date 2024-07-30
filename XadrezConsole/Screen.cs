using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;

namespace XadrezConsole
{
    internal class Screen
    {
        public static void PrintBoard(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Lines; i++)
            {
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{tab.Peca(i, j)} ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
