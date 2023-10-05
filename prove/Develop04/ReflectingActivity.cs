using System.Globalization;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
    private List<string> _questions = new List<string> { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };
    private List<int> _alreadyUsed = new List<int>();

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have, and how you can use it in other aspects of your life.", 30)
    {

    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        do
        {
            DisplayQuestions();
        } while (CheckTimer());
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random r = new Random();
        int j = r.Next(0, _prompts.Count());
        return _prompts[j];
    }

    public string GetRandomQuestion()
    {
        Random r = new Random();
        int j = -1;
        do
        {
            j = r.Next(0, _questions.Count());
        } while (_alreadyUsed.Contains(j) && CheckTimer());
        _alreadyUsed.Add(j);
        return _questions[j];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($" --- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
    }

    public void DisplayQuestions()
    {
        Console.Write($"\n > {GetRandomQuestion()}");
        ShowSpinner(5);
    }
}