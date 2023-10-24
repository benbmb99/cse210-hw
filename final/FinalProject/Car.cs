using System.Data;

public class Car : Property
{

    private int _resaleValue;

    public Car(string name, int cost, int resale, int id) : base(name, cost, id)
    {
        _resaleValue = resale;
    }

    public void Crash()
    {
        if (GetName() == "Escalade")
        {
            Console.WriteLine("\"Well that \"Escaladed\" quickly! ");
        }
        Console.WriteLine("You totaled your car!");
        ResetOwnership();
    }

    public override void Sell(Bank bank)
    {
        bank.Deposit(_resaleValue);
        ResetOwnership();
    }

    public override void SellEnd(Bank bank)
    {
        bank.FinalSell(_resaleValue);
    }

}