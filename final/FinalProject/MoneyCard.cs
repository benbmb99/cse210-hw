using System.Collections;

public class MoneyCard : DiceCard
{
    private Bank _bank = new();

    public MoneyCard(string name, string description, int quantity, string[] amounts) : base(name, description, quantity, amounts, "hand")
    {

    }

    public override void Use()
    {
        int x = RollDice();
        int money = int.Parse(_amounts[x]);
        _bank.Deposit(money);
    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
        _bank = (Bank)a[4];
    }

    public override ArrayList ReturnNewData()
    {
        _a[4] = _bank;
        return _a;
    }
}