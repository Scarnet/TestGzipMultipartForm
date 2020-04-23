using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.Net.Http;

namespace TestGzipMultipartForm
{
    class Program
    {
        static void Main(string[] args)
        {
            var gzipped = new GzipMultipartContent();
            var test = new TestClass();
            gzipped.Add(new StringContent(JsonConvert.SerializeObject(test)), "value");

            jsonContent json = new jsonContent(test);
            var client = new HttpClient();
            var result = client.PostAsync("http://localhost:60001/api/Home/", json).Result;
        }
    }

    public class TestClass
    {
        public string value { get; set; }
    }
}
