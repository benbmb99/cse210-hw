using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void DisplayWelcome() => Console.WriteLine("Welcome to this program!");

    static string PromptUserName(){
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();
        name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
        return name;
    }

    static int PromptUserNumber(){
        Console.WriteLine("Please enter your favorite number: ");
        string number = Console.ReadLine();
        int num = int.Parse(number);
        return num;
    }

    static int SquareNumber(int a) => a * a;

    static void DisplayResult(string name, int a, int b){
        Console.WriteLine($"{name}, the square of your number ({a}) is {b}.");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep 5 World!");
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int num2 = SquareNumber(num);
        DisplayResult(name, num, num2);
    }
}