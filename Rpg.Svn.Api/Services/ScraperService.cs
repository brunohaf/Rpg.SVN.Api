using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Rpg.Svn.Api.Interfaces;

namespace Rpg.Svn.Api.Services
{
    public class ScraperService : IScraperService
    {
        public void Test(string login, string senha)
        {
            var _cookieContainer = new CookieContainer();

            var request = (HttpWebRequest)HttpWebRequest.Create("https://app.roll20.net/sessions/new/");
            request.CookieContainer = _cookieContainer;
            //set the user agent and accept header values, to simulate a real web browser
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";


            //SET AUTOMATIC DECOMPRESSION
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            Console.WriteLine("FIRST RESPONSE");
            Console.WriteLine();
            using (WebResponse response = request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }

            request = (HttpWebRequest)HttpWebRequest.Create("https://roll20.net/");
            //set the cookie container object
            request.CookieContainer = _cookieContainer;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

            //set method POST and content type application/x-www-form-urlencoded
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //SET AUTOMATIC DECOMPRESSIONa
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            //insert your username and password
            string data = string.Format("username={0}&password={1}", login, senha);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);

            request.ContentLength = bytes.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Close();
            }

            Console.WriteLine("LOGIN RESPONSE");
            Console.WriteLine();
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}
