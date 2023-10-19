using System;

class Programs
{
    static void Main(string[] args)
    {
        TotalWealthControlLLC company = new();
        company.SetPlayers();
        company.CreatePlayers();
        company.TakeTurns();
    }
}