using System.Collections;
using System.Net;

public class CarDealership
{
    private List<Car> _allCars = new();

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

            Car a = new(name, cost, resale);
            _allCars.Add(a);
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
        //}
        a = new() { c, bank };
        return a;
    }

    public int DisplayCars()
    {
        bool done = false;
        int response = -1;
        do
        {
            Console.Clear();
            Console.WriteLine("These are the available cars: ");
            int count = 1;
            foreach (Car c in _allCars)
            {
                if (c.GetOwner() == "Unowned")
                {
                    Console.WriteLine($"  {count}. {c.GetName()}");
                }
                count++;
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
            }
        } while (!done);
        return response;
    }

    // public void SaveCars()
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