using System;


public abstract class Shape
{
    protected IRenderer renderer;

    
    protected Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    
    public abstract void Draw();
}

public interface IRenderer
{
    void Render();
}


public class VectorRenderer : IRenderer
{
    public void Render()
    {
        Console.WriteLine("Drawing as vector");
    }
}


public class RasterRenderer : IRenderer
{
    public void Render()
    {
        Console.WriteLine("Drawing as pixels");
    }
}


public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        Console.Write("Circle: ");
        renderer.Render();
    }
}


public class Square : Shape
{
    public Square(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        Console.Write("Square: ");
        renderer.Render();
    }
}


public class Triangle : Shape
{
    public Triangle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        Console.Write("Triangle: ");
        renderer.Render();
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        var circle = new Circle(new VectorRenderer());
        circle.Draw();

        var square = new Square(new RasterRenderer());
        square.Draw();

        var triangle = new Triangle(new VectorRenderer());
        triangle.Draw();
    }
}
