public abstract class Occupation
{
    protected string _levelTitle;

    public Occupation(string title)
    {
        _levelTitle = title;
    }

    public abstract int GetBonus();

    public abstract void LevelUp();

    public abstract void LevelDown();

    public string GetTitle()
    {
        return _levelTitle;
    }

    public virtual void FullDemote()
    {

    }
}