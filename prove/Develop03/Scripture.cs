using System.Diagnostics;

public class Scripture
{

    private Reference _reference = new Reference("", -1, -1);
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text, bool status)
    {
        this._reference = reference;
        string[] words = text.Split(" ");
        int r = 0;
        foreach (string w in words)
        {
            Word word = new Word(w);
            word.SetStatus(status);
            _words.Add(word);
            r++;
        }

    }

    public void HideWords(int numToHide)
    {
        Random random = new Random();
        while (numToHide > 0)
        {
            if (!IsCompletelyHidden())
            {
                int r = random.Next(0, _words.Count());
                if (!_words[r].IsHidden())
                {
                    int n = random.Next(0, 2);
                    if (n == 1)
                    {
                        _words[r].Hide();
                        numToHide--;
                    }
                }
            }
            else
            {
                numToHide = 0;
            }
        }
    }



    public string GetDisplayText()
    {
        Console.Clear();
        string verse = $"{_reference.GetDisplayText()}\n\n";
        foreach (Word word in _words)
        {
            verse = $"{verse} {word.GetDisplayText()}";
        }
        return verse;
    }

    public bool IsCompletelyHidden()
    {
        bool unhidden = false;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                unhidden = true;
                break;
            }
        }
        return !unhidden;
    }
}