using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace FunctionTests
{
    public class IntroductionTests : TestBase
    {
        public IntroductionTests(ITestOutputHelper innerOutputWriter) : base(innerOutputWriter)
        {
        }


        [Fact]
        public void SimpleFunctionalComposition()
        {
            //arrange
            int result = -1;
            int expected = 2;
            var searchString = "zzabyycdxx";
            var charsToFind = new char[] { 'a'};

            //act
            result = Impl.IndexOfAny(searchString, charsToFind);
            
            //assert
            result.Should().Be(expected);
        }

        [Fact]
        public void DeclarativeVsImperativeShouldFilterOutOdds()
        {
            //arrange
            var input = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int> {1,3,5};
            //act

            var result = Impl.DeclarativeVsImperative(input);
            InnerOutputWriter.WriteLine("Result = {{{0}}}", string.Join(";",result));

            //assert
            result.Should().BeEquivalentTo(expected, "We expect the even numbers to be filtered out");
            InnerOutputWriter.WriteLine("Succes !");
        }

        [Fact]
        public void TestHelperShouldBeFilledWithThreeListsWithUniqueItems()
        {
            //arrange
            var nrOfUniqueItems = 5;

            //act
            var result = Impl.FunctionsAsVariablesTwo(nrOfUniqueItems);

            //assert
            AssertList(result.List1, nrOfUniqueItems);
            AssertList(result.List2, nrOfUniqueItems);
            AssertList(result.List3, nrOfUniqueItems);
           
            InnerOutputWriter.WriteLine("Succes !");
        }

        private void AssertList(List<string> values, int nrOfUniqueItems)
        {
            InnerOutputWriter.WriteLine("Result = {{{0}}}", string.Join(";", values));
            values.Should()
                .HaveCount(nrOfUniqueItems, "We expect the list to contain the specified number of items");
            values.Distinct()
                .Count()
                .Should()
                .Be(values.Count, "We expect the list to contain unique items");
        }
    }
}