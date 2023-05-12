using Microsoft.Extensions.DependencyInjection;

//普通注册方式
/*
ServiceCollection services = new ServiceCollection();
services.AddTransient<TestServiceImpl>();
using (ServiceProvider sp = services.BuildServiceProvider())
{
    TestServiceImpl testService = sp.GetRequiredService<TestServiceImpl>();
    testService.Name = "tom";
    testService.SayHi();
}*/
ServiceCollection services = new ServiceCollection();
services.AddTransient<TestServiceImpl>();
//services.AddScoped<TestServiceImpl>();
//services.AddSingleton<TestServiceImpl>();
using (ServiceProvider sp = services.BuildServiceProvider())
{
    TestServiceImpl ts1;
    TestServiceImpl ts2;
    TestServiceImpl ts3;
    TestServiceImpl ts4;
    using (IServiceScope serviceScope = sp.CreateScope())
    {
        ts1 = serviceScope.ServiceProvider.GetRequiredService<TestServiceImpl>();
    }
    using (IServiceScope serviceScope = sp.CreateScope())
    {
        ts2 = serviceScope.ServiceProvider.GetRequiredService<TestServiceImpl>();
    }
    using (IServiceScope serviceScope = sp.CreateScope())
    {
        ts3 = sp.GetRequiredService<TestServiceImpl>();
    }
    using (IServiceScope serviceScope = sp.CreateScope())
    {
        ts4 = sp.GetRequiredService<TestServiceImpl>();
    }
    Console.WriteLine(object.ReferenceEquals(ts1, ts2));
    Console.WriteLine(object.ReferenceEquals(ts3, ts4));
}