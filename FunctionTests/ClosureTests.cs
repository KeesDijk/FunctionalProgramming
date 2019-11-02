using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace FunctionTests
{
    public class ClosureTests : TestBase
    {
        [Fact]
        public void CallingCounterShouldResultInExpectedNumber()
        {
            //arrange
            int times = 10;
            int expected = 9;

            //act
            var result = Impl.CallCounterNrOfTimes(times);
            InnerOutputWriter.WriteLine("Result: {0}", result);

            result.Should().Be(expected, " Calling Counter Should Result In Expected Number ");
            InnerOutputWriter.WriteLine("Succes");
        }
        public ClosureTests(ITestOutputHelper innerOutputWriter) : base(innerOutputWriter)
        {
        }
    }
}