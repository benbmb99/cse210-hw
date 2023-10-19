using System.IO.Pipes;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

public class CardDeck
{
    private List<Card> _allCards = new();
    private Random _rand = new();

    public CardDeck()
    {
        Shuffle();
    }

    public void Shuffle()
    {
        string[] lines = System.IO.File.ReadAllLines("TotalCards.card");

        foreach (string line in lines)
        {
            string[] parts = line.Split("%%");

            string type = parts[0];
            if (type == "BAC")
            {
                int quantity = int.Parse(parts[1]);
                string name = parts[2];
                string details = parts[3];
                string ctype = parts[5];
                string action = parts[4];
                BasicAchievementCard bac = new(name, details, quantity, action, ctype);
                _allCards.Add(bac);
            }
            else if (type == "BBC")
            {
                int quantity = int.Parse(parts[1]);
                string name = parts[2];
                string details = parts[3];
                int amount = int.Parse(parts[4]);
                string action = parts[5];
                BasicBankCard bbc = new(name, details, quantity, amount, action);
                _allCards.Add(bbc);
            }
            else if (type == "CFC")
            {
                int quantity = int.Parse(parts[1]);
                string name = parts[2];
                string details = parts[3];
                CashForClunkers cfc = new(name, details, quantity);
                _allCards.Add(cfc);
            }
            else if (type == "DC")
            {
                string type2 = parts[1];
                if (type2 == "AC")
                {
                    int quantity = int.Parse(parts[2]);
                    string name = parts[3];
                    string details = parts[4];
                    string amount = parts[5];
                    string[] amounts = amount.Split("-");
                    string ctype = parts[6];
                    PromotionCard pc = new(name, details, quantity, ctype, amounts);
                    _allCards.Add(pc);
                }
                else if (type2 == "MC")
                {
                    if (parts[2] == "MPC")
                    {
                        int quantity = int.Parse(parts[3]);
                        string name = parts[4];
                        string details = parts[5];
                        string amount = parts[6];
                        string[] amounts = amount.Split("-");
                        MoneyPropertyCard mpc = new(name, details, quantity, amounts);
                        _allCards.Add(mpc);
                    }
                    else if (parts[2] == "MOC")
                    {
                        int quantity = int.Parse(parts[3]);
                        string name = parts[4];
                        string details = parts[5];
                        string amount = parts[6];
                        string[] amounts = amount.Split("-");
                        string ctype = parts[7];
                        MoneyOccupationCard moc = new(name, details, quantity, amounts, ctype);
                        _allCards.Add(moc);
                    }
                    else
                    {
                        int quantity = int.Parse(parts[2]);
                        string name = parts[3];
                        string details = parts[4];
                        string amount = parts[5];
                        string[] amounts = amount.Split("-");
                        MoneyCard mc = new(name, details, quantity, amounts);
                        _allCards.Add(mc);
                    }
                }
                else if (type2 == "LC")
                {
                    int quantity = int.Parse(parts[2]);
                    string name = parts[3];
                    string details = parts[4];
                    string amount = parts[5];
                    string[] amounts = amount.Split("-");
                    string ctype = parts[6];
                    DemotionCard dc = new(name, details, quantity, amounts, ctype);
                    _allCards.Add(dc);
                }
                else if (type == "RDb")
                {
                    int quantity = int.Parse(parts[2]);
                    string name = parts[3];
                    string details = parts[4];
                    string amount = parts[5];
                    string[] amounts = amount.Split("-");
                    ReduceDebtCard rdc = new(name, details, quantity, amounts);
                    _allCards.Add(rdc);
                }
            }
            else if (type == "In")
            {
                int quantity = int.Parse(parts[1]);
                InsuranceCard i = new(quantity);
                _allCards.Add(i);
            }
            else if (type == "PG")
            {
                int quantity = int.Parse(parts[1]);
                string name = parts[2];
                string details = parts[3];
                PellGrantCard pg = new(name, details, quantity);
                _allCards.Add(pg);
            }
            else if (type == "CDC")
            {
                int quantity = int.Parse(parts[1]);
                CarDamageCard cdc = new(quantity);
                _allCards.Add(cdc);
            }
            else if (type == "BURN")
            {
                int quantity = int.Parse(parts[1]);
                string name = parts[2];
                string details = parts[3];
                string cardType = parts[4];
                BurnCard burn = new(name, details, quantity, cardType);
                _allCards.Add(burn);
            }
        }
    }

    public Card PickCard()
    {
        List<string> index = new();
        List<string> choices = new();
        foreach (Card c in _allCards)
        {
            int x = c.GetQuantity();
            index.Add(c.GetName());
            while (x > 0)
            {
                choices.Add(c.GetName());
                x--;
            }
        }
        int j = _rand.Next(0, choices.Count());
        int k = index.IndexOf(choices[j]);
        _allCards[k].Collect();
        return _allCards[k];
    }
}