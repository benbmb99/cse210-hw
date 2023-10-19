using System.Collections;

public class BasicAchievementCard : Card
{
    private Occupation _occupation;
    private string _action;
    private string _type;

    public BasicAchievementCard(string name, string details, int quantity, string action, string type) : base(name, details, quantity, "auto")
    {
        _action = action;
        _type = type;
    }

    public override void Use()
    {
        if (_action == "levelup")
        {
            _occupation.LevelUp();
        }
        else if (_action == "leveldown")
        {
            _occupation.LevelDown();
        }
        else if (_action == "fired")
        {
            _occupation.FullDemote();
        }
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