

using System.Runtime.InteropServices.Marshalling;

class Tire
{
    private double width;

    private double radius;

    private double aspectRatio;


public Tire(double width, double aspectRatio, double radius)
{
    this.width = width;
    this.radius = radius;
    this.aspectRatio = aspectRatio;

}

public void Display()
{
    Console.WriteLine($"Tire Information: Width: {width}, Ratio: {radius}, Aspect Ratio: {aspectRatio}");
}

}