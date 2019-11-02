using System;

namespace Functions.Monads
{
    public class Maybe<T>
    {
        public static readonly Maybe<T> Nothing = new Maybe<T>(default(T));

        public Maybe(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }

        public bool HasValue
        {
            get { return Value != null && !Value.Equals(default(T)); }
        }
    }

    public static class Maybe
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<TResult> With<TInput, TResult>(this Maybe<TInput> maybe, Func<TInput, TResult> func)
        {
            return maybe.HasValue ? new Maybe<TResult>(func(maybe.Value)) : Maybe<TResult>.Nothing;
        }

        public static Maybe<TInput> Where<TInput>(this Maybe<TInput> maybe, Func<TInput, bool> func)
        {
            return (maybe.HasValue && func(maybe.Value)) ? maybe : Maybe<TInput>.Nothing;
        }

        public static TResult Return<TInput, TResult>(this Maybe<TInput> maybe, Func<TInput, TResult> func, TResult defaultValue)
        {
            return maybe.HasValue ? func(maybe.Value) : defaultValue;
        }

        public static TResult FirstOrDefault<TInput, TResult>(this Maybe<TInput> maybe, Func<TInput, TResult> func, TResult defaultValue)
        {
            return maybe.HasValue ? func(maybe.Value) : defaultValue;
        }


        public static Maybe<TInput> SelectMany<TResult, TInput>(this Maybe<TResult> maybe, Func<TResult, Maybe<TInput>> func)
        {
            return maybe.HasValue ? func(maybe.Value) : Maybe<TInput>.Nothing;
        }

        public static Maybe<TInput> SelectMany<T, U, TInput>(this Maybe<T> maybe, Func<T, Maybe<U>> mayBeFunc, Func<T, U, TInput> func)
        {
            Maybe<TInput> result;
            if (!maybe.HasValue)
            {
                result = Maybe<TInput>.Nothing;
            }
            else
            {
                Maybe<U> u = mayBeFunc(maybe.Value);
                result = u.HasValue ? func(maybe.Value, u.Value).ToMaybe() : Maybe<TInput>.Nothing;
            }
            
            return result;
        }

        public static Maybe<TInput> Select<TInput, T>(this Maybe<T> mayBe, Func<T, TInput> func)
        {
            return mayBe.HasValue ? func(mayBe.Value).ToMaybe() : Maybe<TInput>.Nothing;
        }


    }
}