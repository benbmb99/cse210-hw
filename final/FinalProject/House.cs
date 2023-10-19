public class House : Property
{
    private int _id;

    public House(string name, int cost, int id) : base(name, cost)
    {
        _id = id;
    }

    public void BurnItDown()
    {
        _owner = "Unowned";
    }

    public override void Sell(Bank bank)
    {
        int x = GetCost();
        bank.Deposit(x);
        _owner = "Unowned";
    }

    public int GetID()
    {
        return _id;
    }
}