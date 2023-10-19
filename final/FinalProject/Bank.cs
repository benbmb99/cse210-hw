public class Bank
{
    private int _cashInBank = 0;
    private int _debt = 0;

    public void Buy(int cost)
    {
        _debt += cost;
        Console.WriteLine($"Your debt increased by ${cost} to ${_debt}!");
        Thread.Sleep(2000);
    }

    public void PayOff(int amount)
    {
        if (amount <= _cashInBank)
        {
            _debt -= amount;
            _cashInBank -= amount;
            Console.WriteLine($"You paid off ${amount} of your debt!");
        }
        else
        {
            Console.WriteLine("Insufficient funds to complete transaction.");
        }
        Thread.Sleep(2000);
    }

    public int GetDebt()
    {
        return _debt;
    }

    public void Deposit(int amount)
    {
        _cashInBank += amount;
        Console.WriteLine($"You added ${amount} to the bank!");
        Thread.Sleep(2000);
    }

    public void Withdraw(int amount)
    {
        _cashInBank -= amount;
        Console.WriteLine($"You took ${amount} out of the bank!");
        Thread.Sleep(2000);
    }

    public int GetCashInBank()
    {
        return _cashInBank;
    }


    public void CollectPaycheck(Job job, Education education)
    {
        int pay = job.GetBonus();
        pay = pay * education.GetBonus();
        _cashInBank += pay;
        Console.WriteLine($"You got paid ${pay} this turn!");
        Thread.Sleep(2000);
    }

    public void PayFare()
    {
        _cashInBank -= 2;
        Console.WriteLine("You paid your taxi fares of $2.");
    }
}