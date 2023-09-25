using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(5);
        Fraction frac3 = new Fraction(6,7);
        frac1.SetTop(5);
        frac1.SetBottom(8);
        int x = frac3.GetBottom();
        int y = frac2.GetTop();
        Console.WriteLine(x + " " + y);
        Console.WriteLine($"{frac1.GetFractionString()}\n{frac1.GetDecimalValue()}");
        Console.WriteLine($"{frac2.GetFractionString()}\n{frac2.GetDecimalValue()}");
        Console.WriteLine($"{frac3.GetFractionString()}\n{frac3.GetDecimalValue()}");
    }
}