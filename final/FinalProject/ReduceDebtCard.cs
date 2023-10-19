using System.Collections;

public class ReduceDebtCard : DiceCard
{
    private Bank _bank = new();

    public ReduceDebtCard(string name, string description, int quantity, string[] amount) : base(name, description, quantity, amount, "hand")
    {

    }

    public override void Use()
    {
        int x = RollDice();
        double j = int.Parse(_amounts[x]) / 100;
        double y = _bank.GetDebt();
        int z = (int)(y / j);
        if (z < 1)
        {
            z = 1;
        }
        _bank.PayOff(z);
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