using System.Diagnostics;
using TCSA.MathGame.Models;

namespace TCSA.MathGame;

internal class GameEngine
{
    internal void PlayGame(GameType gameType, Difficulty difficulty)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            int correctAnswer = 0;
            char operation = ' ';
            (int firstNumber, int secondNumber) = Helpers.GetNumbers(gameType, difficulty);

            switch (gameType)
            {
                case GameType.Addition:
                    operation = '+';
                    correctAnswer = firstNumber + secondNumber;
                    break;
                case GameType.Subtraction:
                    operation = '-';
                    correctAnswer = firstNumber - secondNumber;
                    break;
                case GameType.Multiplication:
                    operation = '*';
                    correctAnswer = firstNumber * secondNumber;
                    break;
                case GameType.Division:
                    operation = '/';
                    correctAnswer = firstNumber / secondNumber;
                    break;
            }

            Console.WriteLine($"{firstNumber} {operation} {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);
            if (int.Parse(result) == correctAnswer)
            {
                Console.WriteLine($"Your answer was correct. Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Your answer was incorrect. Type any key for the next question.");
                Console.ReadLine();
            }
        }

        stopwatch.Stop();
        TimeSpan duration = stopwatch.Elapsed;
        Console.WriteLine(
            $"Game over. Your final score is {score}. Time: {duration.TotalSeconds:F2}. Press any key to go back to the main menu.");
        Console.ReadLine();
        Helpers.AddToHistory(score, gameType, duration, difficulty);
    }
}