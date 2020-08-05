using System.IO;
using System;
using Jint;

namespace JintTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var exp="IFBLANK($discountprice,CEILING($buyitnow*1.55)+0.99)";


            var js= File.ReadAllText(@"E:\MyWork\CodeSnippet\CodeSnippet\C#\JintTest\Ca.js");
            var add = new Engine()
            .SetValue("$buyitnow","189.99")
            .SetValue("$discountprice","")
            .Execute(js)
            .Execute($"function getData(){{ return {exp}}}")
            .GetValue("getData");
            var data= add.Invoke(); // -> 3
            Console.WriteLine(data);
        }
    }
}
