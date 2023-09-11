using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep 4 World!");
        List<int> numbers = new List<int>();
        Boolean c = true;
        Console.WriteLine("Enter a list of numbers. Type 0 when you are done.");
        do{
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();
            int num = int.Parse(input);
            if (num!=0){
                numbers.Add(num);
            }else{c=false;}
        }while(c);
        int sum = 0;
        int largest = -2147483647;
        int smallest = 2147483647;
        int smallTo0 = smallest;
        foreach(int num in numbers){
            sum += num;
            if (num<smallTo0 && num>0){
                smallTo0 = num;
            }
            if(num<smallest){smallest=num;}
            if(num>largest){largest=num;}
        }
        float av = sum/numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {av:0.000}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest number is: {smallest}");
        Console.WriteLine($"The smallest positive number is: {smallTo0}");
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers){
            Console.WriteLine(num);
        }

    }
}