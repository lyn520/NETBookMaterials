Console.WriteLine("1-Main:" + Thread.CurrentThread.ManagedThreadId);
Console.WriteLine(await CalcAsync2(1000));
Console.WriteLine("2-Main:" + Thread.CurrentThread.ManagedThreadId);


static async Task<decimal> CalcAsync1(int n)
{
    Console.WriteLine("CalcAsync:" + Thread.CurrentThread.ManagedThreadId);
    decimal result = 1;
    Random rand = new Random();
    for (int i = 0; i < n * n; i++)
    {
        result = result + (decimal)rand.NextDouble();
    }
    return await Task.FromResult(result);
    //return await Task.Run(() => result);
}

static async Task<decimal> CalcAsync(int n)
{
    Console.WriteLine("CalcAsync:" + Thread.CurrentThread.ManagedThreadId);
    return await Task.Run(() =>
    {
        Console.WriteLine("Task.Run:" + Thread.CurrentThread.ManagedThreadId);
        decimal result = 1;
        Random rand = new Random();
        for (int i = 0; i < n * n; i++)
        {
            result = result + (decimal)rand.NextDouble();
        }
        return result;
    });
}

//不用async关键字，直接返回Task，不需要拿到结果后再封装成Task
static Task<decimal> CalcAsync2(int n)
{
    Console.WriteLine("CalcAsync:" + Thread.CurrentThread.ManagedThreadId);
    return Task.Run(() =>
    {
        Console.WriteLine("Task.Run:" + Thread.CurrentThread.ManagedThreadId);
        decimal result = 1;
        Random rand = new Random();
        for (int i = 0; i < n * n; i++)
        {
            result = result + (decimal)rand.NextDouble();
        }
        return result;
    });
}