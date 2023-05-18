using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();
//一般放在普通json文件之前，仅开发环境使用
configBuilder.AddUserSecrets<Program>();

configBuilder.AddJsonFile("appsettings.json")
    .AddEnvironmentVariables("Test1_").AddCommandLine(args);
IConfigurationRoot config = configBuilder.Build();
string server = config["Server"];
string userName = config["UserName"];
string password = config["Password"];
string port = config["Port"];
//Console.WriteLine($"server={server},port={port}");
//Console.WriteLine($"userName={userName},password={password}");
Console.WriteLine(config.GetDebugView());