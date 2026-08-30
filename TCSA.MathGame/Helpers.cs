using TCSA.MathGame.Models;

namespace TCSA.MathGame;

internal class Helpers
{
    internal static List<Game> games = new List<Game>()
    {
        /*new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
        new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
        new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
        new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
        new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
        new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
        new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
        new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
        new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },*/
    };

    internal static void PrintGames()
    {
        //var gamesToPrint = games.Where(x => x.Date > new DateTime(2022, 08, 09)).OrderByDescending(x => x.Score);

        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("---------------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty}: {game.Score}pts - {game.Duration.TotalSeconds:F2}");
        }

        Console.WriteLine("---------------------------\n");
        Console.WriteLine("Press any key to return  to main menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType, TimeSpan duration, Difficulty difficulty)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            Difficulty = difficulty,
            Duration = duration,
        });
    }

    internal static string ValidateResult(string? result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            result = Console.ReadLine();
        }

        return result;
    }

    internal static string? GetName()
    {
        Console.WriteLine("Please type your name");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }

        return name;
    }

    internal static (int min, int max) GetRange(GameType gameType, Difficulty difficulty)
    {
        switch (gameType)
        {
            case GameType.Addition:
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        return (1, 11);
                    case Difficulty.Medium:
                        return (1, 51);
                    case Difficulty.Hard:
                        return (1, 101);
                }

                break;
            case GameType.Subtraction:
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        return (1, 11);
                    case Difficulty.Medium:
                        return (1, 51);
                    case Difficulty.Hard:
                        return (1, 101);
                }

                break;
            case GameType.Multiplication:
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        return (1, 6);
                    case Difficulty.Medium:
                        return (1, 11);
                    case Difficulty.Hard:
                        return (1, 21);
                }

                break;
            case GameType.Division:
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        return (1, 11);
                    case Difficulty.Medium:
                        return (1, 31);
                    case Difficulty.Hard:
                        return (1, 51);
                }

                break;
        }

        throw new InvalidOperationException();
    }

    internal static (int firstNumber, int secondNumber) GetNumbers(GameType gameType, Difficulty difficulty)
    {
        (int min, int max) = GetRange(gameType, difficulty);
        var random = new Random();
        int firstNumber = random.Next(min, max);
        int secondNumber = random.Next(min, max);

        if (gameType == GameType.Division)
        {
            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(min, max);
                secondNumber = random.Next(min, max);
            }
        }

        return (firstNumber, secondNumber);
    }
}