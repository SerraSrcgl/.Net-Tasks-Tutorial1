using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Tutorial2
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var url = args[0];
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);
            var content = await response.Content.ReadAsStringAsync();
            var matches = regex.Matches(content);
            foreach (var match in matches)
            {
                Console.WriteLine(match.ToString());
            }

        }
    }
}
