using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "My name is Imran";
            Console.WriteLine(Uppercaser.Uppercase(input));
            Console.Read();
        }
    }
}
