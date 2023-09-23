using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class Prompt
{

    Random _random = new Random();
    int _lastNumber = -1;
    int _x;
    bool _same = true;
    public string _prompt = "(incomplete)";
    private List<string> CompilePrompts()
    {
        List<string> prompts = new List<string>();

        string prompt1 = "Who was the most interesting person I interacted with today?";
        string prompt2 = "What was the best part of my day?";
        string prompt3 = "How did I see the hand of the Lord in my life today?";
        string prompt4 = "What was the strongest emotion I felt today?";
        string prompt5 = "If I had one thing I could do over today, what would it be?";
        string prompt6 = "What was the worst part of my day?";
        string prompt7 = "How did I show kindness to someone else today?";
        string prompt8 = "What were the meals I ate today? Which was my favorite?";
        string prompt9 = "What am I most grateful about today?";
        string prompt0 = "What/who inspired you the most today?";
        prompts.Add(prompt0);
        prompts.Add(prompt1);
        prompts.Add(prompt2);
        prompts.Add(prompt3);
        prompts.Add(prompt4);
        prompts.Add(prompt5);
        prompts.Add(prompt6);
        prompts.Add(prompt7);
        prompts.Add(prompt8);
        prompts.Add(prompt9);
        return prompts;
    }

    public string SelectPrompt(string response)
    {
        if (response == "yes")
        {
            List<string> s = CompilePrompts();
            do
            {
                _same = true;
                _x = _random.Next(0, 9);
                if (_x != _lastNumber)
                {
                    _lastNumber = _x;
                    _same = false;
                }
            } while (_same);
            _prompt = s[_x];
        }
        else if (response == "no")
        {
            _prompt = "Freewrite";
        }
        Console.WriteLine("  " + _prompt);
        return _prompt;
    }
}