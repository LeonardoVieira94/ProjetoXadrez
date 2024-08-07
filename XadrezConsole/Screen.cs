using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;
using XadrezConsole.ChessGame;

namespace XadrezConsole
{
    internal class Screen
    {

        public static void PrintChessMatch(ChessMatch match)
        {
            Screen.PrintBoard(match.Tab);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            Console.WriteLine("Waiting play: " + match.CurrentPlayer);
            if (match.Check)
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintHash(match.CapturedPiece(Cor.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintHash(match.CapturedPiece(Cor.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintHash(HashSet<Peca> hash)
        {
            Console.Write("[");
            foreach (Peca x in hash) 
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    PrintPeca(tab.Peca(i, j));
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                         Console.BackgroundColor = originalBackground; 
                    }
                    PrintPeca(tab.Peca(i, j));
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("-");
            }
            else
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

        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);
        }
    }
}
