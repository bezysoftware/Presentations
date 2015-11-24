namespace Barclays.UberCalculator.Interception
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Barclays.UberCalculator.Logging;

    using Microsoft.Practices.Unity.InterceptionExtension;

    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        private readonly ILog log;

        public LoggingInterceptionBehavior(ILog log)
        {
            this.log = log;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            this.log.Debug("Before call to: {0}.{1}, parameters: {2}",
                    input.Target,
                    input.MethodBase.Name,
                    this.GetParameters(input));

            var result = getNext()(input, getNext);

            if (result.Exception != null)
            {
                this.log.Error("Exception while calling: {0}, parameters: {1}, ex: {2}", 
                    input.MethodBase.Name, 
                    this.GetParameters(input), 
                    result.Exception);
            }
            else
            {
                this.log.Debug("Call finished: {0}, parameters: {1}, result: {2}",
                    input.MethodBase.Name,
                    this.GetParameters(input),
                    result.ReturnValue);
            }

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

        private string GetParameters(IMethodInvocation input)
        {
            return string.Join("\n---------\n", input.MethodBase.GetParameters().Select(parameter => string.Format("\nName: {0}, Value: {1}", parameter.Name, input.Arguments[parameter.Name])));
        }
    }
}
