using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep 3 World!");
        Random random = new Random();
        string again = "yes";
        do{
            int magicNum = random.Next(1,100);
            Console.WriteLine("The number I'm thinking of is between 1 and 100.\nWhat is my number? ");
            string guess = "";
            Boolean c = true;
            int guessNum = 1;
            do{
                guess = Console.ReadLine();
                int num = int.Parse(guess);
                if(num>magicNum){
                    Console.WriteLine("Guess lower.");
                }else if(num<magicNum){
                    Console.WriteLine("Guess higher.");
                }else{
                    c=false;
                }
                guessNum++;
                Console.WriteLine("What is your next guess? ");
            }while(c);
            Console.WriteLine("Congratulations! You guessed it!");
            Console.WriteLine($"It took you {guessNum} guesses to guess my number!");
            Console.WriteLine("\nDo you want to play again (yes/no)? ");
            again = Console.ReadLine().ToLower();
        }while (again == "yes");
        Console.WriteLine("Thanks for playing!");
    }
}