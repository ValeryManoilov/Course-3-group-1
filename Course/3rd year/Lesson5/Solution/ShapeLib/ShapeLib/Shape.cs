namespace ShapeLib;
public abstract class Shape
{
    public double Side {get; set;}
    public Shape() { }
    public Shape(double side)
    {
        this.Side = side;
    }
    public abstract double GetArea();
    public abstract double GetPerimeter();
}