public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private DateTime _startTime;

    public Activity(string name, string description, int duration)
    {
        this._name = name;
        this._description = description;
        this._duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"\n{_description}");
        Console.Write("\nHow long, in seconds, would you like to do this activity? ");
        int duration = 0;
        bool done = false;
        do
        {
            try
            {
                duration = int.Parse(Console.ReadLine());
                done = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nInvalid Entry. Please try again.");
                Console.WriteLine("How long, in seconds, would you like to do this activity? ");
            }
        } while (!done);
        _duration = duration;
        Console.Clear();
        Console.WriteLine("Clear your mind...");
        ShowSpinner(3);
        SetTimer();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\n\nGood job!");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int sec)
    {
        do
        {
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            sec--;
        } while (sec > 0);
    }

    public void ShowCountdown(int sec)
    {
        do
        {
            Console.Write(sec);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            sec--;
        } while (sec > 0);
    }

    public void SetTimer()
    {
        _startTime = DateTime.Now;
    }

    public bool CheckTimer()
    {
        int sec = (int)(DateTime.Now - _startTime).TotalSeconds;
        if (sec < _duration)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}