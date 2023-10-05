using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> list = new();
        Square s = new("yellow", 5);
        list.Add(s);
        //Console.WriteLine(s.GetColor());
        //Console.WriteLine(s.GetArea());
        Rectangle r = new("red", 3, 5);
        list.Add(r);
        //Console.WriteLine(r.GetColor());
        //Console.WriteLine(r.GetArea());
        Circle c = new("blue", 4);
        list.Add(c);
        //Console.WriteLine(c.GetColor());
        //Console.WriteLine(c.GetArea());

        foreach(Shape q in list){
            Console.WriteLine(q.GetColor());
            Console.WriteLine(q.GetArea());
        }
    }
}