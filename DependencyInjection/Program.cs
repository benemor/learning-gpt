using Autofac;
using DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<GreetingService>().As<IGreetingService>();
        builder.RegisterType<MyClass>();
        var container = builder.Build();
        var myClass = container.Resolve<MyClass>();
        myClass.DoSomething();
    }
}

public class MyClass
{
    private readonly IGreetingService _greetingService;

    public MyClass(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public void DoSomething()
    {
        _greetingService.Greet("John");
    }
}