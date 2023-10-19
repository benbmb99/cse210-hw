using System.Collections;

public class DemotionCard : AchievementCard
{
    private bool _skipTest = false;
    private bool _skip = false;

    public DemotionCard(string name, string description, int quantity, string[] amounts, string type) : base(name, description, quantity, amounts, type, "multiplayer")
    {

    }

    public override void Use()
    {
        int x = RollDice();
        if (_amounts[x] == "1")
        {
            _occupation.LevelDown();
            if (_skipTest)
            {
                _skip = true;
                Console.WriteLine("Your next turn will be skipped.");
                Thread.Sleep(2000);
            }
        }
        else if (_amounts[x] == "s")
        {
            _skip = true;
            Console.WriteLine("Your next turn will be skipped.");
            Thread.Sleep(2000);
        }
    }

    public override void SetParameters(ArrayList a)
    {
        base.SetParameters(a);
        if (_type == "jobskip")
        {
            _skipTest = true;
        }
    }

    public override ArrayList ReturnNewData()
    {
        ArrayList a = base.ReturnNewData();
        if (_skipTest == true)
        {
            a[5] = _skip;
        }
        return a;
    }
}