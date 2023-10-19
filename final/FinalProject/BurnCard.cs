using System.Collections;

public class BurnCard : Card
{
    private bool _hasInsurance;
    private List<House> _houses = new();
    private Bank _bank = new();
    private Random _rand = new();

    public BurnCard(string name, string details, int quantity, string cardType) : base(name, details, quantity, cardType)
    {

    }

    public override void Use()
    {
        int i = _rand.Next(0, _houses.Count());
        House house = _houses[i];
        if (_hasInsurance)
        {
            InsuranceCard a = new InsuranceCard(1);
            if (a.CheckInsurance())
            {
                Console.WriteLine("Your insurance covered the cost of your house.");
                _bank.PayOff(house.GetCost());
            }
            else
            {
                Console.WriteLine("Your house burned down and your insurance didn't cover the costs.");
            }
            _hasInsurance = false;
        }
        house.BurnItDown();
        _houses[i] = house;
    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
        _houses = (List<House>)a[3];
        _bank = (Bank)a[4];
        _hasInsurance = (bool)a[6];
    }

    public override ArrayList ReturnNewData()
    {
        _a[3] = _houses;
        _a[4] = _bank;
        _a[6] = _hasInsurance;
        return _a;
    }
}