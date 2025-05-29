using System;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;

public class Lab2_Versia1
{
    public void No_Async()
    {
        var Time = Stopwatch.StartNew();
        string[] htp = 
        {
            "https://gamazavr.ru/search/?query=eve+online",
            "https://lolkek/cheburek.ru/",
        };

        using (var client = new HttpClient())
        {
            try
            {
                foreach (var x in htp)
                {
                    var q = client.Send(new HttpRequestMessage(HttpMethod.Get, x));

                    if (!q.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: HTTP {q.StatusCode} | URL: {x}");
                        return;
                    }

                    var json = q.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Console.WriteLine($"The result of {x}:\n{json}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Critical error: {ex.Message}");
            }
            finally
            {
                Time.Stop();
                Console.WriteLine($"No Async Time: {Time.Elapsed}\n");
            }
        }
    }
}