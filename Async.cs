using System;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;

public class Lab2_Versia2
{
    public async Task Async()
    {
        var Time = Stopwatch.StartNew();
        string[] htp =
        {
            "https://gamazavr.ru/search/?query=eve+online",
            "https://lolkek/cheburek.ru/"
        };

        using (var client = new HttpClient())
        {
            try
            {
                var tasks = htp.Select(x => client.GetAsync(x)).ToArray();
                var qs = await Task.WhenAll(tasks);

                foreach (var q in qs)
                {
                    if (!q.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: HTTP {q.StatusCode} | URL: {q.RequestMessage.RequestUri}");
                        return;
                    }
                }

                foreach (var q in qs)
                {
                    var json = await q.Content.ReadAsStringAsync();
                    Console.WriteLine($"The result of {q.RequestMessage.RequestUri}:\n{json}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Critical error: {ex.Message}");
            }
            finally
            {
                Time.Stop();
                Console.WriteLine($"Async Time: {Time.Elapsed}\n");
            }
        }
    }
}