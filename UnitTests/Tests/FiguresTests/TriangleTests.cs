using Geometry.Models;
using Xunit;

namespace Tests.Tests.FiguresTests
{
    public class TriangleTests
    {
        [Fact]
        public void InitializationTests()
        {
            Assert.True(new Triangle(1, 1, 1) is Triangle);
            Assert.True(new Triangle(new double[] { 1, 1, 1 }) is Triangle);
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 1, 1 }));
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 1, 1, 1, 1 }));
            Assert.Throws<ArgumentException>(() => new Triangle(0, 1, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(1, -1, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 3));
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(10, 12, 10, 48)]
        public void GetAreaTests(double sideA, double sideB, double sideC, double expected)
        {
            var result = new Triangle(sideA, sideB, sideC).Area;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(10, 12, 10, false)]
        public void IsRightTriangleTests(double sideA, double sideB, double sideC, bool expected)
        {
            var result = new Triangle(sideA, sideB, sideC).IsRightTriangle;
            Assert.Equal(expected, result);
        }
    }
}
