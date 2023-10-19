using System.Collections;

public class BasicBankCard : Card
{
    private Bank _bank = new();
    private int _amount;
    private string _action;

    public BasicBankCard(string name, string details, int quantity, int amount, string action) : base(name, details, quantity, "hand")
    {
        _amount = amount;
        _action = action;
    }

    public override void Use()
    {
        if (_action == "deposit")
        {
            _bank.Deposit(_amount);
        }
        else if (_action == "withdraw")
        {
            _bank.Withdraw(_amount);
        }
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