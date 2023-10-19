using System.Collections;

public class CarDamageCard : DiceCard
{
    private static string[] _amount = { "0", "10", "10", "10", "5", "Totaled", "5", "10", "10", "10", "0" };
    private List<Car> _cars = new();
    private Bank _bank = new();
    private Random _rand = new();

    public CarDamageCard(int quantity) : base("Accident", "You got in an accident and must pay money.", quantity, _amount, "auto")
    {

    }

    public override void Use()
    {
        int x = RollDice();
        try
        {
            int money = int.Parse(_amount[x]);
            _bank.Withdraw(money);
        }
        catch (Exception e)
        {
            if (_amount[x] == "Totaled")
            {
                Car car = _cars[_rand.Next(0, _cars.Count())];
                car.Crash();
            }
        }
    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
        _cars = (List<Car>)a[2];
        _bank = (Bank)a[4];
    }

    public override ArrayList ReturnNewData()
    {
        _a[2] = _cars;
        _a[4] = _bank;
        return _a;
    }
}