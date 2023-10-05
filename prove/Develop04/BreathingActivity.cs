public class BreathingActivity : Activity
{

    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 30)
    {

    }

    public void Run()
    {
        DisplayStartingMessage();
        do
        {
            Console.Write("\n\nBreathe in... ");
            ShowCountdown(4);
            Console.Write("\nBreathe out... ");
            ShowCountdown(6);
        } while (CheckTimer());
        DisplayEndingMessage();
    }
}