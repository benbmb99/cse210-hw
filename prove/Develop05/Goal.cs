public abstract class Goal{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points){
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString(){
        string a = " ";
        if(IsComplete()){
            a = "X";
        }
        return $"[{a}] {_shortName} ({_description})\n     --> Points ({_points})";
    }

    public abstract string GetStringRepresentation();

    public string GetName(){
        return _shortName;
    }
}