using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class TotalWealthControlLLC
{
    private CarDealership _dealership = new();
    private Realtor _realtor = new();
    private int _numOfPlayers = 1;
    private List<WealthManager> _players = new();
    private CardDeck _cd = new();
    private bool _gameOver = false;
    private ArrayList _finalValues = new();


    public void SetPlayers()
    {
        bool done = false;
        Console.Clear();
        Console.WriteLine("       Welcome to the Game of Debt!");
        Thread.Sleep(1000);
        Console.WriteLine("...where your goal is to get out of debt the quickest.");
        Thread.Sleep(2000);
        Console.Write("\nHow many players would you like to play with? ");
        do
        {
            try
            {
                Exception e = new();
                _numOfPlayers = int.Parse(Console.ReadLine());
                if (_numOfPlayers > 4)
                {
                    Console.WriteLine("We don't recommend more than 4 players.\nAre you sure you want to continue? ");
                    string response = Console.ReadLine().ToLower();
                    if (response == "yes")
                    {
                        done = true;
                    }
                    else
                    {
                        throw e;
                    }
                }
                done = true;
            }
            catch (Exception e)
            {
                Console.Write("Invalid Entry. Please try again: ");
                Thread.Sleep(2000);
            }
        } while (!done);
        if (_numOfPlayers == 1)
        {
            Console.WriteLine("WARNING: Single player mode is still in beta stages.");
        }
    }

    // public void SetCPUs() //One day :`) Not this timme. Just in here so I can figure it out for next time.
    // {
    //     bool done = false;
    //     do
    //     {
    //         Console.Write("How many CPUs would you like to play with? ");
    //         try
    //         {
    //             _numOfCPUs = int.Parse(Console.ReadLine());
    //             done = true;
    //         }
    //         catch (Exception e)
    //         {
    //             Console.Write("Invalid Entry. Please try again: ");
    //         }
    //     } while (!done);
    // }

    public void CreatePlayers()
    {
        int x = 1;
        do
        {
            string name = $"Player {x}";
            Console.Write($"What is your name, player {x}? (Press Enter for default) ");
            string response = Console.ReadLine().Trim();
            if (!(response == ""))
            {
                name = response;
            }
            WealthManager a = new(name);
            _players.Add(a);
            x++;
        } while (x <= _numOfPlayers);
    }

    public void TakeTurns()
    {
        do
        {
            foreach (WealthManager a in _players)
            {
                ArrayList info = new()
            {
                _dealership,
                _realtor,
                _cd
            };
                ArrayList final = a.TakeTurn(info, _numOfPlayers);
                _dealership = (CarDealership)final[0];
                _realtor = (Realtor)final[1];
                _gameOver = (bool)final[2];
                _cd = (CardDeck)final[3];
                if (_gameOver)
                {
                    //     _winner = a.ReturnName();
                    break;
                }
            }
        } while (!_gameOver);
        GameOver();
    }

    public void GameOver()
    {
        List<Car> winnersCars = new();
        List<House> winnersHouses = new();
        int winnersValue = -4000;
        string winner = "";
        foreach (WealthManager w in _players)
        {
            _finalValues.Add(w.EndGame());
        }
        foreach (ArrayList a in _finalValues)
        {
            if ((int)a[2] > winnersValue)
            {
                winnersCars = (List<Car>)a[0];
                winnersHouses = (List<House>)a[1];
                winnersValue = (int)a[2];
                winner = (string)a[3];
            }
        }
        Celebrate(winner, winnersValue, winnersCars, winnersHouses);
        Console.WriteLine("Thanks for playing!");
        Thread.Sleep(5000);
    }

    public void Celebrate(string winner, int winnerValue, List<Car> winnerCars, List<House> winnerHouses)
    {
        Console.WriteLine($"Congratulations! {winner} won!");
        Console.WriteLine($"{winner} ended with:");
        Console.WriteLine($" {winner}'s Value: ${winnerValue}");
        Console.WriteLine($" Houses:");
        foreach (House h in winnerHouses)
        {
            Console.WriteLine($"   {h.GetName()}  Value: {h.GetCost()}");
        }
        foreach (Car c in winnerCars)
        {
            Console.WriteLine($"   {c.GetName()}  Value: {c.GetCost()}");
        }
        Console.WriteLine();
        int sec = 5;
        do
        {
            Console.Write("(~^.^)~");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" (~^.^)~");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write("  ~(^.^~)");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" ~(^.^~)");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" (~^_^)~");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write("  (~^_^)~");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write("   (~^_^)~");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write("  ~(^v^~)");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" ~(^v^~)");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" (~^v^)~");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" (~^v^)~");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write("\\(^.^)\\");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" /(^o^)/");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" \\(^.^)\\");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            Console.Write(" /(^o^)/");
            Thread.Sleep(250);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b");
            sec--;
        } while (sec > 0);
        Console.WriteLine("\b *\\(^v^)/*");
    }

}