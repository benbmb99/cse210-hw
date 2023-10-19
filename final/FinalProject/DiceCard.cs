public abstract class DiceCard : Card
{
    private Random _dice = new();

    protected string[] _amounts = new string[11];

    public DiceCard(string name, string details, int quantity, string[] amounts, string cardType) : base(name, details, quantity, cardType)
    {
        _amounts = amounts;
    }

    public int RollDice()
    {
        int x = _dice.Next(0, 6);
        int y = _dice.Next(0, 6);
        return x + y;
    }
}