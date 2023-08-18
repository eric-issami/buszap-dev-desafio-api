using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;

namespace RickAndMortyConnector.Miscellaneous
{
    public class RestfulApi : IDisposable
    {

        public object Get(string url)
        {
            try
            {

                HttpClient client = new HttpClient();
                string result = "";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result.ToString();
                    ///TODO: remover ao final
                    //Console.WriteLine("{0}", result);

                }
                else
                {
                    Console.WriteLine("StatusCode: {0} /r/nMessage: {1}", (int)response.StatusCode, response.ReasonPhrase);
                }

                client.Dispose();


                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Dispose()
        {
        }
    }
}

