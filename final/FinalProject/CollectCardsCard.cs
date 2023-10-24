using System.Collections;

public class CollectCardsCard : Card
{
    private int _amount;

    public CollectCardsCard(string name, string details, int quantity, int amount) : base(name, details, quantity, "hand")
    {
        _amount = amount;
    }
    public override void SetParameters(ArrayList a)
    {
        _a = a;
    }

    public override void Use()
    {
        _a[8] = (int)_a[8] + _amount;
    }

    public override ArrayList ReturnNewData()
    {
        return _a;
    }
}