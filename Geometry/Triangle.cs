using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public class Triangle : IFigure
    {
        class DescendedDateComparer : IComparer<float>
        {
            public int Compare(float x, float y)
            {
                int ascendingResult = Comparer<float>.Default.Compare(x, y);
                return 0 - ascendingResult;
            }
        }
        private readonly SortedSet<float> _lengths = new SortedSet<float>(new DescendedDateComparer());

        public Triangle()
        {
        }
        
        public Triangle(float a, float b, float c)
        {
            _lengths.Add(a);
            _lengths.Add(b);
            _lengths.Add(c);
        }

        public string Name => "Triangle";

        public double GetArea()
        {
            var _halfMeter = _lengths.Sum() / 2;
            var _area = Math.Sqrt(_halfMeter * _lengths.Select(l => _halfMeter - l).Aggregate((s, l) => s*l));
            return _area;
        }

        public bool IsRectangular()
        {
            float hypotenuse = _lengths.First();
            return hypotenuse*hypotenuse == _lengths.Skip(1).Sum(l => l * l);
        }
        
    }
}