using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep 2 World!");
        Console.WriteLine("What is the percentage for the class? ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);
        string grade = "";
        if(percentage>=90){
            grade = "A";
        }else if(percentage>=80){
            grade = "B";
        }else if(percentage>=70){
            grade = "C";
        }else if(percentage>=60){
            grade = "D";
        }else if(percentage<60){
            grade = "F";
        }

        int pom = percentage % 10;

        if(pom>=7 && percentage<95 && percentage>60){
            grade=grade+"+";
        }else if(pom<3 && percentage>=60){
            grade=grade+"-";
        }

        Console.WriteLine($"The appropriate letter grade is {grade}.");

        if(percentage>=70){
            Console.WriteLine("Congratulations! You passed the class!");
        }else{
            Console.WriteLine("Sorry. You failed the class. Try again next semester!");
        }
    }
}