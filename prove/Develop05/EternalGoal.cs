public class EternalGoal : Goal
{
    
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {

    }

    public override int RecordEvent()
    {
        int points = int.Parse(_points);
        return points;
    }

    public override bool IsComplete()
    {
        //return _lastTime == DateTime.Today && _done;
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"E%%{_shortName}%%{_description}%%{_points}";
    }
}