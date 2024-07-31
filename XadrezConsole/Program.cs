using XadrezConsole.Board;
using XadrezConsole.Board.Enums;
using XadrezConsole.Board.Exceptions;
using XadrezConsole.ChessGame;


namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.EndGame)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Tab);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Posicao origin = Screen.ReadPosition().ToPosition();
                    Console.Write("Target: ");
                    Posicao target = Screen.ReadPosition().ToPosition();

                    match.MakeMovement(origin, target);
                }

                
                
            }

            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}