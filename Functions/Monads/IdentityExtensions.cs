using System;

namespace Functions.Monads
{
    public static class IdentityExtensions
    {
        public static Identity<B> Bind<A, B>(this Identity<A> a, Func<A, Identity<B>> func)
        {
            return func(a.Value);
        }

        public static Identity<T> ToIdentity<T>(this T value)
        {
            return new Identity<T>(value);
        }

        public static Identity<T> SelectMany<A, B, T>(this Identity<A> a, Func<A, Identity<B>> func, Func<A, B, T> select)
        {
            return select(a.Value, func(a.Value).Value).ToIdentity();
        }
    }
}