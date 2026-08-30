using TCSA.MathGame.Models;

namespace TCSA.MathGame;

internal class Menu
{
    GameEngine gameEngine = new();

    internal void ShowMenu(string? name, DateTime? date)
    {
        var random = new Random();
        Console.Clear();
        Console.WriteLine(
            $"Hello {name.ToUpper()}. It's {date}. This is your math's game. That's great thay you're working on imroving yoiurself\n");
        Console.WriteLine("Press any key to show menu");
        Console.ReadLine();
        Console.WriteLine("\n");

        bool isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine(@$"
What game would you like to play today? Choose from the options below:
V - View Previous Games
R - Random Game
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
            Console.WriteLine("----------------------------------------------");

            var gameSelected = Console.ReadLine();
            GameType? gameType = null;
            //bool isGameSelected = false;

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    break;
                case "r":
                    gameType = (GameType)random.Next(0, 4);
                    break;
                case "a":
                    gameType = GameType.Addition;
                    break;
                case "s":
                    gameType = GameType.Subtraction;
                    break;
                case "m":
                    gameType = GameType.Multiplication;
                    break;
                case "d":
                    gameType = GameType.Division;
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            if (gameType.HasValue)
            {
                var difficulty = GetDifficulty();
                gameEngine.PlayGame(gameType.Value, difficulty);
            }
        } while (isGameOn);
    }

    internal Difficulty GetDifficulty()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@$"
Choose the difficulty:
1 - Easy
2 - Medium
3 - Hard");
            Console.WriteLine("----------------------------------------------");
            var chooseDifficulty = Console.ReadLine();

            switch (chooseDifficulty)
            {
                case "1":
                    return Difficulty.Easy;
                case "2":
                    return Difficulty.Medium;
                case "3":
                    return Difficulty.Hard;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}