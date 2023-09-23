using System;
using System.Globalization;

//Websites I used:
//https://stackoverflow.com/questions/1199571/how-to-hide-file-in-c
//https://stackoverflow.com/questions/18867180/check-if-list-is-empty-in-c-sharp
//https://stackoverflow.com/questions/5449956/how-to-add-a-delay-for-a-2-or-3-seconds
//https://stackoverflow.com/questions/6238232/how-to-clear-the-entire-console-window
//https://stackoverflow.com/questions/38960/how-to-find-out-if-a-file-exists-in-c-sharp-net

//Extras:
//I know that time constraintaaaas are one of the biggest problems people have with journals. Therefore,
//I added a quick entry option if someone didn't have enough time to interact with the menu. The only catch is
//that it only works if there was a previously used file. First time users wouldn't be able to use it so much. 
//I've also tried to find ways to solve problems where overwriting files and saving issues might be problems to
//make it more user friendly for those who- let's say- aren't exactly computer gurus. Or those who are forgetful,
//because that can be a serious problem as well.

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        int save = 0;
        Console.Clear();
        Console.WriteLine("Welcome to your personal journal!");
        Journal journal = new Journal("", new List<Entry>());

        if (File.Exists("last.file"))
        {
            string file = System.IO.File.ReadAllText("last.file");
            Console.Write($"Would you like to quick add a journal entry to {file}? (y/n)");
            string response1 = Console.ReadLine();
            if (response1 == "y" || response1 == "yes")
            {
                journal.QuickLoad(file);
                journal.NewEntry();
                journal.SaveJournal();
                done = true;
            }
        }

        if (!done)
        {
            Console.Write("Would you like to load a journal? ");
            string response = Console.ReadLine();
            if (response == "yes")
            {
                journal.LoadJournal();
            }
        }

        while (!done)
        {
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("\nWhat option would you like to do? ");
            Console.WriteLine("  1. Create a New Entry\n  2. View your journal\n  3. Save your journal\n  4. Load your journal\n  5. Quit");
            Console.Write("Please choose an option number: ");
            string choice = Console.ReadLine();
            int num = int.Parse(choice);
            if (num == 1)
            {
                journal.NewEntry();
                save = 1;
            }
            else if (num == 2)
            {
                journal.DisplayAll();
                Console.WriteLine("\nPress Enter to continue.");
                Console.ReadLine();
            }
            else if (num == 3)
            {
                journal.SaveJournal();
                save = 0;
            }
            else if (num == 4)
            {
                journal.LoadJournal();
            }
            else if (num == 5)
            {
                if (save == 1)
                {
                    Console.WriteLine("You have unsaved changes.\nWould you like to save before quitting? (yes/no)");
                    string response = Console.ReadLine();
                    if (response == "yes")
                    {
                        journal.SaveJournal();
                    }
                }
                done = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid option. ");
            }
        }
        Console.WriteLine("\nThank you for writing in your journal today!\nHave a nice day!");
        File.SetAttributes("last.file", FileAttributes.Hidden);
        using (StreamWriter lastFile = new StreamWriter("last.file"))
        {
            lastFile.Write(journal._fileName);
        }
        Thread.Sleep(2000);
    }
}