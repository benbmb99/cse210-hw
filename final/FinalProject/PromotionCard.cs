using System.Collections;

public class PromotionCard : AchievementCard
{

    public PromotionCard(string name, string description, int quantity, string type, string[] amounts) : base(name, description, quantity, amounts, type, "hand")
    {

    }

    public override void Use()
    {
        int x = RollDice();
        if (_amounts[x] == "1")
        {
            _occupation.LevelUp();
        }
        else if (_amounts[x] == "2")
        {
            _occupation.LevelUp();
            _occupation.LevelUp();
        }
    }
}