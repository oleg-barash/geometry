using System;

namespace Geometry
{
    public interface IFigure
    {
        string Name { get; }
        double GetArea();
    }
}