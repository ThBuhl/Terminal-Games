using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class Mastermind {
    int[] answer = new int[] { 0, 0, 0, 0 };
    int threshold = 10;
    string rawGuess = "";
    int[] guess = new int[] { 0, 0, 0, 0 };
    int hits;
    int blows;
    bool gameWon = false;

    public static void Main() {
        Mastermind game = new Mastermind();
        game.run();
    }

    public void run() {
        Console.WriteLine("Here are the rules of Mastermind:");
        Console.WriteLine("Four distinct numbers between 1 and 9 will be randomly chosen. It will be your job to guess the correct numbers, in the correct order.");
        Console.WriteLine("For each guess, you get feedback. You are told how many of the numbers you guessed are 'hits' or 'blows'");
        Console.WriteLine("A 'hit' is a number that is in the right position.");
        Console.WriteLine("A 'blow' is a number that is in the answer, but is in the wrong position.");
        Console.WriteLine("The dificulty is determined by the number of guesses you get.");
        Console.WriteLine("Type 'dif' if you want to change the dificulty, otherwise just press enter:");
        string input = Console.ReadLine();
        if (input.Equals("dif")) {
            Console.WriteLine("How many guesses do you want?");
            while (!changeDificulty(Console.ReadLine())) {
                Console.WriteLine("That's not a valid number. Try again.");
            }
        }
        Console.WriteLine("Beginning the game!");
        beginGame();
        printEnding();
    }

    public void beginGame() {
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
            } while (!evaluateValidity(rawGuess));
            evaluateGuess(guess);
            printResults();
            if (hits == 4) {
                gameWon = true;
                break;
            }
        }
    }

    public bool evaluateValidity(string input) {
        if (input.Length == 4) {
            try {
                for (int i = 0; i < 4; i++) {
                    guess[i] = int.Parse(input[i].ToString());
                }
            } catch (Exception) {
                Console.WriteLine("\tInvalid guess! Please guess four numbers between 1 and 9");
                return false;
            }
        } else {
            Console.WriteLine("\tInvalid guess! Please guess four numbers between 1 and 9");
            return false;
        }
        return true;
    }

    public void evaluateGuess(int[] guess) {
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

    public void printResults() {
        Console.WriteLine("Hits: " + hits + "\tBlows: " + blows);
    }

    public void printEnding() {
        if (gameWon) {
            Console.WriteLine("You guessed it! You win!");
        } else {
            Console.WriteLine("No more guesses! You lose! The correct answer was " + string.Join("", answer));
        }
        Console.WriteLine("Game Over!");
    }

    public bool changeDificulty(string input) {
        try {
            threshold = int.Parse(input);
            return true;
        } catch (Exception) {
            return false;
        }
    }
}


