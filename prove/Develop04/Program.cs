using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

//These are the websites I used:
//https://stackoverflow.com/questions/14057329/how-to-get-the-difference-in-time-in-seconds
//https://stackoverflow.com/questions/723211/quick-way-to-create-a-list-of-values-in-c

//Extras:
//I create a stats page that contains the stats of each of the activities: time completed as well as number of times the
//activity was done. I also made it so that, on the reflecting activity, no prompts are repeated during the duration of 
//the activity. I've also throw in a couple of error catch statements in case the user doesn't use a number in their entry.
//Also, just for fun, I made it so the user can see what they input into the program for the listing activity.

class Program
{
    static void Main(string[] args)
    {
        int bDur = 0;
        int rDur = 0;
        int lDur = 0;
        int bCount = 0;
        int rCount = 0;
        int lCount = 0;
        bool done = false;
        Console.Clear();
        Console.WriteLine("Welcome to the Mindfulness program.\n");
        do
        {
            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("  1. Breathing Exercise\n  2. Reflection Exercise\n  3. Listing Activity\n  4. Session Stats\n  5. Quit");
            Console.Write("Please select an option from above: ");
            int choice = -1;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                choice = 0;
            }
            if (choice == 1)
            {
                BreathingActivity a = new BreathingActivity();
                a.Run();
                bDur = bDur + a.GetDuration();
                bCount++;
            }
            else if (choice == 2)
            {
                ReflectingActivity a = new ReflectingActivity();
                a.Run();
                rDur = rDur + a.GetDuration();
                rCount++;
            }
            else if (choice == 3)
            {
                ListingActivity a = new ListingActivity();
                a.Run();
                lDur = lDur + a.GetDuration();
                lCount++;
            }
            else if (choice == 4)
            {
                Console.Clear();
                Console.WriteLine("Your session statistics are:");
                Console.WriteLine($"  1. Breathing Activity\n     --> {bCount} time(s); {bDur} seconds");
                Console.WriteLine($"  2. Reflecting Activity\n     --> {rCount} time(s); {rDur} seconds");
                Console.WriteLine($"  3. Listing Activity\n     --> {lCount} time(s); {lDur} seconds");
                if (bDur + rDur + lDur >= 150 || bCount + rCount + lCount >= 4)
                {
                    Console.WriteLine("\nWow! You've done a lot! Keep up the good work!");
                }
                else if (bDur + rDur + lDur > 0 || bCount + rCount + lCount > 0)
                {
                    Console.WriteLine("\nKeep up the good work!");
                }
                else
                {
                    Console.WriteLine("\nDo some exercises to get some stats!");
                }
                Console.WriteLine("\nPress enter to continue.");
                Console.ReadLine();
            }
            else if (choice == 5)
            {
                done = true;
            }
            else
            {
                Console.WriteLine("\nInvalid Entry. Please try again.");
                Thread.Sleep(2000);
            }
            Console.Clear();
        } while (!done);
        Console.WriteLine("Thanks for joining us for these mindfulness exercises today.");
    }
}