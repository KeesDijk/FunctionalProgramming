using System;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace FunctionTests
{
    public class RecursionTests : TestBase
    {
        [Fact]
        public void SimpleRecursion()
        {
            //arrange
            var input = 5;
            var expected = 120;

            //act
            var result = Impl.Factorial(input);
            InnerOutputWriter.WriteLine("result = {0}", result);
            
            //Assert
            result.Should().Be(expected, "We expect the factorial to be calculated correctly");
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact(Skip = "Catching the stackoverflow doesn't work as expected")]
        public void ToLargeAFactorialShouldCauseAsStackOverflow()
        {
            //arrange
            var input = 100000;
            
            //act
            Action a = () =>
            {
                var result = Impl.Factorial(input);
                InnerOutputWriter.WriteLine("result = {0}", result);
            };

            //Assert
            a.ShouldThrow<StackOverflowException>("An input that is to large should cause a stackoverflow");
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void TailRecursion()
        {
            //arrange
            var input = 5;
            var expected = 120;

            //act
            var result = Impl.FactorialTail(input, 1);
            InnerOutputWriter.WriteLine("result = {0}", result);

            //Assert
            result.Should().Be(expected, "We expect the factorial to be calculated correctly");
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void TrampolineRecursion1()
        {
            //arrange
            var input = 5;
            var expected = 120;

            //act
            var result = Impl.FactorialTrampoline(input);
            InnerOutputWriter.WriteLine("result = {0}", result);

            //Assert
            result.Should().Be(expected, "We expect the factorial to be calculated correctly");
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void TrampolineRecursion2()
        {
            //arrange
            var input = 10000;

            //act
            Action a = () =>
            {
                var result = Impl.FactorialTrampoline(input);
                InnerOutputWriter.WriteLine("result = {0}", result);
            };

            //Assert
            a.ShouldNotThrow<StackOverflowException>("An input that is large should not cause a stackoverflow");
            InnerOutputWriter.WriteLine("succes");
        }

        
        public RecursionTests(ITestOutputHelper innerOutputWriter) : base(innerOutputWriter)
        {
        }
    }
}