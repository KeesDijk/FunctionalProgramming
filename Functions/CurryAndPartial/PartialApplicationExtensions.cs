using System;

namespace Functions.CurryAndPartial
{
    public static class PartialApplicationExtensions
    {
        public static Func<B, R> Partial<A, B, R>(this Func<A, B, R> f, A a)
        {
            return b => f(a, b);
        }
    }
}