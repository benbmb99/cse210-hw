using System.Collections;

public class PellGrantCard : Card
{
    private Education _education = new();
    private Bank _bank = new();

    public PellGrantCard(string name, string details, int quantity) : base(name, details, quantity, "hand")
    {

    }

    public override void Use()
    {
        if (_education.GetStatus() == "Attending")
        {
            _bank.Deposit(10);
        }
        else if (_education.GetStatus() == "Not Attending")
        {
            if (_education.GetTitle() != "CEO")
            {
                _education.SetStatus();
            }
            else
            {
                _bank.Deposit(10);
            }
        }
    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
        _education = (Education)a[1];
        _bank = (Bank)a[4];
    }

    public override ArrayList ReturnNewData()
    {
        _a[1] = _education;
        _a[4] = _bank;
        return _a;
    }
}