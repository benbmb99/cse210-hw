using System;

//Websites I used:
//https://www.w3schools.com/cs/cs_for_loop.php
//https://stackoverflow.com/questions/919244/converting-a-string-to-datetime

//Extras:
//I created a menu that helps explain the number of points to get to each level. You can access it by typing 'help'
//on the main menu. I also created a level bar that fills up each time you record an event. It shows you how far
//you are from the previous level to the next level. That being said, each level is incremented by 100 points, so
//level 1 is 100 points, to get to level 2 it's 200 points (total 300 pts), to get to level 3 it's 300 points (total
//500 pts), etc. I also created a little congratulations celebration every time you level up! I also enhanced several
//bits of the saving and loading schemes to prevent user error.
//Oh, and I also created a fourth "Daily Goal" option, too. Yes, it keeps track of your day-to-day streak. B) 

class Program
{
    static void Main(string[] args)
    {
        GoalManager n = new();
        n.Start();
    }
}