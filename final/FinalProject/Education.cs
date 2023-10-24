public class Education : Occupation
{

    private string _status = "Not Attending";
    private Random _rand = new();

    public Education() : base("None")
    {

    }

    public void CheckConferance()
    {
        if (_status == "Attending")
        {
            int x = _rand.Next(0, GetBonus() + 1);
            if (x <= 1)
            {
                LevelUp();
            }
        }
    }

    public override int GetBonus()
    {
        int bonus = 1;
        if (_levelTitle == "Associates")
        {
            bonus = 2;
        }
        else if (_levelTitle == "Bachelors")
        {
            bonus = 3;
        }
        else if (_levelTitle == "Masters")
        {
            bonus = 4;
        }
        else if (_levelTitle == "Doctorate")
        {
            bonus = 5;
        }
        return bonus;
    }

    public override void LevelUp()
    {
        if (_levelTitle == "None")
        {
            _levelTitle = "Associates";
        }
        else if (_levelTitle == "Associates")
        {
            _levelTitle = "Bachelors";
        }
        else if (_levelTitle == "Bachelors")
        {
            _levelTitle = "Masters";
        }
        else if (_levelTitle == "Masters")
        {
            _levelTitle = "Doctorate";
        }
        _status = "Not Attending";
        Console.WriteLine($"Congratulations! You graduated! You are now at level {_levelTitle}.");
        Thread.Sleep(2000);
    }

    public override void LevelDown()
    {
        if (_levelTitle == "Associates")
        {
            _levelTitle = "None";
        }
        else if (_levelTitle == "Bachelors")
        {
            _levelTitle = "Associates";
        }
        else if (_levelTitle == "Masters")
        {
            _levelTitle = "Bachelors";
        }
        else if (_levelTitle == "Doctorate")
        {
            _levelTitle = "Masters";
        }
        Console.WriteLine($"Too bad! You lost your degree! You are now at level {_levelTitle}.");
        Thread.Sleep(2000);
    }

    public string GetStatus()
    {
        return _status;
    }

    public void SetStatus()
    {
        if (_levelTitle != "Doctorate")
        {
            _status = "Attending";
            Console.WriteLine("You started attending school!");
        }
        else
        {
            Console.WriteLine("You already have a doctorate!");
        }
        Thread.Sleep(2000);
    }
}