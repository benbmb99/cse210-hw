public class DailyGoal : Goal
{
    private DateTime _lastTime = DateTime.Today;
    private bool _done = false;
    private int _streak;
    public DailyGoal(string name, string description, string points) : base(name, description, points)
    {

    }

    public DailyGoal(string name, string description, string points, string lastTime, int streak, bool done) : base(name, description, points)
    {
        _lastTime = DateTime.Parse(lastTime);
        _streak = streak;
        if (_lastTime == DateTime.Today)
        {
            _done = done;
        }
        else
        {
            _done = false;
        }
    }

    public void CheckStreak()
    {
        if ((_lastTime - DateTime.Today).TotalDays >= 2)
        {
            _streak = 0;
        }
    }

    public override int RecordEvent()
    {
        int points = 0;
        if (!IsComplete())
        {
            _streak++;
            points = int.Parse(_points);
            _lastTime = DateTime.Today;
        }
        else
        {
            Console.WriteLine("Already completed for today!");
        }
        return points;
    }

    public override bool IsComplete()
    {
        return _lastTime == DateTime.Today && _done;
    }

    public override string GetStringRepresentation()
    {
        return $"D%%{_shortName}%%{_description}%%{_points}%%{_lastTime}%%{_streak}%%{_done}";
    }

    public override string GetDetailsString()
    {
        CheckStreak();
        string a = " ";
        if (IsComplete())
        {
            a = "X";
        }
        return $"[{a}] {_shortName} ({_description})\n     --> Points ({_points})   Daily Streak ({_streak})";
    }
}