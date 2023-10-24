using System.Collections;
using System.Net;
using System.Text;

public class CarDealership
{
    private List<Car> _allCars = new();
    private List<Car> _unsoldCars = new();
    private List<Car> _soldCars = new();

    public CarDealership()
    {
        LoadCars();
    }

    private void LoadCars()
    {
        string[] lines = System.IO.File.ReadAllLines("AllCars.car");

        foreach (string line in lines)
        {
            string[] parts = line.Split("%%");

            string name = parts[0];
            int cost = int.Parse(parts[1]);
            int resale = cost / 2;
            int id = int.Parse(parts[2]);

            Car a = new(name, cost, resale, id);
            _allCars.Add(a);
            _unsoldCars.Add(a);
        }
    }



    public ArrayList BuyCar(int carNum, string playerName, Bank bank)
    {
        int cost;
        Car c;
        ArrayList a;
        //if (_allCars[carNum].GetOwner() == "Unowned")
        //{
        cost = _allCars[carNum].Purchase(playerName);
        bank.Buy(cost);
        c = _allCars[carNum];
        _soldCars.Add(c);
        _unsoldCars.Remove(c);
        //}
        a = new() { c, bank };
        return a;
    }

    public int DisplayCars()
    {
        bool done = false;
        int response = -1;
        int count = 0;
        do
        {
            Console.WriteLine("These are the available cars: ");
            int side = 0;
            Car old = new("", 0, 0, 0);
            foreach (Car c in _allCars)
            {
                count++;
                if (c.GetOwner() == "Unowned")
                {
                    if (side == 0)
                    {
                        if (count == _unsoldCars.Count() && count % 2 == 1)
                        {
                            Console.WriteLine($"  {c.GetID()}. {c.GetName()}");
                        }
                        old = c;
                        side = 1;
                    }
                    else
                    {
                        var s = new StringBuilder();
                        s.Append(String.Format("  {0,-2}. {1,-14}  {2,-2}. {3,-13}", old.GetID(), old.GetName(), c.GetID(), c.GetName()));
                        Console.WriteLine(s);
                        //if (c.GetID() + 1 != _allCars.Count())
                        //{
                        side = 0;
                        //}
                    }
                }
            }
            Console.Write("Which car would you like to buy? ");
            try
            {
                Exception e = new();
                response = int.Parse(Console.ReadLine());
                if (response < 1 || response > count)
                {
                    throw e;
                }
                if (_allCars[response - 1].GetOwner() != "Unowned")
                {
                    Console.WriteLine($"{_allCars[response - 1].GetName()} is already owned by {_allCars[response - 1].GetOwner()}.");
                    throw e;
                }
                done = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Response.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        } while (!done);
        return response;
    }

    public int GetCarsAvailable()
    {
        int i = 0;
        foreach (Car c in _allCars)
        {
            if (c.GetOwner() == "Unowned")
            {
                i++;
            }
        }
        return i;
    }

    // public void SaveCars()  Not yet
    // {
    //     using (StreamWriter outputFile = new StreamWriter("currentGame.car"))
    //     {
    //         foreach (Car c in _allCars)
    //         {
    //             outputFile.WriteLine($"{c.GetName()}%%{c.GetCost()}%%{c.GetOwner()}");
    //         }
    //     }
    // }
}