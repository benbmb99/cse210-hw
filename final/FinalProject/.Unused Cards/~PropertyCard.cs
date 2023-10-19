//public abstract class PropertyCard:Card{
    protected Property _property;

    public PropertyCard(string name, string details, int quantity, Property property):base(name, details, quantity){
        _property = property;
    }
}