using System.Collections;

public abstract class AchievementCard : DiceCard
{
    protected Occupation _occupation;
    protected string _type;

    public AchievementCard(string name, string description, int quantity, string[] amounts, string type, string cardType) : base(name, description, quantity, amounts, cardType)
    {
        _type = type;
    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
        if (_type == "education")
        {
            _occupation = (Education)a[1];
        }
        else
        {
            _occupation = (Job)a[0];
        }
    }

    public override ArrayList ReturnNewData()
    {
        if (_type == "school")
        {
            _a[1] = _occupation;
        }
        else if (_type == "work")
        {
            _a[0] = _occupation;
        }
        return _a;
    }
}