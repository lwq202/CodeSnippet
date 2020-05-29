using System.Collections;
using System;

namespace JsonConvertModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Model model=new Model();
        }
    }

    public interface IBase
    {

    }
    public class Model
    {
        public IEnumerable<IBase> Items { get; set; }
    }
    public class Model1 : IBase
    {
        public int Nnum1 { get; set; }
    }
    public class Model2 : IBase
    {
        public int Nnum2 { get; set; }

    }
}
