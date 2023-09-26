public class Mastermind {
    int[] answer = new int[] { 0, 0, 0, 0 };
    int threshold = 10;
    string? rawGuess = "";
    bool validGuess;
    int[] guess = new int[] { 0, 0, 0, 0 };
    int hits;
    int blows;
    bool gameWon = false;

    public static void Main() {
        Mastermind game = new();
        game.Run();
    }

    public void Run() {
        Console.WriteLine("Here are the rules of Mastermind:");
        Console.WriteLine("Four distinct numbers between 1 and 9 will be randomly chosen. It will be your job to guess the correct numbers, in the correct order.");
        Console.WriteLine("For each guess, you get feedback. You are told how many of the numbers you guessed are 'hits' or 'blows'");
        Console.WriteLine("A 'hit' is a number that is in the right position.");
        Console.WriteLine("A 'blow' is a number that is in the answer, but is in the wrong position.");
        Console.WriteLine("The dificulty is determined by the number of guesses you get.");
        Console.WriteLine("Type 'dif' if you want to change the dificulty, otherwise just press enter:");
        string? input = Console.ReadLine();
        if (input != null) {
            if (input.Equals("dif")) {
                Console.WriteLine("How many guesses do you want?");
                while (!int.TryParse(input, out threshold)) {
                    Console.WriteLine("That's not a valid number. Try again.");
                }
            }
            Console.WriteLine("Beginning the game!");
            BeginGame();
            PrintEnding();
        }
    }

    public void BeginGame() {
        Random generator = new Random();
        for (int i = 0; i < 4; i++) {
            int newNumber = 0;
            do {
                newNumber = generator.Next(1, 10);
            } while (answer.Contains(newNumber));
            answer[i] = newNumber;
        }
        for (int i = 1; i <= threshold; i++) {
            Console.WriteLine("Round number " + i + ":");
            do {
                rawGuess = Console.ReadLine();
            } while (!EvaluateValidity(rawGuess));
            EvaluateGuess(guess);
            PrintResults();
            if (hits == 4) {
                gameWon = true;
                break;
            }
        }
    }

    public bool EvaluateValidity(string? input) {
        validGuess = true;
        if (input != null && input.Length == 4) {
            try {
                for (int i = 0; i < 4; i++) {
                    // Check if parsing worked for all four input chars
                    validGuess = validGuess && int.TryParse(new ReadOnlySpan<char>(input[i]), out guess[i]);
                }
                return validGuess;
            } catch (Exception) {
                Console.WriteLine("\tException occurred while ");
                return false;
            }
        } else {
            Console.WriteLine("\tInvalid guess! Please guess four numbers between 1 and 9");
            return false;
        }
    }

    public void EvaluateGuess(int[] guess) {
        hits = 0;
        blows = 0;
        for (int i = 0; i < 4; i++) {
            if (answer.Contains(guess[i])) {
                if (guess[i] == answer[i]) {
                    hits++; // Hit means 'Guessed number appears in the answer, in the guessed position
                } else {
                    blows++; // Blow means 'Guessed number appears in the answer, but not in the guessed position
                }
            }
        }
    }

    public void PrintResults() {
        Console.WriteLine("Hits: " + hits + "\tBlows: " + blows);
    }

    public void PrintEnding() {
        if (gameWon) {
            Console.WriteLine("You guessed it! You win!");
        } else {
            Console.WriteLine("No more guesses! You lose! The correct answer was " + string.Join("", answer));
        }
        Console.WriteLine("Game Over!");
    }
}


