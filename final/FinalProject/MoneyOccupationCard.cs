using System.Collections;

public class MoneyOccupationCard : AchievementCard
{
    private Bank _bank = new();

    public MoneyOccupationCard(string name, string description, int quantity, string[] amounts, string type) : base(name, description, quantity, amounts, type, "hand")
    {

    }

    public override void Use()
    {
        int x = RollDice();
        int y = int.Parse(_amounts[x]) * _occupation.GetBonus();
        _bank.Deposit(y);
    }

    public override void SetParameters(ArrayList a)
    {
        _bank = (Bank)a[4];
        base.SetParameters(a);
    }


    public override ArrayList ReturnNewData()
    {
        _a[4] = _bank;
        return base.ReturnNewData();
    }
}