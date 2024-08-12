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
                    try
                    {
                        Console.Clear();
                        Screen.PrintChessMatch(match);
                        Console.WriteLine();
                        Console.Write("Source: ");
                        Posicao source = Screen.ReadPosition().ToPosition();                     
                        match.CheckSourcePosition(source);
                        Console.Clear();

                        bool[,] posicoesPossiveis = match.Tab.Peca(source).PossibleMovements();
                        Screen.PrintBoard(match.Tab, posicoesPossiveis);
                        Console.WriteLine();
                        Console.Write("Target: ");
                        Posicao target = Screen.ReadPosition().ToPosition();
                        match.CheckTargetPosition(source, target);
                        match.MakePlay(source, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Screen.PrintChessMatch(match);

            }

            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}