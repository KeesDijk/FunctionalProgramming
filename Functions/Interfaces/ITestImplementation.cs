using System;
using System.Collections.Generic;
using System.Numerics;
using Functions.Helpers;

namespace Functions.Interfaces
{
    public interface ITestImplementation
    {
        int IndexOfAny(string searchString, char[] charsToFind);
        List<int> DeclarativeVsImperative(List<int> collection);
        void FunctionsAsVariablesOne(int a);
        TestHelper FunctionsAsVariablesTwo(int nrOfUniqueItems);
        IEnumerable<int> SimpleSelectFunction(List<int> input);
        IEnumerable<int> SlightlyLessSimpleSelectFunction(List<int> input, Func<int, bool> predicate);
        IEnumerable<int> SimpleMapFunction(List<int> input);
        IEnumerable<int> SlightlyLessSimpleMapFunction(List<int> input, Func<int, int> converterFunc );
        int SimpleReduceFunction(List<int> input);
        int SlightlyLessSimpleReduceFunction(List<int> input,int seed, Func<int, int, int> aggregateFunc);
        List<int> FirstFiveIndexesOfFarInFarFarAway(List<string> text);
        int CallCounterNrOfTimes(int times);
        BigInteger Factorial(int x);
        BigInteger FactorialTail(int x, BigInteger product);
        BigInteger FactorialTrampoline(int x);
        int Fibonaci(int input, int times = 1);
    }
}