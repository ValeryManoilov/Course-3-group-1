namespace ShapeLib; 
public class Square : Shape
{
    public double Side {get; set;}
    public Square(double side) : base(side) {
        this.Side = side;
    }

    public override double GetArea()
    {
        return Math.Round(Math.Pow(this.Side, 2), 2);
    }
    public override double GetPerimeter()
    {
        return Math.Round(this.Side * 4, 2);
    }
} 