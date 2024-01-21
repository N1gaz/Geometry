using Geometry.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (sides is null || sides.Count() != 3) throw new ArgumentException("У треугольника должно быть три стороны");

            var sortedSides = sides.OrderByDescending(x => x).ToArray();

            if (!CheckEveryLength(sortedSides)) throw new ArgumentException("Некорректный ввод. Сторона может быть строго больше нуля.");
            if (!CheckAllLengths(sortedSides)) throw new ArgumentException("Некорректный ввод. Одна сторона не может быть больше двух других");

            _sides = sortedSides;
        }

        private bool CheckEveryLength(IEnumerable<double> sides)
        {
            foreach (var side in sides)
                if(!(side >  0)) return false;
            return true;
        }

        private bool CheckAllLengths(IEnumerable<double> sortedSides) => sortedSides.ElementAt(0) < sortedSides.ElementAt(1) + sortedSides.ElementAt(2);

        private double P => _sides.Sum() / 2.0; //Полупериметр
        public override double Area => Math.Sqrt(P * (P - _sides[0]) * (P - _sides[1]) * (P - _sides[2]));
        public bool IsRightTriangle => _sides[0] * _sides[0] == _sides[1] * _sides[1] + _sides[2] * _sides[2];
    }
}
