using System.Collections;
using System.Dynamic;
using System.Security.Claims;

public class WealthManager
{
    private string _playerName;
    private int _carsAvailable;
    private Job _myJob = new();
    private Education _myEducation = new();
    private List<Car> _myCars = new();
    private List<House> _myHouse = new();
    private List<Card> _myHand = new();
    private List<Card> _oldHand = new();
    private Bank _myBank = new();
    private bool _isComplete = false;
    private bool _skipTurn = false;
    private bool _hasInsurance = false;
    private bool _usedInsurance = false;
    private bool _taxi = false;
    private bool _hasLicense = true;
    private int _cardsToCollect = 0;
    private bool _conferance = true;
    private int _turns = 1;

    public WealthManager(string name)
    {
        _playerName = name;
    }

    public ArrayList BuildInfoPacket()
    {
        ArrayList a = new(){
            _myJob,
            _myEducation,
            _myCars,
            _myHouse,
            _myBank,
            _skipTurn,
            _hasInsurance,
            _hasLicense,
            _cardsToCollect,
            _conferance
        };
        return a;
    }

    public void Unpack(ArrayList a)
    {
        _myJob = (Job)a[0];
        _myEducation = (Education)a[1];
        _myCars = (List<Car>)a[2];
        _myHouse = (List<House>)a[3];
        _myBank = (Bank)a[4];
        _skipTurn = (bool)a[5];
        _usedInsurance = !(bool)a[6];
        _hasLicense = (bool)a[7];
        _cardsToCollect = (int)a[8];
        _conferance = (bool)a[9];
    }

    public ArrayList TakeTurn(ArrayList a, int numOfPlayers)
    {
        Console.Clear();
        if (!_skipTurn)
        {
            bool done = false;
            if (numOfPlayers > 1)
            {
                Console.WriteLine($"It is now {_playerName}'s turn.");
                Thread.Sleep(1000);
            }
            if (_taxi)
            {
                _myBank.PayFare();
            }
            if (_conferance)
            {
                _myEducation.CheckConferance();
                _conferance = true;
            }
            CarDealership c = (CarDealership)a[0];
            Realtor r = (Realtor)a[1];
            _carsAvailable = c.GetCarsAvailable();
            CardDeck cd = (CardDeck)a[2];
            if (_hasLicense)
            {
                _myBank.CollectPaycheck(_myJob, _myEducation);
            }
            else
            {
                Education none = new();
                _myBank.CollectPaycheck(_myJob, none);
                _hasLicense = true;
            }
            _myHand.Add(cd.PickCard());
            _myHand.Add(cd.PickCard());
            Console.WriteLine("You drew two cards.");
            CheckCards();
            Thread.Sleep(5000);
            List<Card> remove = new();
            foreach (Card l in _myHand)
            {
                if (l.GetCardType() == "auto" || (l.GetCardType() == "multiplayer" /* && numOfPlayers == 1 */)) //to be used when multiplayer is updated
                {
                    if (_turns == 1 && (l.GetName() == "Accident" || l.GetName() == "My House Burned" || l.GetName() == "Arsonist"))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"\"{l.GetName()}\" was played automatically!");
                        l.SetParameters(BuildInfoPacket());
                        l.Use();
                        l.ReturnNewData();
                        remove.Add(l);
                    }
                }
            }
            foreach (Card card in remove)
            {
                _myHand.Remove(card);
            }
            do
            {
                if (_myCars.Count() < 1 && !_taxi)
                {
                    bool done1 = false;
                    do
                    {
                        if (_carsAvailable > 0)
                        {
                            Console.Write("\nYou don't have a car! Would you like to (1) buy a car or (2) use public transportation? ");
                            try
                            {
                                Exception e = new();
                                int choice = int.Parse(Console.ReadLine());
                                if (choice == 1)
                                {
                                    Console.WriteLine("You don't have a car! Let's buy one: ");
                                    ContactCarDealership(c);
                                    done1 = true;
                                }
                                else if (choice == 2)
                                {
                                    _taxi = true;
                                    done1 = true;
                                }
                                else
                                {
                                    throw e;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid Entry.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are currently no cars available for purchase.\nAs a result, you are automatically enrolled in public transportation.\n If you want to change this, please try purchasing a car again later.");
                            _taxi = true;
                        }
                    } while (!done1);
                }
                if (_myHouse.Count() < 1)
                {
                    Console.WriteLine("\nYou don't have a house! Let's buy one: ");
                    ContactRealtor(r);
                }
                Console.Clear();
                CheckInsurance();
                Console.WriteLine("What would you like to do?\n  1. Use Cards\n  2. View Cards (and Details)\n  3. Pay Off Debt\n  4. View Bank Info\n  5. View Player Info\n  6. Buy House/Car\n  7. Sell House/Car\n  8. Go to School\n  9. End Turn");
                Console.Write("Your choice: ");
                string response = Console.ReadLine().Trim();
                if (response == "1")
                {
                    UseCards();
                }
                else if (response == "2")
                {
                    ViewCards();
                }
                else if (response == "3")
                {
                    PayOffDebt();
                }
                else if (response == "4")
                {
                    ViewBankInfo();
                }
                else if (response == "5")
                {
                    DisplayPlayerInfo();
                }
                else if (response == "6")
                {
                    Console.Write("Would you like to buy (1) a house or (2) a car? ");
                    try
                    {
                        Exception e = new();
                        int response1 = int.Parse(Console.ReadLine());
                        if (response1 == 1)
                        {
                            Console.WriteLine("Choose a house to buy: ");
                            ContactRealtor(r);
                        }
                        else if (response1 == 2)
                        {
                            Console.WriteLine("Choose a car to buy:");
                            ContactCarDealership(c);
                            if (_taxi)
                            {
                                _taxi = false;
                            }
                        }
                        else
                        {
                            throw e;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid entry. Please try again.");
                    }
                }
                else if (response == "8")
                {
                    ContactUniversity();
                }
                else if (response == "7")
                {
                    Sell();
                }
                else if (response == "9")
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Invalid Entry.");
                    Thread.Sleep(2000);
                }
                int count = 0;
                while (_cardsToCollect > 0)
                {
                    _myHand.Add(cd.PickCard());
                    _cardsToCollect--;
                    count++;
                }
                if (count > 0)
                {
                    Console.WriteLine($"You drew {count} cards!");
                }
                CheckCards();
                CheckProperty();
            } while (!done);
            CheckCompletion();
            ArrayList b = new() { c, r, _isComplete, cd };
            _turns++;
            return b;
        }
        else
        {
            Console.WriteLine($"It is {_playerName}'s turn, but we have to skip their turn.");
            Thread.Sleep(2000);
            _skipTurn = false;
            _turns++;
            return a;
        }
    }

