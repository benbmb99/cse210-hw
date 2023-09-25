using System.Dynamic;
using System.Runtime.InteropServices;

public class Fraction{
    private int _top;
    private int _bottom;
    public Fraction(){
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int topNum){
        _top = topNum;
        _bottom = 1;
    }
    public Fraction(int topNum, int bottomNum){
        _top = topNum;
        _bottom = bottomNum;
    }
    public void SetTop(int top){
        _top = top;
    }

    public int GetBottom(){
        return _bottom;
    }

    public int GetTop(){
        return _top;
    }

    public void SetBottom(int bottom){
        _bottom = bottom;
    }

    public string GetFractionString(){
        string abs = $"{_top}/{_bottom}";
        return abs;
    }

    public double GetDecimalValue(){
        double dec = (double)_top / (double)_bottom;
        return dec;
    } 
}