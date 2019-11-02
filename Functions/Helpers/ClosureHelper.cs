using System;

namespace Functions.Helpers
{
    public class ClosureHelper
    {
        private int localVariable;

        public Func<int> GetCounter()
        {
            Func<int> resultFunction = () =>
            {
                return localVariable++;
            };
            return resultFunction;
        }

        public ClosureHelper()
        {
            localVariable = 0;
        }
    }
}