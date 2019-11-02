using System;
using System.Collections.Generic;

namespace Functions.Memoization
{
    public static class MemoizationExtensions
    {
        public static Func<R> Memoize<R>(this Func<R> f)
        {
            R value = default(R);
            bool hasValue = false;
            return () =>
            {
                if (!hasValue)
                {
                    hasValue = true;
                    value = f();
                }
                return value;
            };
        }

        public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
        {
            var map = new Dictionary<A, R>();
            return a =>
            {
                R value;
                if (map.TryGetValue(a, out value))
                    return value;
                value = f(a);
                map.Add(a, value);
                return value;
            };
        }
    }
}