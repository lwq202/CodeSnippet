using System.Linq;
using System.Collections.Generic;
using System;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试virtual怎么反射出来
            var type= typeof(Model);
            var props= type.GetProperties();
            foreach (var prop in props)
            {
                var info= prop.GetAccessors();
                Console.WriteLine(prop.Name+(info[0].IsVirtual?"是虚方法":"不是虚方法"));
                ;
            }
        }

        public class Model{
            public string Name { get; set; }
            public virtual string Json { get; set; }
        }

        public static void  SetValue(){
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
    }
}
