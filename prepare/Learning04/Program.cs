using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment mine = new Assignment("Josh Kyleson", "Derivatives");
        Console.WriteLine(mine.GetSummary());
        MathAssignment yours = new MathAssignment("Kyle Josheson", "Fractals", "4.5", "1-18");
        Console.WriteLine(yours.GetSummary());
        Console.WriteLine(yours.GetHomeworkList());
        WritingAssignment ours = new WritingAssignment("Kyle's Son, Josh", "Environment", "How I can stop the environment from being evil?");
        Console.WriteLine(ours.GetSummary());
        Console.WriteLine(ours.GetWritingInformation());
    }
}