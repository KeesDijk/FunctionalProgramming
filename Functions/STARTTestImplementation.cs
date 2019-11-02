using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Functions.Base;
using Functions.Helpers;
using Functions.Interfaces;

namespace Functions
{
    public class STARTTestImplementation : TestImplementationBase, ITestImplementation
    {
        public int IndexOfAny(string searchString, char[] charsToFind)
        {
            var result = -1;
            var indexedSearchString = Enumerable.Range(0, searchString.Length)
                .Zip(searchString.ToArray(), (index,c) => new {index,c} );
            foreach (var indexpair in indexedSearchString)
            {
                if (charsToFind.Contains(indexpair.c))
                {
                    result = indexpair.index;
                    break;
                }
            }

            return result;
        }

        public List<int> DeclarativeVsImperative(List<int> collection)
        {
            List<int> results = new List<int>();
            foreach (var num in collection)
            {
                if (num % 2 != 0)
                    results.Add(num);
            }
            return results;
        }

        public void FunctionsAsVariablesOne(int a)
        {
            try
            {
                Log(string.Format("Starting processing with : {0}", a));
                DoComplicatedProcessing(a);
                Log("Done processing");
            }
            catch (ArgumentException ea)
            {
                var msg = "Illigal Argument" + ea.Message;
                Log(msg, ea);
                throw;
            }
            catch (Exception e)
            {
                var msg = "Unknown exception" + e.Message;
                Log(msg, e);
                throw;
            }
        }

        public TestHelper FunctionsAsVariablesTwo(int nrOfUniqueItems)
        {
            var result = new TestHelper();

            //Fill list1
            var i = 0;
            var endlessLoopGuard = 0;
            while (i < nrOfUniqueItems && endlessLoopGuard < 10) {
                var nextList1Item = GetNextList1Item();
                if (!result.List1.Contains(nextList1Item))
                {
                    i++;
                    endlessLoopGuard = 0;
                    result.List1.Add(nextList1Item);
                }
                else
                {
                    endlessLoopGuard++;
                }
            }

            //Fill list2
            i = 0;
            endlessLoopGuard = 0;
            while (i < nrOfUniqueItems && endlessLoopGuard < 10)
            {
                var nextList2Item = GetNextList2Item();
                if (!result.List2.Contains(nextList2Item))
                {
                    i++;
                    endlessLoopGuard = 0;
                    result.List2.Add(nextList2Item);
                }
                else
                {
                    endlessLoopGuard++;
                }
            }

            //Fill list3
            i = 0;
            endlessLoopGuard = 0;
            while (i < nrOfUniqueItems && endlessLoopGuard < 10)
            {
                var nextList3Item = GetNextList3Item();
                if (!result.List3.Contains(nextList3Item))
                {
                    i++;
                    endlessLoopGuard = 0;
                    result.List3.Add(nextList3Item);
                }
                else
                {
                    endlessLoopGuard++;
                }
            }

            return result;
        }

        public IEnumerable<int> SimpleSelectFunction(List<int> input)
        {
            var result = new List<int>();

            foreach (var i in input)
            {
                if (i > 10)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public IEnumerable<int> SlightlyLessSimpleSelectFunction(List<int> input, Func<int, bool> predicate)
        {
            var result = new List<int>();

            foreach (var i in input)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public IEnumerable<int> SimpleMapFunction(List<int> input)
        {
            var result = new List<int>();

            foreach (var i in input)
            {
                result.Add(i * 2);
            }
            return result;
        }

        public IEnumerable<int> SlightlyLessSimpleMapFunction(List<int> input, Func<int, int> converterFunc )
        {
            var result = new List<int>();

            foreach (var i in input)
            {
                result.Add(converterFunc(i));
            }
            return result;
        }

        public int SimpleReduceFunction(List<int> input)
        {
            int result = 0;

            foreach (var i in input)
            {
                result += i;
            }
            return result;
        }

        public int SlightlyLessSimpleReduceFunction(List<int> input,int seed, Func<int, int, int> aggregateFunc)
        {
            int result = seed;

            foreach (var i in input)
            {
                result = aggregateFunc(result, i);
            }
            return result;
        }

        public List<int> FirstFiveIndexesOfFarInFarFarAway(List<string> text)
        {
            var result = new List<int>();
            var countSoFar = 0;
            var index = 0;
            foreach (var word in text)
            {
                if (word.Equals("Far", StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(index);
                    countSoFar++;
                }
                if (countSoFar >= 5)
                {
                    break;
                }
                index++;
            }
            return result;
        }

        public int CallCounterNrOfTimes(int times)
        {
            int result = 0;
            var closureHelper = new ClosureHelper();
            for (int i = 0; i < times; i++)
            {
                var counterFunc = closureHelper.GetCounter();
                result = counterFunc();
            }
            return result;
        }

        public BigInteger Factorial(int x)
        {
            BigInteger result = 1;
            for (int i = x; i >= 2; i--)
            {
                result *= i;
            }
            return result;
        }

        public BigInteger FactorialTail(int x, BigInteger product)
        {
            BigInteger result = 1;
            for (int i = x; i >= 2; i--)
            {
                result *= i;
            }
            return result;
        }

        public BigInteger FactorialTrampoline(int x)
        {
            BigInteger result = 1;
            for (int i = x; i >= 2; i--)
            {
                result *= i;
            }
            return result;
        }

        public int Fibonaci(int input, int times = 1)
        {
            Func<int, int> fib = null;
            fib = n => n > 1 ? fib(n - 1) + fib(n - 2) : n;
            int fibonaci = 0;
            for (int i = 0; i < times; i++)
            {
                fibonaci = fib.Invoke(input);
            }
            return fibonaci;
        }
    }
}
