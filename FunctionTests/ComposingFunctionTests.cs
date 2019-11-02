using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using FluentAssertions;
using Functions.CurryAndPartial;
using Functions.Monads;
using Xunit;
using Xunit.Abstractions;

namespace FunctionTests
{
    public class ComposingFunctionTests : TestBase
    {
        public ComposingFunctionTests(ITestOutputHelper innerOutputWriter) : base(innerOutputWriter)
        {
        }


        [Fact]
        public void SimpleFunctionalComposition()
        {
            //arrange
            int expected = 2*5 + 2;
            Func<int, int> add2 = x => x + 2;
            Func<int, int> mult2 = x => x * 2;

            Func<int, int> add2Mult2 = x => add2(mult2(x));

            //act
            var result = add2Mult2(5);
            InnerOutputWriter.WriteLine("expected = {0} , result = {1}", expected, result);

            //assert
            result.Should().Be(expected);
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void PartialApplicationComposition()
        {
            //arrange
            int expected = 2 * 5 + 2;
            Func<int, int, int> add = (x,y) => x + y;
            Func<int, int, int> mult = (x,y) => x * y;

            Func<int, int> add2 = x => add(x,2);
            Func<int, int> mult2 = x => mult(x, 2);
            
            //act
            var result = add2(mult2(5));
            InnerOutputWriter.WriteLine("expected = {0} , result = {1}", expected, result);

            //assert
            result.Should().Be(expected);
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void CurryComposition()
        {
            //arrange
            int expected = 2 * 5 + 2;
            Func<int, int, int> add = (x, y) => x + y;
            Func<int, int, int> mult = (x, y) => x * y;

            Func<int, Func<int, int>> curriedAdd = add.Curry();
            Func<int, Func<int, int>> curriedMultiply = mult.Curry();

            Func<int, int> add2 = curriedAdd(2);
            Func<int, int> mult2 = curriedMultiply(2);

            //act
            var result = add2(mult2(5)); 
            InnerOutputWriter.WriteLine("expected = {0} , result = {1}", expected, result);

            //assert
            result.Should().Be(expected);
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void CurryComposition2()
        {
            //arrange
            int expected = 10;
            Func<int, int, int, int, int> addFourThings = (a, b, c, d) => a + b + c + d;

            var curriedAddFourThings = addFourThings.Curry();
            
            var addOne = curriedAddFourThings(1);
            var addOneAndTwo = addOne(2);
            var addOneAndTwoAndThree = addOneAndTwo(3);

            //act
            int result1 = curriedAddFourThings(1)(2)(3)(4);
            int result2 = addOneAndTwoAndThree(4); 

            InnerOutputWriter.WriteLine("expected = {0} , result1 = {1}, result2 = {2}", expected, result1, result2);

            //assert
            result1.Should().Be(expected);
            result2.Should().Be(expected);
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void MonadComposition()
        {
            //arrange
            var expected = "Hello World!, 7, 11-01-2010";

            //act
            var result =
                 "Hello World!".ToIdentity()
                    .Bind(hello => 7.ToIdentity()
                        .Bind(number => (new DateTime(2010, 1, 11)).ToIdentity()
                            .Bind(date => string.Format("{0}, {1}, {2:dd-MM-yyyy}", hello, number, date).ToIdentity())));

            InnerOutputWriter.WriteLine("result = {0}", result.Value);

            //assert
            result.Value.Should().Be(expected);
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void MonadComposition2()
        {
            //arrange
            var expected = "Hello World!, 7, 11-01-2010";
            
            //act
            var result =
                from hello in "Hello World!".ToIdentity()
                from number in 7.ToIdentity()
                from date in (new DateTime(2010, 1, 11)).ToIdentity()
                select string.Format("{0}, {1}, {2:dd-MM-yyyy}", hello, number, date);
            
            InnerOutputWriter.WriteLine("result = {0}", result.Value);

            //assert
            result.Value.Should().Be(expected);
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void MaybeMonadTest1()
        {
            //Arrange
            Person person = new Person();
            string expected = "PostalCodeIsEmpty";

            //Act
            var result = person.ToMaybe()
                .With(x => x.Adress)
                .Return(x => x.PostalCode, "PostalCodeIsEmpty");

            InnerOutputWriter.WriteLine("result = {0}", result);

            //Assert
            result.Should().Be(expected, "For an empty postalcode we expect the result to be the default value");
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void MaybeMonadTest2()
        {
            //Arrange
            string expected = "Blah22";
            Person person = new Person {Adress = new Address { PostalCode = expected}};
            
            //Act
            var result = person.ToMaybe()
                .With(x => x.Adress)
                .Return(x => x.PostalCode, "PostalCodeIsEmpty");

            InnerOutputWriter.WriteLine("result = {0}", result);

            //Assert
            result.Should().Be(expected, "When the postalcode not is null we expect the result to be the postalcode");
            InnerOutputWriter.WriteLine("succes");
        }

        [Fact]
        public void MaybeMonadTest3()
        {
            //Arrange
            string expected = "PostalCodeIsEmpty";
            Person person = new Person { Adress = new Address { PostalCode = "Blah22" }, Name  = "NameLongerThanFour"};

            //Act
            var result = person.ToMaybe()
                .Where(x => x.Name.Length < 4)
                .With(x => x.Adress)
                .Return(x => x.PostalCode, "PostalCodeIsEmpty");

            InnerOutputWriter.WriteLine("result = {0}", result);

            //Assert
            result.Should().Be(expected, "For a person with a name longer than four characters we expect the postalcode to be the default value");
            InnerOutputWriter.WriteLine("succes");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public Address Adress { get; set; }
    }

    public class Address
    {
        public string PostalCode { get; set; }
    }
}