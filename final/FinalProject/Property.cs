public abstract class Property
{
    private string _name;
    private int _cost;
    protected string _owner = "Unowned";

    public Property(string name, int cost)
    {
        _name = name;
        _cost = cost;
    }

    public int GetCost()
    {
        return _cost;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetOwner()
    {
        return _owner;
    }

    public int Purchase(string playerName)
    {
        _owner = playerName;
        return _cost;
    }

    public abstract void Sell(Bank bank);

    public void ResetOwnership()
    {
        _owner = "Unowned";
    }
}