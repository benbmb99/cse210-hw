public class House : Property
{

    public House(string name, int cost, int id) : base(name, cost, id)
    {

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

    public override void SellEnd(Bank bank)
    {
        int x = GetCost();
        bank.FinalSell(x);
    }
}