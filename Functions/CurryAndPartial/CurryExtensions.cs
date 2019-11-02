using System;

namespace Functions.CurryAndPartial
{
    public static class CurryExtensions
    {
        public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(this Func<T1, T2, T3> f)
        {
            return a => b => f(a, b);
        }

        public static Func<T1, Func<T2, Func<T3,T4>>> Curry<T1, T2, T3,T4>(this Func<T1, T2, T3, T4> f)
        {
            return a => b => c => f(a, b,c);
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4,T5>>>> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> f)
        {
            return a => b => c => d => f(a, b, c, d);
        }
    }
}