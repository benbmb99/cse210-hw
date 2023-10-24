using System.Collections;
using System.Net;
using System.Text;

public class Realtor
{
    private List<House> _allHouses = new();
    private List<House> _soldHouses = new();
    private List<House> _unsoldHouses = new();

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
            _unsoldHouses.Add(a);
        }
    }

    public ArrayList BuyHouse(int houseNum, string playerName, Bank bank)
    {
        int cost;
        House h = new("", 0, 0);
        ArrayList a;
        //if (_allHouses[houseNum].GetOwner() == "Unowned")
        //{
        if (houseNum >= 0)
        {
            cost = _allHouses[houseNum].Purchase(playerName);
            bank.Buy(cost);
            h = _allHouses[houseNum];
            _soldHouses.Add(h);
            _unsoldHouses.Remove(h);
        }
        else
        {
            CookieCutter cc = new();
            cost = cc.Purchase(playerName);
            bank.Buy(cost);
            h = cc;
        }
        //}
        a = new() { h, bank };
        return a;
    }

    public int DisplayHouses()
    {
        bool done = false;
        int response = -1;
        int count = 0;
        do
        {
            Console.WriteLine("These are the available houses: ");
            int side = 0;
            House old = new("", 0, 0);
            if (_unsoldHouses.Count() > 0)
            {
                foreach (House h in _unsoldHouses)
                {
                    count++;
                    /* Console.WriteLine($"{(count == _allHouses.Count())} + {(h.GetOwner() != "Unowned" && old.GetOwner() == "Unowned")} or {(h.GetOwner() == "Unowned" && old.GetOwner() != "Unowned")}");
                    Console.WriteLine($"{(count == _allHouses.Count())} + {((h.GetOwner() != "Unowned" && old.GetOwner() == "Unowned") || (h.GetOwner() == "Unowned" && old.GetOwner() != "Unowned"))}");
                    Console.WriteLine($"{((count == _allHouses.Count()) && ((h.GetOwner() != "Unowned" && old.GetOwner() == "Unowned") || (h.GetOwner() == "Unowned" && old.GetOwner() != "Unowned")))}");
                    if ((count == _allHouses.Count()) && ((h.GetOwner() != "Unowned" && old.GetOwner() == "Unowned") || (h.GetOwner() == "Unowned" && old.GetOwner() != "Unowned")))
                    //fix this if you can
                    {
                        if (h.GetOwner() == "Unowned")
                        {
                            Console.WriteLine($"  {h.GetID()}. {h.GetName()}");
                        }
                        else
                        {
                            Console.WriteLine($"  {old.GetID()}. {old.GetName()}");
                        }
                    }else*/
                    if (h.GetOwner() == "Unowned")
                    {
                        if (side == 0)
                        {
                            if (count == _unsoldHouses.Count())
                            {
                                Console.WriteLine($"  {h.GetID()}. {h.GetName()}");
                            }
                            old = h;
                            side = 1;
                        }
                        else
                        {
                            var s = new StringBuilder();
                            s.Append(String.Format("  {0,-2}. {1,-14}  {2,-2}. {3,-13}", old.GetID(), old.GetName(), h.GetID(), h.GetName()));
                            Console.WriteLine(s);
                            //if (h.GetID() + 1 != _allHouses.Count())
                            //{
                            side = 0;
                            //}
                        }
                    }
                }
                Console.Write("Which house would you like to buy? ");
                string k = "";
                try
                {
                    Exception e = new();
                    k = Console.ReadLine();
                    response = int.Parse(k);
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
                    if (k == "quit" || k == "no")
                    {
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Response.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine($"  1. Cookie Cutter");
                Console.Write("Which house would you like to buy? ");
                string k = "";
                try
                {
                    Exception er = new();
                    k = Console.ReadLine();
                    response = int.Parse(k);
                    if (response == 1)
                    {
                        response = 0;
                    }
                    done = true;
                }
                catch (Exception er)
                {
                    if (k == "quit" || k == "no")
                    {
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Response.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }
        } while (!done);
        return response;
    }

    public void CheckSold()
    {
        foreach (House h in _allHouses)
        {
            if (h.GetOwner() == "Unowned")
            {
                try
                {
                    _soldHouses.Remove(h);
                    _unsoldHouses.Add(h);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}