namespace ShapeLib;
public class Circle : Shape
{
    public double Radius {get; set;}
    public Circle(double side) : base(side) {
        this.Radius = side;
    }
    public override double GetArea()
    {
        return Math.Round(Math.Pow(this.Radius, 2) * Math.PI, 2);
    }
    public override double GetPerimeter()
    {
        return Math.Round(this.Radius * Math.PI * 2, 2);
    }
}