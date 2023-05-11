// See https://aka.ms/new-console-template for more information

foreach (var item in Test1())
{
    Console.WriteLine(item);
}
foreach (var item in Test2())
{
    Console.WriteLine(item);
}
await foreach (var item in Test3())
{
    Console.WriteLine(item);
}

static IEnumerable<int> Test1()
{
    var list = new List<int>();
    list.Add(1);
    list.Add(2);
    list.Add(3);
    return list;
}

static IEnumerable<int> Test2()
{
    yield return 0;
    yield return 1;
    yield return 2;
    yield return 3;
}

static async IAsyncEnumerable<int> Test3()
{
    yield return await GetHtmlCount("https://www.baidu.com");
    yield return await GetHtmlCount("https://www.bing.com");
    yield return await GetHtmlCount("https://www.msn.com");
}

static async Task<int> GetHtmlCount(string url)
{
    using var httpClient = new HttpClient();
    var html = await httpClient.GetStringAsync(url);
    return html.Length;
}