    public void UseCards()
    {
        if (_myHand.Count() > 0)
        {
            int response = -1;
            bool done = false;
            do
            {
                Console.Clear();
                Console.WriteLine("These are your cards: ");
                int count = 1;
                foreach (Card d in _myHand)
                {
                    Console.WriteLine($"  {count}. {d.GetName()}");
                    count++;
                }
                Console.Write("Which card would you like to use? ");
                try
                {
                    Exception e = new();
                    response = int.Parse(Console.ReadLine());
                    if (response < 1 || response >= count)
                    {
                        throw e;
                    }
                    else
                    {
                        done = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Response.");
                    Thread.Sleep(2000);
                }
            } while (!done);
            if (_myHand[response - 1].GetCardType() == "multiplayer")
            {
                //fill in here for multiplayer update
            }
            _myHand[response - 1].SetParameters(BuildInfoPacket());
            _myHand[response - 1].Use();
            _myHand[response - 1].ReturnNewData();
            Console.WriteLine($".{_myHand[response - 1].GetName()}.");
            if (!(_myHand[response - 1].GetType() is InsuranceCard))
            {
                _myHand.RemoveAt(response - 1);
                _oldHand.RemoveAt(response - 1);
            }
        }
        else
        {
            Console.WriteLine("You have no cards.");
            Thread.Sleep(2000);
        }
    }

    public void ContactRealtor(Realtor r)
    {
        Console.Clear();
        int house = r.DisplayHouses() - 1;
        ArrayList f = r.BuyHouse(house, _playerName, _myBank);
        if (house != -1)
        {
            _myHouse.Add((House)f[0]);
        }
        else
        {
            _myHouse.Add((CookieCutter)f[0]);
        }
        _myBank = (Bank)f[1];
    }

    public void ContactCarDealership(CarDealership c)
    {
        Console.Clear();
        int car = c.DisplayCars() - 1;
        ArrayList f = c.BuyCar(car, _playerName, _myBank);
        _myCars.Add((Car)f[0]);
        _myBank = (Bank)f[1];
    }

    public void ContactUniversity()
    {
        Console.Clear();
        if (_myEducation.GetTitle() != "Doctorate")
        {
            if (_myEducation.GetStatus() != "Attending")
            {
                Console.Write("An education costs 10 dollars to begin.\nDo you want to start attending?(y/n) ");
                string response1 = Console.ReadLine();
                if (response1 == "y")
                {
                    _myBank.Buy(10);
                    _myEducation.SetStatus();
                }
            }
            else
            {
                Console.WriteLine("You are already attending school!");
                Thread.Sleep(2000);
            }
        }
        else
        {
            Console.WriteLine("You already have your Doctorate!");
        }
    }

    public void ViewCards()
    {
        Console.Clear();
        if (_myHand.Count() > 0)
        {
            Console.WriteLine("These are your cards: ");
            int count = 1;
            foreach (Card c in _myHand)
            {
                Console.WriteLine($"  {count}. {c.GetName()}: {c.GetDetails()}");
                count++;
            }
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("You don't have any cards.");
            Thread.Sleep(2000);
        }
    }

    public void PayOffDebt()
    {
        Console.Clear();
        Console.Write("How much debt would you like to payoff? ");
        try
        {
            Exception e = new();
            int money = int.Parse(Console.ReadLine());
            if (money > _myBank.GetCashInBank() || money <= 0)
            {
                Console.WriteLine("You don't have enough money.");
                throw e;
            }
            else
            {
                _myBank.PayOff(money);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid Entry.");
            Thread.Sleep(2000);
        }
    }

    public void ViewBankInfo()
    {
        Console.Clear();
        Console.WriteLine("Your bank info: ");
        Console.WriteLine($"  Cash in Bank: {_myBank.GetCashInBank()}");
        Console.WriteLine($"  Remaining Debt: {_myBank.GetDebt()}");
        Console.WriteLine("\nPress Enter to Continue. ");
        Console.ReadLine();
    }

    public void CheckProperty()
    {
        List<int> removeH = new();
        foreach (House h in _myHouse)
        {
            if (h.GetOwner() == "Unowned")
            {
                removeH.Add(_myHouse.IndexOf(h));
            }
        }
        List<int> removeC = new();
        foreach (Car c in _myCars)
        {
            if (c.GetOwner() == "Unowned")
            {
                removeC.Add(_myCars.IndexOf(c));
            }
        }
        foreach (int i in removeH)
        {
            _myHouse.RemoveAt(i);
        }
        foreach (int i in removeC)
        {
            _myCars.RemoveAt(i);
        }
    }

    public void CheckCompletion()
    {
        if (_myBank.GetDebt() <= 0)
        {
            _isComplete = true;
        }
    }

    public void CheckInsurance()
    {
        foreach (Card c in _myHand)
        {
            if (c.GetName() == "Insurance")
            {
                if (_hasInsurance && _usedInsurance)
                {
                    _myHand.Remove(c);
                    _usedInsurance = false;
                    _hasInsurance = false;
                }
                else if (_hasInsurance && !_usedInsurance)
                {
                    _hasInsurance = true;
                }
            }
            else
            {
                _hasInsurance = false;
            }
        }
    }

    public string ReturnName()
    {
        return _playerName;
    }

    public void DisplayPlayerInfo()
    {
        Console.Clear();
        Console.WriteLine($"{_playerName}'s info is:");
        Console.WriteLine($"  Job Level: {_myJob.GetTitle()}\n  Education Level: {_myEducation.GetTitle()}");
        Console.WriteLine($"  Cars:");
        foreach (Car c in _myCars)
        {
            Console.WriteLine($"     Name: {c.GetName()}  Resale Value: {c.GetCost() / 2}");
        }
        Console.WriteLine($"  Houses:");
        foreach (House c in _myHouse)
        {
            Console.WriteLine($"     Name: {c.GetName()}  Resale Value: {c.GetCost()}");
        }
        Console.WriteLine("Press Enter to Continue.");
        Console.ReadLine();
    }

    public void Sell()
    {
        Console.Clear();
        Console.Write("Would you like to sell (1) a house or (2) a car? ");
        try
        {
            Exception e = new();
            int response1 = int.Parse(Console.ReadLine());
            if (response1 == 1)
            {
                if (_myHouse.Count() > 1)
                {
                    Console.WriteLine("Choose a house to sell: ");
                    int count = 1;
                    foreach (House h in _myHouse)
                    {
                        Console.WriteLine($"  {count}. {h.GetName()}");
                        count++;
                    }
                    Console.Write("House to sell: ");
                    try
                    {
                        int response = int.Parse(Console.ReadLine());
                        _myHouse[response - 1].Sell(_myBank);
                        Console.WriteLine($"{_myHouse[response - 1].GetName()} sold!");
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine("Invalid entry. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("You can't sell your only house. ");
                }
            }
            else if (response1 == 2)
            {
                if (_myCars.Count() > 1)
                {
                    Console.WriteLine("Choose a car to sell: ");
                    int count = 1;
                    foreach (Car c in _myCars)
                    {
                        Console.WriteLine($"  {count}. {c.GetName()}");
                        count++;
                    }
                    Console.Write("Car to sell: ");
                    try
                    {
                        int response = int.Parse(Console.ReadLine());
                        _myCars[response - 1].Sell(_myBank);
                        Console.WriteLine($"{_myCars[response - 1].GetName()} sold!");
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine("Invalid entry. Please try again.");
                    }
                }
                else if (_myCars.Count() == 1)
                {
                    Console.WriteLine("You can't sell your only car. ");
                }
                else
                {
                    Console.WriteLine("You don't have any cars to sell.");
                }
            }
            else
            {
                throw e;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid entry. Please try again.");
        }
        Thread.Sleep(2000);
    }

    public void CheckCards()
    {
        foreach (Card c in _myHand)
        {
            if (!(_oldHand.Contains(c)))
            {
                Console.WriteLine($"You drew the card: {c.GetName()}");
                Console.WriteLine($"   Description ---> {c.GetDetails()}");
                _oldHand.Add(c);
            }
        }
    }

    public ArrayList EndGame()
    {
        List<Car> cars = new();
        List<House> houses = new();
        int finalValue;
        foreach (Car c in _myCars)
        {
            c.SellEnd(_myBank);
            cars.Add(c);
        }
        foreach (House h in _myHouse)
        {
            h.Sell(_myBank);
            houses.Add(h);
        }
        finalValue = _myBank.EndGame();
        ArrayList a = new() { cars, houses, finalValue, _playerName };
        return a;
    }
}