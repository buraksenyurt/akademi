int myGuess = new Random().Next(1, 101);
int userGuess = 0;
int guessCount = 0;
const int totalTries = 5;

Console.WriteLine("I have a number in my mind. (between 1 and 100). Guess what? You have 5 attempts:");

while (userGuess != myGuess)
{
    if (guessCount >= totalTries)
    {
        Console.WriteLine($"You've used all your attempts. My number was {myGuess}.");
        break;
    }

    guessCount++;
    Console.Write($"{guessCount} attemt :");
    var userInput = Console.ReadLine();

    if (!int.TryParse(userInput, out userGuess))
    {
        Console.WriteLine("Please enter a valid number.");
        continue;
    }

    if (userGuess < myGuess)
    {
        Console.WriteLine("Too low. Please try again.");
    }
    else if (userGuess > myGuess)
    {
        Console.WriteLine("Too high. Please try again.");
    }
    else
    {
        Console.WriteLine($"Woavvv! You guessed the number in {guessCount} attempts.");
        break;
    }
}
