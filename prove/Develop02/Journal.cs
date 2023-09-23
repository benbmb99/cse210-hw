using System.Net;
using System.Net.Quic;
using System.Security.Cryptography;

public class Journal
{

    public string _fileName = "myJournal.jrnl";
    public List<Entry> _journal = new List<Entry>();
    public int _total = 0;

    public Journal(string fileName, List<Entry> entries)
    {
        this._fileName = fileName;
        this._journal = entries;
    }

    public void NewEntry()
    {
        Entry entry = new Entry("", "");
        Console.Write("\nWould you like a prompt? ");
        string response = Console.ReadLine();
        Console.Write(entry._date);
        Prompt prompt = new Prompt();
        entry._myPrompt = prompt.SelectPrompt(response);
        entry._myEntry = Console.ReadLine();
        Console.Write("\nWould you like to save the entry? (yes/no) ");
        string save = Console.ReadLine();
        if (save == "yes")
        {
            _journal.Add(entry);
            _total++;
        }
    }

    public void QuickLoad(string _fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(_fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(" %%");

            string date = parts[0];
            string entryTitle = parts[1];
            string entry = parts[2];

            Entry entry1 = new Entry(entryTitle, entry, date);
            _journal.Add(entry1);
            _total++;
        }
    }

    public void LoadJournal()
    {
        if (_journal.Any() && _fileName != "")
        {
            Console.Write("Would you like to save the previous journal before loading a new one? (yes/no) ");
            string response = Console.ReadLine();
            if (response == "yes")
            {
                SaveJournal();
                _journal.Clear();
                _total = 0;
            }
        }
        if (_journal.Any() && _fileName == "")
        {
            Console.Write("Would you like to append the entries to a journal? (yes/no) ");
            string response = Console.ReadLine();
            if (response == "no")
            {
                _journal.Clear();
                _total = 0;
            }
        }
        Console.Write("\nWhat is the name of the journal file you'd like to load? ");
        string file = Console.ReadLine();
        if (!file.EndsWith(".jrnl"))
        {
            file = file + ".jrnl";
        }
        bool exists = File.Exists(file);
        if (exists)
        {
            _fileName = file;
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
            }
        }

        string[] lines = System.IO.File.ReadAllLines(_fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(" %%");

            string date = parts[0];
            string entryTitle = parts[1];
            string entry = parts[2];

            Entry entry1 = new Entry(entryTitle, entry, date);
            _journal.Add(entry1);
            _total++;
        }
    }

    public void SaveJournal()
    {
        bool abort = false;
        if (_fileName == "")
        {
            Console.Write("Which file would you like to save to? ");
            string response = Console.ReadLine();
            if (!response.EndsWith(".jrnl"))
            {
                response = response + ".jrnl";
            }
            if (File.Exists(response))
            {
                _fileName = response;
            }
            else if (response == "")
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
                foreach (Entry entry in _journal)
                {
                    outputFile.WriteLine(entry._date + " %%" + entry._myPrompt + " %% " + entry._myEntry);
                }
            }
            Console.Write("Saving");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine("Save successful.");
        }
        else
        {
            Console.WriteLine("Save cancelled.");
        }
    }

    public void DisplayAll()
    {
        Console.WriteLine();
        foreach (Entry entry in _journal)
        {
            entry.DisplayEntry();
        }
    }
}