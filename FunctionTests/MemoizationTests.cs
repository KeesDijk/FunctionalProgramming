using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace FunctionTests
{
    public class MemoizationTests : TestBase
    {
        [Fact]
        public void FibonacciTest()
        {
            //Arrange
            var input = 8;
            var expected = 21;

            //Act
            var result = Impl.Fibonaci(input);
            InnerOutputWriter.WriteLine("Result: {0}", result);

            result.Should().Be(expected, " Calling Fibbonaci Should Result In Expected Number ");
            InnerOutputWriter.WriteLine("Succes");
        }

        [Fact]
        public void TimedFibonacciTest()
        {
            //Arrange
            var input = 45;
            var expected = 1134903170;
            var timer = new Stopwatch();

            //Act
            timer.Start();
            var result = Impl.Fibonaci(input, 1);
            timer.Stop();
            InnerOutputWriter.WriteLine("Result: {0} in {1}", result, timer.ElapsedMilliseconds);

            result.Should().Be(expected, " Calling Fibbonaci Should Result In Expected Number ");
            InnerOutputWriter.WriteLine("Succes");
        }

        public MemoizationTests(ITestOutputHelper innerOutputWriter) : base(innerOutputWriter)
        {
        }
    }
}