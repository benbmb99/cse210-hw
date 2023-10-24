using System.Collections;

public class FlunkedFinalsCard : BasicBankCard
{

    public FlunkedFinalsCard(string name, string details, int quantity, int amount, string action) : base(name, details, quantity, amount, action)
    {

    }

    public override ArrayList ReturnNewData()
    {
        _a[4] = _bank;
        _a[9] = false;
        return _a;
    }
}