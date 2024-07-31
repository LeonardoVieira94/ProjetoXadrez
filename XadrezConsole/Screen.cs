using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole
{
    internal class Screen
    {
        public static void PrintBoard(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Columns; j++)
                {

                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                    
                }

                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPeca(Peca peca)
        {
            if (peca.Color == Cor.Black)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else 
            {
                Console.Write(peca);
            }
            
        }
    }
}
