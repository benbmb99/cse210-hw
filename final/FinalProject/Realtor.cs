using System.Collections;
using System.Text;

public class Realtor
{
    private List<House> _allHouses = new();
    private List<House> _soldHouses = new();

    public Realtor()
    {
        LoadHouses();
    }

    private void LoadHouses()
    {
        CheckSold();
        string[] lines = System.IO.File.ReadAllLines("AllHouses.house");

        foreach (string line in lines)
        {
            string[] parts = line.Split("%%");

            string name = parts[0];
            int cost = int.Parse(parts[1]);
            int id = int.Parse(parts[2]);

            House a = new(name, cost, id);
            _allHouses.Add(a);
        }
    }

    public ArrayList BuyHouse(int houseNum, string playerName, Bank bank)
    {
        int cost;
        House h;
        ArrayList a;
        //if (_allHouses[houseNum].GetOwner() == "Unowned")
        //{
        cost = _allHouses[houseNum].Purchase(playerName);
        bank.Buy(cost);
        h = _allHouses[houseNum];
        _soldHouses.Add(h);
        //}
        a = new() { h, bank };
        return a;
    }

    public int DisplayHouses()
    {
        bool done = false;
        int response = -1;
        do
        {
            Console.WriteLine("These are the available houses: ");
            int side = 0;
            House old = new("", 0, 0);
            foreach (House h in _allHouses)
            {

                if (h.GetOwner() == "Unowned")
                {
                    if (side == 0)
                    {
                        old = h;
                        side = 1;
                    }
                    else
                    {
                        if ((old.GetID()-_soldHouses.Count()) == (_allHouses.Count()-_soldHouses.Count()))
                        //fix this if you can
                        {
                            Console.WriteLine($"  {old.GetID()}. {old.GetName()}");
                        }else{
                        var s = new StringBuilder();
                        s.Append(String.Format("  {0,-2}. {1,-14}  {2,-2}. {3,-13}", old.GetID(), old.GetName(), h.GetID(), h.GetName()));
                        Console.WriteLine(s);
                        if (h.GetID() + 1 != _allHouses.Count())
                        {
                            side = 0;
                        }
                        }
                        
                    }

                }
            }
            Console.Write("Which house would you like to buy? ");
            try
            {
                Exception e = new();
                response = int.Parse(Console.ReadLine());
                if (response < 1 && response >= _allHouses.Count() + 1)
                {
                    Console.WriteLine("Error");
                    throw e;
                }
                if (_allHouses[response - 1].GetOwner() != "Unowned")
                {
                    Console.WriteLine($"{_allHouses[response - 1].GetName()} is already owned by {_allHouses[response - 1].GetOwner()}.");
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

    public void CheckSold(){
        foreach(House h in _allHouses){
            if(h.GetOwner()=="Unowned");
            try{
                _soldHouses.Remove(h);
            }catch(Exception e){

            }
        }
    }
}