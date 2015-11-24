namespace Barclays.UberCalculator.Interception
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Practices.Unity.InterceptionExtension;

    public class RetryingInterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var result = getNext()(input, getNext);

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get
            {
                return true;
            }
        }
    }
}
