using Geometry.Abstracts;

namespace Geometry.Models
{
    public class Circle : Figure
    {
        private double _radius;

        public Circle(double radius)
        {
            if (!(radius > 0)) throw new ArgumentException("Радиус строго положительный");
            _radius = radius;
        }
        public override double Area => Math.PI * _radius * _radius;
    }
}
