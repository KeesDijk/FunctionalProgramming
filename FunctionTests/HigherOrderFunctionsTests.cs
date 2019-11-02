using System.Collections.Generic;
using FluentAssertions;
using InfraStrcuture;
using Xunit;
using Xunit.Abstractions;

namespace FunctionTests
{
    public class HigherOrderFunctionsTests : TestBase
    {
        [Fact]
        public void SimpleSelectTest()
        {
            //arrange
            var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var expected = new List<int> { 11, 12, 13, 14, 15 };

            //act
            var result = Impl.SimpleSelectFunction(input);
            InnerOutputWriter.WriteLine("Result = {{{0}}}", string.Join(";", result));

            //Assert
            result.Should().BeEquivalentTo(expected, "We expect all numbers above 10 to be selected");
            InnerOutputWriter.WriteLine("Succes !");
        }

        [Fact]
        public void SlightlyLessSimpleSelectFunctionTest()
        {
            //arrange
            var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //act
            var result = Impl.SlightlyLessSimpleSelectFunction(input, i => i < 10);
            InnerOutputWriter.WriteLine("Result = {{{0}}}", string.Join(";", result));

            //Assert
            result.Should().BeEquivalentTo(expected, "We expect all numbers above 10 to be selected");
            InnerOutputWriter.WriteLine("Succes !");
        }

        [Fact]
        public void SimpleMapTest()
        {
            //arrange
            var input = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int> { 2, 4, 6, 8, 10 };

            //act
            var result = Impl.SimpleMapFunction(input);
            InnerOutputWriter.WriteLine("Result = {{{0}}}", string.Join(";", result));

            //Assert
            result.Should().BeEquivalentTo(expected, "We expect all numbers to be multiplied by 2");
            InnerOutputWriter.WriteLine("Succes !");
        }

        [Fact]
        public void SlightlyLessSimpleMapFunctionTest()
        {
            //arrange
            var input = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int> { 3, 5, 7, 9, 11 };

            //act
            var result = Impl.SlightlyLessSimpleMapFunction(input, i => i * 2 + 1);
            InnerOutputWriter.WriteLine("Result = {{{0}}}", string.Join(";", result));

            //Assert
            result.Should().BeEquivalentTo(expected, "We expect all numbers to be multiplied by 2 plus one");
            InnerOutputWriter.WriteLine("Succes !");
        }

        [Fact]
        public void SimpleReduceTest()
        {
            //arrange
            var input = new List<int> { 1, 2, 3, 4, 5 };
            var expected = 15;

            //act
            var result = Impl.SimpleReduceFunction(input);
            InnerOutputWriter.WriteLine("Result = {0}", result);

            //Assert
            result.Should().Be(expected, "We expect the result to be the sum of all numbers");
            InnerOutputWriter.WriteLine("Succes !");
        }

        [Fact]
        public void SlightlyLessSimpleReduceFunctionTest()
        {
            //arrange
            var input = new List<int> { 1, 2, 3, 4, 5 };
            var seed = 1;
            var expected = 120;

            //act
            var result = Impl.SlightlyLessSimpleReduceFunction(input, seed, (r, i) => r * i);
            InnerOutputWriter.WriteLine("Result = {0}", result);

            //Assert
            result.Should().Be(expected, "We expect the result to be the mutiplication result of all numbers");
            InnerOutputWriter.WriteLine("Succes !");
        }

        [Fact]
        public void ShouldBeAbleToGetTheFirstFiveIndexesOfFar()
        {
            //arrange
            var text = SampleText.FarFarAwayWords;
            var expected = new List<int> {0, 1, 7, 103, 316};

            // act
            var result = Impl.FirstFiveIndexesOfFarInFarFarAway(text);
            InnerOutputWriter.WriteLine("Result = {{{0}}}", string.Join(";", result));

            //Assert
            result.ShouldBeEquivalentTo(expected, "First Five indexes should be as expected");
            InnerOutputWriter.WriteLine("Succes !");
        }

        public HigherOrderFunctionsTests(ITestOutputHelper innerOutputWriter) : base(innerOutputWriter)
        {
        }
    }
}