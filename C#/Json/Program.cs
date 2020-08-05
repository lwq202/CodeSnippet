using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Json
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string,string> dirs=new Dictionary<string, string>();
            var str= dirs["sfd"];
            string json= await File.ReadAllTextAsync("test.json");
            var model= json.ToObject<ResponseGetOperations>();
            var errors= model.Operations.First().Errors.Specific;
            if (errors is JObject jErrors)
            {
                foreach (var prop in jErrors.Properties())
                {
                    Console.WriteLine($"key:{prop.Name}\r\nValue:{prop.Value.ToString()}");
                }
                
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
