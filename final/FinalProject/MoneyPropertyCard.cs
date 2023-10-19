using System.Collections;

public class MoneyPropertyCard : DiceCard
{
    private Bank _bank = new();
    private List<House> _houses = new();

    public MoneyPropertyCard(string name, string description, int quantity, string[] amounts) : base(name, description, quantity, amounts, "hand")
    {

    }

    public override void Use()
    {
        int totalValue = 0;
        foreach (House h in _houses)
        {
            totalValue += h.GetCost();
        }
        int x = RollDice();
        double y = totalValue / (int.Parse(_amounts[x]) / 100);
        int z = (int)Math.Round(y);
        _bank.Deposit(z);
    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
        _bank = (Bank)a[4];
        _houses = (List<House>)a[3];
    }


    public override ArrayList ReturnNewData()
    {
        _a[4] = _bank;
        return _a;
    }
}