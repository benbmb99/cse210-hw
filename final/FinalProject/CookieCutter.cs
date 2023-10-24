using System.Runtime.CompilerServices;

public class CookieCutter : House
{
    private static string _name = "Cookie Cutter";
    private static int _id = 1;
    private static int _cost = 500;

    public CookieCutter() : base(_name, _cost, _id)
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
}