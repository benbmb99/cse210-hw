using System.Collections;

public class CashForClunkers : Card
{
    private Random _dice = new();
    private Bank _bank = new();
    private List<Car> _cars = new();
    public CashForClunkers(string name, string details, int quantity) : base(name, details, quantity, "hand")
    {

    }

    public override void Use()
    {
        Random rand = new();
        int i = rand.Next(0, _cars.Count());
        Car car = _cars[i];
        int x = _dice.Next(1, 7);
        int y = _dice.Next(1, 7);
        int z = x + y;
        if (z > 11 || z < 3)
        {
            _bank.Deposit(20);
        }
        else if (z > 8 || z < 6)
        {
            _bank.Deposit(10);
        }
        else if (z != 7)
        {
            _bank.Deposit(5);
        }
        else
        {
            car.Sell(_bank);
        }
        car.ResetOwnership();
        _cars[i] = car;
    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
        _bank = (Bank)a[4];
        _cars = (List<Car>)a[2];
    }

    public override ArrayList ReturnNewData()
    {
        _a[4] = _bank;
        _a[2] = _cars;
        return _a;
    }
}