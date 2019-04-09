using System;

namespace Geometry
{
    public class Circle : IFigure
    {
        private readonly double _radius;

        public Circle() { }

        public Circle(double radius)
        {
            _radius = radius;
        }
        public string Name { get; set; } = "Circle";
        public double GetArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}