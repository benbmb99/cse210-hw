using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.XPath;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _fileName;
    private int _level;
    private int _previousLevelUp;
    private int _nextLevelUp;

    public GoalManager()
    {
        _goals = new();
        _score = 0;
        _previousLevelUp = 0;
        _level = 1;
        _fileName = "";
        _nextLevelUp = 100;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("\nWelcome to DancingThroughLife's Life RPG!\n");
        bool done = false;
        do
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("What would you like to do?\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            Console.Write("Your choice: ");
            string response = Console.ReadLine();
            if (response == "1")
            {
                CreateGoal();
            }
            else if (response == "2")
            {
                ListGoalDetails();
            }
            else if (response == "3")
            {
                SaveGoals();
            }
            else if (response == "4")
            {
                LoadGoals();
            }
            else if (response == "5")
            {
                RecordEvent();
            }
            else if (response == "6")
            {
                done = true;
            }
            else if (response == "help")
            {
                LevelHelp();
            }
        } while (!done);
        Console.WriteLine("Thank you for using DancingThroughLife's Life RPG. Come back soon!");
        Thread.Sleep(5000);
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"You are currently at level {_level}.");
        LevelBar();
    }

    public void ListGoalNames()
    {
        int s = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{s}. {g.GetName()}");
            s++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();
        int s = 1;
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals, silly!");
        }
        else
        {
            Console.WriteLine("These are your goals: ");
        }
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{s}. {g.GetDetailsString()}");
            s++;
        }
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        Console.Clear();
        bool done = false;
        Console.WriteLine("\nThere are three types of goals:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal");
        Console.Write("Which goal would you like? (type 'help' for more information.) ");
        do
        {
            string response = Console.ReadLine().Trim();
            if (response == "1")
            {
                Console.Clear();
                Console.Write("What is a short name for your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of your goal? ");
                string description = Console.ReadLine();
                Console.Write("How many points is it worth? ");
                string points = Console.ReadLine();
                SimpleGoal a = new(name, description, points);
                _goals.Add(a);
                Console.WriteLine("Goal Added!");
                done = true;
            }
            else if (response == "2")
            {
                Console.Clear();
                Console.Write("What is a short name for your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of your goal? ");
                string description = Console.ReadLine();
                Console.Write("How many points is it worth per achievment? ");
                string points = Console.ReadLine();
                EternalGoal a = new(name, description, points);
                _goals.Add(a);
                Console.WriteLine("Goal Added!");
                done = true;
            }
            else if (response == "3")
            {
                Console.Clear();
                Console.Write("What is a short name for your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of your goal? ");
                string description = Console.ReadLine();
                Console.Write("How many points is it per time achieved? ");
                string points = Console.ReadLine();
                Console.Write("How many times would you like to do this goal? ");
                string target = Console.ReadLine();
                Console.Write($"What is the completion bonus for completing the the goal {target} times? ");
                string bonus = Console.ReadLine();
                ChecklistGoal a = new(name, description, points, target, bonus);
                _goals.Add(a);
                Console.WriteLine("Goal Added!");
                done = true;
            }
            else if (response == "help")
            {
                Console.Clear();
                Console.WriteLine("There are three types of goals:\n  1. Simple Goal - (A basic goal that is checked off once accomplished.)\n  2. Eternal Goal - (A goal accomplished daily, but it's never completed.)\n  3. Checklist Goal - (A goal to do multiple times, no specific time frame.)");
                Console.Write("Which goal would you like? ");
            }
            else
            {
                Console.WriteLine("Invalid Response.");
                Console.Write("Choose another option: ");
                Thread.Sleep(2000);
            }
        } while (!done);
        Thread.Sleep(2000);
    }

    public void RecordEvent()
    {
        Console.WriteLine();
        bool done = false;
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals, silly!");
        }
        else
        {
            Console.WriteLine("The goals are:");
            ListGoalNames();
            Console.Write("Which goal did you complete? ");
            int points;
            do
            {
                string response = Console.ReadLine();
                try
                {
                    int result = int.Parse(response);
                    points = _goals[result - 1].RecordEvent();
                    done = true;
                    _score += points;
                    if (points > 0)
                    {
                        Console.WriteLine("\nEvent Recorded.");
                    }
                }
                catch
                {
                    if (response == "quit")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid response, please try again: ");
                    }
                }
            } while (!done);
            Thread.Sleep(2000);
            LevelChecker();
        }
    }

    public void SaveGoals()
    {
        bool abort = false;
        if (_fileName == "")
        {
            Console.Write("Which file would you like to save to? ");
            string response = Console.ReadLine();
            if (!response.EndsWith(".rpg"))
            {
                response += ".rpg";
            }
            if (File.Exists(response))
            {
                _fileName = response;
            }
            else if (response == "" || response == "quit")
            {
                abort = true;
            }
            else
            {
                Console.Write("File does not yet exist. Would you like to create it? (yes/no) ");
                string response1 = Console.ReadLine();
                if (response1 == "yes")
                {
                    _fileName = response;
                }
                else
                {
                    abort = true;
                }
            }
        }
        if (!abort || _fileName != "")
        {
            using (StreamWriter outputFile = new StreamWriter(_fileName))
            {
                outputFile.WriteLine($"U%%{_score}%%{_level}%%{_previousLevelUp}%%{_nextLevelUp}");
                foreach (Goal g in _goals)
                {
                    outputFile.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.Write("Saving");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write("\b \b\b \b\b \b\b \b\b \b\b");
            Console.WriteLine("e successful.");
        }
        else
        {
            Console.WriteLine("Save cancelled.");
        }
        Thread.Sleep(2000);
    }

    public void LoadGoals()
    {
        bool good = false;
        do
        {
            Console.Write("\nWhat is the name of the file you'd like to load? ");
            string file = Console.ReadLine();
            if (!file.EndsWith(".rpg"))
            {
                file += ".rpg";
            }
            else if (file == "quit")
            {
                break;
            }
            bool exists = File.Exists(file);
            if (exists)
            {
                _fileName = file;
                good = true;
            }
            else
            {
                Console.WriteLine("\nError 404: File not found.");
                Console.WriteLine($"Would you like to create the file: {file}?");
                string response = Console.ReadLine();
                if (response == "yes")
                {
                    Console.WriteLine("File created.");
                    _fileName = file;
                    good = true;
                }
            }
        } while (!good);
        if (good)
        {
            string[] lines = System.IO.File.ReadAllLines(_fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split("%%");

                string type = parts[0];
                if (type == "U")
                {
                    _score = int.Parse(parts[1]);
                    _level = int.Parse(parts[2]);
                    _previousLevelUp = int.Parse(parts[3]);
                    _nextLevelUp = int.Parse(parts[4]);
                }
                else if (type == "S")
                {
                    bool complete = false;
                    if (parts[4] == "True")
                    {
                        complete = true;
                    }
                    SimpleGoal s = new(parts[1], parts[2], parts[3], complete);
                    _goals.Add(s);
                }
                else if (type == "E")
                {
                    bool complete = false;
                    if (parts[6] == "True")
                    {
                        complete = true;
                    }
                    EternalGoal e = new(parts[1], parts[2], parts[3], parts[4], int.Parse(parts[5]), complete);
                    _goals.Add(e);
                }
                else if (type == "C")
                {
                    ChecklistGoal c = new(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
                    _goals.Add(c);
                }
            }
            LevelChecker();
        }
        Thread.Sleep(2000);
    }

    public void Celebrate()
    {
        Console.WriteLine($"\nCongratulations! You just leveled up to level {_level}!\n");
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
        Console.Write("\b *\\(^v^)/*");
        Thread.Sleep(5000);
    }

    public void LevelChecker()
    {
        int levelUp = _level * 100 + _previousLevelUp;
        _nextLevelUp = levelUp;
        if (_score >= levelUp)
        {
            _level++;
            Celebrate();
            _previousLevelUp = levelUp;
            _nextLevelUp = _level * 100 + _previousLevelUp;
        }
    }

    public void LevelHelp(){
        Console.WriteLine("These are the number of points for each level: ");
        int x = 1;
        int p = 0;
        while(x<=20){
            int s = x*100+p;
            Console.WriteLine($"Level {x}: {s} points");
            x++;
            p=s;
        }
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }

    public void LevelBar(){
        double x = (_score - _previousLevelUp) / (2 * _level);
        Console.Write($"{_previousLevelUp} [");
        for(int i = 1; i<=50; i++){
            if(x>i){
                Console.Write("|");
            }else if(x<=i){
                Console.Write(" ");
            }
        }
        Console.WriteLine($"] {_nextLevelUp}\n");
    }
}