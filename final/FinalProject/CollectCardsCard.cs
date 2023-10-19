using System.Collections;

public class CollectCardsCard : Card
{
    int _amount;

    public CollectCardsCard(string name, string details, int quantity, int amount) : base(name, details, quantity, "hand")
    {
        _amount = amount;
    }
    public override void SetParameters(ArrayList a)
    {

    }

    public override void Use()
    {

    }

    public override ArrayList ReturnNewData()
    {
        return _a;
    }
}