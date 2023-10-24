using System.Collections;
using System.Reflection.Metadata.Ecma335;

public class LoseLicenseCard : Card
{

    public LoseLicenseCard(string name, string details, int quantity) : base(name, details, quantity, "multiplayer")
    {

    }

    public override void SetParameters(ArrayList a)
    {
        _a = a;
    }

    public override void Use()
    {
        _a[7] = false;
    }

    public override ArrayList ReturnNewData()
    {
        return _a;
    }
}