public class Job : Occupation
{
    public Job() : base("Mailroom")
    {

    }

    public override int GetBonus()
    {
        int bonus = 2;
        if (_levelTitle == "Warehouse")
        {
            bonus = 3;
        }
        else if (_levelTitle == "Administrator")
        {
            bonus = 4;
        }
        else if (_levelTitle == "Manager")
        {
            bonus = 5;
        }
        else if (_levelTitle == "Vice President")
        {
            bonus = 6;
        }
        else if (_levelTitle == "CEO")
        {
            bonus = 7;
        }
        return bonus;
    }

    public override void LevelUp()
    {
        if (_levelTitle == "Mailroom")
        {
            _levelTitle = "Warehouse";
        }
        else if (_levelTitle == "Warehouse")
        {
            _levelTitle = "Administrator";
        }
        else if (_levelTitle == "Administrator")
        {
            _levelTitle = "Manager";
        }
        else if (_levelTitle == "Manager")
        {
            _levelTitle = "Vice President";
        }
        else if (_levelTitle == "Vice President")
        {
            _levelTitle = "CEO";
        }
        Console.WriteLine($"Congratulations! You were promoted! You are now at level {_levelTitle}.");
        Thread.Sleep(2000);
    }

    public override void LevelDown()
    {
        if (_levelTitle == "Warehouse")
        {
            _levelTitle = "Mailroom";
        }
        else if (_levelTitle == "Administrator")
        {
            _levelTitle = "Warehouse";
        }
        else if (_levelTitle == "Manager")
        {
            _levelTitle = "Administrator";
        }
        else if (_levelTitle == "Vice President")
        {
            _levelTitle = "Manager";
        }
        else if (_levelTitle == "CEO")
        {
            _levelTitle = "Vice President";
        }
        Console.WriteLine($"Too bad! You were demoted! You are now at level {_levelTitle}.");
        Thread.Sleep(2000);
    }

    public override void FullDemote()
    {
        _levelTitle = "Mailroom";
        Console.WriteLine($"Ouch! You got fired! You are back at level {_levelTitle}.");
    }
}