using System.Collections;

public abstract class Card
{
    private string _name;
    private string _details;
    protected int _quantity;
    protected ArrayList _a = new();
    protected string _cardType;

    public Card(string name, string details, int quantity, string cardType)
    {
        _name = name;
        _details = details;
        _quantity = quantity;
        _cardType = cardType;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDetails()
    {
        return _details;
    }

    public abstract void SetParameters(ArrayList a);

    public abstract void Use();

    public string Collect()
    {
        _quantity--;
        return _name;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public abstract ArrayList ReturnNewData();

    public string GetCardType()
    {
        return _cardType;
    }
}