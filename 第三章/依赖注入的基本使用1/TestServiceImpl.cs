public class TestServiceImpl : ITestService,IDisposable
{
    public string Name { get; set; }

    public void Dispose()
    {
        Console.WriteLine("TestServiceImpl Dispose......");
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}");
    }
}
