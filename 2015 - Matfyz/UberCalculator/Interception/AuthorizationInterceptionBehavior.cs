namespace Barclays.UberCalculator.Interception
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Practices.Unity.InterceptionExtension;

    public class AuthorizationInterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            if (!this.IsValidUser())
            {
                return input.CreateExceptionMethodReturn(new UnauthorizedAccessException("..."));
            }

            return getNext()(input, getNext);
        }

        private bool IsValidUser()
        {
            return false;
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
