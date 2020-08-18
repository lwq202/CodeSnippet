using System.IO;
using System;
using Jint;

namespace JintTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var exp="isExitsFunction('ISBLANK')";


            var js= File.ReadAllText(@"E:\MyWork\CodeSnippet\CodeSnippet\C#\JintTest\Ca.js");
            var add = new Engine()
            .Execute(js)
            .Execute($"function getData(){{ return {exp}}}")
            .GetValue("getData");
            var data= add.Invoke().ToString(); // -> 3
            Console.WriteLine(data);
        }
    }
}
