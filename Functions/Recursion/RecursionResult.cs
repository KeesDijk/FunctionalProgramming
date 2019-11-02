using System;

namespace Functions.Recursion
{
    public class RecursionResult<T>
    {
        private readonly bool _isFinalResult;
        private readonly T _result;
        private readonly Func<RecursionResult<T>> _nextStep;
        internal RecursionResult(bool isFinalResult, T result, Func<RecursionResult<T>> nextStep)
        {
            _isFinalResult = isFinalResult;
            _result = result;
            _nextStep = nextStep;
        }

        public bool IsFinalResult { get { return _isFinalResult; } }
        public T Result { get { return _result; } }
        public Func<RecursionResult<T>> NextStep { get { return _nextStep; } }
    }
}