using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Cw1_APBD
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            
            var client = new HttpClient();
            var result = await client.GetAsync(url);

            if(result.IsSuccessStatusCode) //2xx
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                MatchCollection matches = regex.Matches(html);
                foreach(var m in matches)
                {
                    Console.WriteLine(m);
                }

                //Console.WriteLine(html);

            }

            //JS -> Promise asynce await
            //Java -> Future<T>
            //Task -> async await
        }
    }
}
