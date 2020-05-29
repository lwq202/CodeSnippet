using System.Linq;
using System.Collections.Generic;
using System;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names=new List<string>();
            names.Add("");
            var nameType= names.GetType();
            
            var method = nameType.GetMethod("get_Item");
            var countProp = nameType.GetProperties()
            .SingleOrDefault(a=>a.Name.Equals("Count"));
            var count= (int)countProp.GetValue(names);
        
            var arg = new object[] { 0 };
            var info =method.Invoke(names, arg);

            Console.WriteLine("Hello World!");
        }

        public class Model{
            public string Name { get; set; }
        }
    }
}
