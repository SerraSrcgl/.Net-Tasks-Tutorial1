using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Task4
{
    // isteğin yapılması
    //ve gelen sonucun işlenmesi
    //hep asenkron olarak gerçekleştirilmekte. Bu sayede
    //kullanıcı arayüzü donmadan sunucu ile iletişim kurmak mümkün olmakta.
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            int counter = 0;
            if (args.Length == 0)
            {
                throw new ArgumentNullException();
            }
                var url = args[0];

                try
                {
                    var httpClient = new HttpClient(); 
                    var response = await httpClient.GetAsync(url); 

                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var content = await response.Content.ReadAsStringAsync();

                    MatchCollection matches = regex.Matches(content);

                    foreach (var match in matches)
                    {
                        counter += 1;
                        Console.WriteLine(match.ToString());
                    }
                    if (counter == 0)
                    {
                        Console.WriteLine("No email addresses found");
                    }
                    httpClient.Dispose();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while downloading the page");
                }




            }
        }
    }


  