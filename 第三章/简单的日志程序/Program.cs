using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Serilog;
using 简单的日志程序;

ServiceCollection services = new ServiceCollection();
services.AddLogging(logBuilder =>
{
    //logBuilder.ClearProviders();
    //logBuilder.AddConsole();
    //logBuilder.SetMinimumLevel(LogLevel.Trace);

    //logBuilder.AddNLog();
    var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
    logBuilder.AddSerilog(logger);
});
services.AddScoped<Test1>();
using (var sp = services.BuildServiceProvider())
{
    var logger = sp.GetRequiredService<ILogger<Program>>();
    logger.LogWarning("这是一条警告消息");
    logger.LogError("这是一条错误消息");
    string age = "abc";
    logger.LogInformation("用户输入的年龄：{0}", age);
    try
    {
        int i = int.Parse(age);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "解析字符串为int失败");
    }

    Test1 test1 = sp.GetRequiredService<Test1>();
    test1.Test();
}
