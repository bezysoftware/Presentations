namespace Barclays.UberCalculator
{
    using Barclays.UberCalculator.Calculators;
    using Barclays.UberCalculator.Interception;
    using Barclays.UberCalculator.IO;
    using Barclays.UberCalculator.Logging;
    using Barclays.UberCalculator.Magics;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;

    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();

            container
                .RegisterType<ICalculator, Calculator>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>(), /*new InterceptionBehavior<AuthorizationInterceptionBehavior>(),*/ new InterceptionBehavior<RetryingInterceptionBehavior>())
                //.RegisterType<IMagic, MagicNotOk>()
                .RegisterType<IMagic, Magic>()
                .RegisterType<ILog, ConsoleLog>()
                .RegisterType<IOutputWritter, ConsoleReaderWriter>()
                .RegisterType<IInputReader, ConsoleReaderWriter>();

            container.Resolve<CalculatorGui>().Run();
        }
    }
}
