using System;

namespace Functions.Recursion
{
    public static class TailRecursion
    {
        public static T Execute<T>(Func<RecursionResult<T>> func)
        {
            do
            {
                var recursionResult = func();
                if (recursionResult.IsFinalResult)
                    return recursionResult.Result;
                func = recursionResult.NextStep;
            } while (true);
        }

        public static RecursionResult<T> Return<T>(T result)
        {
            return new RecursionResult<T>(true, result, null);
        }

        public static RecursionResult<T> Next<T>(Func<RecursionResult<T>> nextStep)
        {
            return new RecursionResult<T>(false, default(T), nextStep);
        }

    }
}