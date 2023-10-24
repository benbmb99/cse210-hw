using System.Collections;

public class JuryDutyCard : BasicBankCard
{
    private Random _dice = new();
    private bool _skip = false;

    public JuryDutyCard(string name, string details, int quantity, int amount, string action) : base(name, details, quantity, amount, action)
    {

    }

    public override void Use()
    {
        base.Use();
        int x = _dice.Next(0, 6);
        int y = _dice.Next(0, 6);
        int z = x + y;
        if (z >= 6 && z <= 8)
        {
            _skip = true;
            Console.WriteLine("Your next turn will be skipped.");
            Thread.Sleep(2000);
        }
    }

    public override ArrayList ReturnNewData()
    {
        _a[4] = _bank;
        _a[5] = _skip;
        return _a;
    }
}