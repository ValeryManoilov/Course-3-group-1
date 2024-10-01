namespace ShapeLib;
public class Rect : Shape
{
    public double Widht {get; set;}
    public double Height {get; set;}
    public Rect() { }
    public Rect(double w, double h)
    {
        this.Widht = w;
        this.Height = h;
    }

    public override double GetArea()
    {
        return this.Widht * this.Height;
    }

    public override double GetPerimeter()
    {
        return (this.Widht * 2) + (this.Height * 2);
    }
}