public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {

    }

    public SimpleGoal(string name, string description, string points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        int points = 0;
        if (!_isComplete)
        {
            points = int.Parse(_points);
            _isComplete = true;
        }
        else
        {
            Console.WriteLine("You can't complete this task twice.");
        }
        return points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"S%%{_shortName}%%{_description}%%{_points}%%{_isComplete}";
    }
}