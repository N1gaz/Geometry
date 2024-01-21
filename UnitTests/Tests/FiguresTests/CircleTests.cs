using Geometry.Models;
using Xunit;

namespace Tests.Tests.FiguresTests
{
    public class CircleTests
    {
        [Fact]
        public void InitializationTests()
        {
            Assert.True(new Circle(1) is Circle);
            Assert.Throws<ArgumentException>(() => new Circle(0));
            Assert.Throws<ArgumentException>(() => new Circle(-1));
            Assert.True(new Circle(1.0) is Circle);
            Assert.Throws<ArgumentException>(() => new Circle(0.0));
            Assert.Throws<ArgumentException>(() => new Circle(-1.0));
        }

        [Theory]
        [InlineData(1,Math.PI)]
        [InlineData(2, Math.PI * 4.0)]
        public void GetAreaTests(double radius, double expected) 
        {
            var result = new Circle(radius).Area;
            Assert.Equal(expected, result);
        }
    }
}
