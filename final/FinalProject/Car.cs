using System.Data;

public class Car : Property
{

    private int _resaleValue;

    public Car(string name, int cost, int resale) : base(name, cost)
    {
        _resaleValue = resale;
    }

    public void Crash()
    {
        ResetOwnership();
    }

    public override void Sell(Bank bank)
    {
        bank.Deposit(_resaleValue);
        ResetOwnership();
    }

}