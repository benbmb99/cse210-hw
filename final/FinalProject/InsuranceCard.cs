using System.Collections;

public class InsuranceCard : DiceCard
{
    private static string[] _amount = { "0", "0", "0", "1", "1", "1", "1", "1", "0", "0", "0" };
    private bool _hasInsurance;

    public InsuranceCard(int quantity) : base("Insurance Card", "Roll a dice to see if your insurance kicks in.", quantity, _amount, "insurance")
    {

    }

    public override void Use()
    {
        Console.WriteLine("You can't use this now.");
        Thread.Sleep(2000);
    }

    public bool CheckInsurance()
    {
        if (_hasInsurance)
        {
            int x = RollDice();
            int check = int.Parse(_amount[x]);
            _hasInsurance = false;
            if (check == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
        _hasInsurance = (bool)a[6];
    }

    public override ArrayList ReturnNewData()
    {
        _a[6] = _hasInsurance;
        return _a;
    }
}