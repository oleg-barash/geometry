using System;
using System.Collections.Generic;
using System.Linq;
using Geometry;
using NUnit.Framework;
namespace Tests
{
    public class Tests
    {
        private List<IFigure> _figures;
        [SetUp]
        public void Setup()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IFigure).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToArray();
            _figures = new List<IFigure>(100);
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var r = rnd.Next(types.Length);
                _figures.Add((IFigure)Activator.CreateInstance(types[r]));
            }
        }

        [Test]
        public void Test()
        {
            _figures.Select(f => f.GetArea());
            Assert.Pass();
        }

        [Test]
        public void RectangularWorks()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Assert.IsTrue(triangle.IsRectangular());
            triangle = new Triangle(5, 4, 3);
            Assert.IsTrue(triangle.IsRectangular());
            Assert.Pass();  
        }
        
        [Test]
        public void TriangleAreaCalculatedCorrectly()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Assert.IsTrue(triangle.GetArea() == 6);
            Assert.Pass();  
        }
        
    }
}