using System.IO;
using System;
using Jint;

namespace JintTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var exp="CEILING($buyitnowprice*1.05)";


            var js= File.ReadAllText(@"E:\MyWork\CodeSnippet\CodeSnippet\C#\JintTest\Ca.js");
            var add = new Engine(options => { options.Strict(false); })
            .SetValue("$buyitnowprice","54.99")
            .Execute(js)
            .Execute($"function getData(){{ return {exp}}}")
            .GetValue("getData");
            var data= add.Invoke().ToString(); // -> 3
            Console.WriteLine(data);
        }
    }
}
