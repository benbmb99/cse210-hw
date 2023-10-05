using System.Security.Cryptography.X509Certificates;

public class ListingActivity : Activity
{
    private int _count;
    private readonly List<string> _prompts = new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 30)
    {

    }

    public void Run()
    {
        DisplayStartingMessage();
        _count = 0;
        Console.WriteLine("\nList as many responses you can to the following prompt:\n");
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        SetTimer();
        DisplayList(GetListFromUser());
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random r = new Random();
        int j = r.Next(0, _prompts.Count());
        Console.WriteLine($" --- {_prompts[j]} ---\n");
    }

    public List<string> GetListFromUser()
    {
        List<string> _myResponses = new List<string>();
        while (CheckTimer())
        {
            string response = Console.ReadLine();
            _count++;
            _myResponses.Add(response);
        }
        return _myResponses;
    }

    public void DisplayList(List<string> a)
    {
        Console.Clear();
        int x = 1;
        Console.WriteLine("You wrote the following: ");
        foreach (string w in a)
        {
            Console.WriteLine($"  {x}. {w}");
            x++;
        }
        Thread.Sleep(x * 500);
    }
}