public class Program
{
    static int die1;
    static int die2;
    static int sum;
    static int sides;
    public static void Main()
    {
        //methods need two params
        //method for dice combination
        //method for totals
        Console.WriteLine("Welcome to my Super Casino!\nThis game is called Dice Roller!");
        while (true)
        {
            try
            {
                sides = int.Parse(GetUserInput("How many sides should the die have?"));
                if (sides < 1)
                {
                    Console.WriteLine("INVALID");
                    continue;
                }
            }
            catch
            {
                Console.WriteLine("INVALID");
                continue;
            }
            while (true)
            {
                DiceRoller();
                bool check = GoAgain();
                if (check == false)
                {
                    break;
                }
            }
            break;
        }
    }
    //METHODS
    static string GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        string output = Console.ReadLine();
        return output;
    }
    //combinations 
    static void SixSidedDie()
    {
        //Snake Eyes: Two 1s
        if (die1 == 1 && die2 == 1)
        {
            Console.WriteLine();
            string message = "==>Snake Eyes!";
            Console.WriteLine(message);
        }
        //Ace Deuce: A 1 and 2
        else if (die1 == 1 && die2 == 2)
        {
            Console.WriteLine();
            string message = "==>Ace Deuce!";
            Console.WriteLine(message);
        }
        //Box Cars: Two 6s
        else if (die1 == 6 && die2 == 6 || sum == 12)
        {
            Console.WriteLine();
            string message = "==>Box Cars!";
            Console.WriteLine(message);
        }
        //Win: A total of 7 or 11
        else if (sum == 7 || sum == 11)
        {
            Console.WriteLine();
            string message = "==>A Win!";
            Console.WriteLine(message);
            //Craps: A total of 2, 3, or 12 (will also generate another message!)
        }
        else if (sum == 2 || sum == 3 )
        {
            Console.WriteLine();
            string message = "==>Craps!";
            Console.WriteLine(message);
        }
    }
    //generate random numbers
    static void DiceRoller()
    {
        Random dice = new Random();
        die1 = dice.Next(1, sides + 1);
        die2 = dice.Next(1, sides + 1);
        sum = die1 + die2;
        if (sides <= 6 || sides >=1 )
        {
            SixSidedDie();
        }
        Console.WriteLine($"You rolled {die1} and {die2} => total {sum}");
    }
    static bool GoAgain()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to go again (y/n)?");
            string input = Console.ReadLine();
            try
            {
                if (input.ToLower().Trim() == "y")
                {
                    Console.WriteLine("Okay!");
                    Console.WriteLine();
                    return true;
                }
                else if (input.ToLower().Trim() == "n")
                {
                    Console.WriteLine("Okay bye!");
                    return false;
                }
                else
                {
                    throw new Exception("Not a valid option, please try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
