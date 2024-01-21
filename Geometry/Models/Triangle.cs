using Geometry.Abstracts;

namespace Geometry.Models
{
    /// <summary>
    /// Треугольник. Каждая сторона строго больше нуля. Одна сторона не может быть больше двух оставшихся.
    /// </summary>
    public class Triangle : Figure
    {
        private double[] _sides;

        /// <summary>
        /// Создание треугольника по трем сторонам.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double sideA, double sideB, double sideC) : this(new[] {sideA,  sideB, sideC}) { }

        public Triangle(IEnumerable<double> sides)
        {
            if (_sides is null || _sides.Count() != 3) throw new ArgumentException("У треугольника должно быть три стороны");

            var sortedSides = sides.OrderDescending().ToArray();

            if (!CheckEveryLength(sortedSides)) throw new ArgumentException("Некорректный ввод. Сторона может быть строго больше нуля.");
            if (!CheckAllLengths(sortedSides)) throw new ArgumentException("Некорректный ввод. Одна сторона не может быть больше двух других");

            _sides = sortedSides;
        }

        private bool CheckEveryLength(IEnumerable<double> sides)
        {
            foreach (var side in _sides)
                if(!(side >  0)) return false;
            return true;
        }

        private bool CheckAllLengths(IEnumerable<double> sortedSides) => sortedSides.ElementAt(0) < sortedSides.ElementAt(1) + sortedSides.ElementAt(2);

        private double Perimeter => _sides.Sum();
        public override double Area => Math.Sqrt(Perimeter * (Perimeter - _sides[0]) * (Perimeter - _sides[1]) * (Perimeter - _sides[2]));
        public bool IsRightTriangle => _sides[0] * _sides[0] == _sides[1] * _sides[1] + _sides[2] * _sides[2];
    }
}
