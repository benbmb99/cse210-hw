public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, string target, string bonus) : base(name, description, points)
    {
        bool done = false;
        do
        {

            try
            {
                _target = int.Parse(target);
                done = true;
            }
            catch
            {
                Console.WriteLine("You entered an invalid target goal.");
                Console.Write("Please enter the number of times you want to do this goal: ");
                target = Console.ReadLine();
            }
        } while (!done);
        do
        {
            done = false;
            try
            {
                _bonus = int.Parse(bonus);
                done = true;
            }
            catch
            {
                Console.WriteLine("You entered an invalid bonus.");
                Console.Write("Please enter the number of points to be recieved when this goal is fully completed: ");
                bonus = Console.ReadLine();
            }
        } while (!done);
    }

    public ChecklistGoal(string name, string description, string points, string bonus, string amountCompleted, string target) : base(name, description, points)
    {
        _target = int.Parse(target);
        _bonus = int.Parse(bonus);
        _amountCompleted = int.Parse(amountCompleted);
    }

    public override int RecordEvent()
    {
        int points = 0;
        if (!IsComplete())
        {
            _amountCompleted++;
            points = points + int.Parse(_points);
            if (IsComplete())
            {
                points = points + _bonus;
            }
            //_lastTime = DateTime.Today;
        }
        else
        {
            Console.WriteLine("Already completed!");
        }
        return points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override string GetDetailsString()
    {
        string a = " ";
        if (IsComplete())
        {
            a = "X";
        }
        return $"[{a}] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}\n     --> Points ({_points})  Completion Bonus ({_bonus})";
    }

    public override string GetStringRepresentation()
    {
        return $"C%%{_shortName}%%{_description}%%{_points}%%{_bonus}%%{_amountCompleted}%%{_target}";
    }
}