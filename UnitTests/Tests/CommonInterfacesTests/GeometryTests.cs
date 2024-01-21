using Geometry.Abstracts;
using Geometry.Implementations;
using Geometry.Models;
using Xunit;

namespace Tests.Tests.CommonInterfacesTests
{
    public class GeometryTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestWithMultipleFigures(Figure figure, double expected)
        {
            var result = CommonGeometry.GetFigureArea(figure);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]{ new Circle(1), Math.PI},
                new object[]{ new Circle(2), Math.PI * 4},
                new object[]{ new Triangle(3, 4, 5), 6},
                new object[]{ new Triangle(10, 12, 10), 48},
            };
    }
}
