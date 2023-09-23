using System.Xml.Linq;
using System.IO;
using System.Net;

public class Entry
{
    static DateTime _today = DateTime.Now;
    public string _date = _today.ToShortDateString();
    public string _myPrompt = "";
    public string _myEntry = "";
    public Entry(string prompt, string entry, string date = "")
    {
        if (date == "")
        {
            date = _today.ToShortDateString();
        }
        this._date = date;
        this._myPrompt = prompt;
        this._myEntry = entry;
    }

    public void DisplayEntry()
    {
        Console.WriteLine(_date + "  " + _myPrompt);
        Console.WriteLine(_myEntry);
        Console.WriteLine();
    }

}