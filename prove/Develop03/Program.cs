using System;
using System.Runtime.InteropServices;

//Websites I used: 
//https://stackoverflow.com/questions/4398270/how-to-split-string-preserving-whole-words
//https://stackoverflow.com/questions/73297984/split-word-into-letters-c-sharp
//https://stackoverflow.com/questions/559415/concat-all-strings-inside-a-liststring-using-linq
//https://stackoverflow.com/questions/19724933/check-string-of-chars
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements

//Extras:
//I made it so that the user can input their own scripture if they want, but if they want a random scripture,
//there is a random that selects a random scripture from the text file "DefaultScriptures.txt". I also know that
//some people memorize better with having the first letter of the word still showing, so I created an option that
//allows for either the first letter to show or no letter to show.

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        Console.Clear();
        Console.WriteLine("Welcome to the scripture memorizer!");
        Console.WriteLine("Which option would you like to use for this session?\n  1. First letters showing\n  2. No Letters showing ");
        Console.Write("I would like option: (1/2) ");
        int option;
        try
        {
            option = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            option = 1;
            Console.WriteLine("Default settings of option 1 applied.");
        }
        bool status = true;
        if (option == 1)
        {
            status = true;
        }
        else if (option == 2)
        {
            status = false;
        }
        else
        {
            Console.WriteLine("Default settings of option 1 applied.");
        }
        Console.Write("Would you like to load a random default scripture? (yes/no) ");
        string response = Console.ReadLine().ToLower().Trim();
        Scripture scripture;
        if (response == "yes")
        {
            List<Scripture> scriptures = LoadFile(status);
            int a = random.Next(0, scriptures.Count());
            scripture = scriptures[a];
        }
        else
        {
            Console.WriteLine("To input your own scripture, we will ask a few questions.");
            Console.Write("What is the book the scripture is in? ");
            string book = Console.ReadLine();
            Console.Write("What is the chapter the scripture is in? ");
            int chapter = int.Parse(Console.ReadLine());
            Console.Write("What is the verse the scripture is in? (if it is in multiple verses, what is the first verse?) ");
            int verse = int.Parse(Console.ReadLine());
            Console.Write("Is there more than one verse? ");
            string response1 = Console.ReadLine().ToLower().Trim();
            Reference reference;
            if (response1 == "yes")
            {
                Console.Write("What is the ending verse of the reference? ");
                int endVerse = int.Parse(Console.ReadLine());
                reference = new Reference(book, chapter, verse, endVerse);
            }
            else
            {
                reference = new Reference(book, chapter, verse);
            }
            Console.WriteLine("Please enter the text of the scripture below: (for multiple verses, press 'Shift + Enter' to create paragraphs) ");
            string text = Console.ReadLine();
            scripture = new Scripture(reference, text, status);
        }

        Console.WriteLine(scripture.GetDisplayText());
        int x = random.Next(4, 6);
        scripture.HideWords(x);

        while (!scripture.IsCompletelyHidden())
        {
            string response1 = Console.ReadLine();
            if (response1.ToLower().Trim() == "quit")
            {
                break;
            }
            Console.WriteLine(scripture.GetDisplayText());
            x = random.Next(4, 6);
            scripture.HideWords(x);
        }
        Console.WriteLine(scripture.GetDisplayText());
        Console.ReadLine();
    }

    public static List<Scripture> LoadFile(bool status)
    {
        List<Scripture> scriptures = new List<Scripture>();
        string[] lines = System.IO.File.ReadAllLines("DefaultScriptures.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split("%%");

            string text = parts[0];
            string book = parts[1];
            int chapter = int.Parse(parts[2]);
            int verse = int.Parse(parts[3]);
            Reference reference;
            if (parts.Length == 5)
            {
                int endVerse = int.Parse(parts[4]);
                reference = new Reference(book, chapter, verse, endVerse);
            }
            else
            {
                reference = new Reference(book, chapter, verse);
            }
            Scripture scripture = new Scripture(reference, text, status);
            scriptures.Add(scripture);
        }
        return scriptures;
    }
}