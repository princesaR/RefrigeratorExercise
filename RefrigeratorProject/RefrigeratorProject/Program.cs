using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var r1 = new Refrigerator("1", "1", 3, null);
            Console.WriteLine(r1);

        }
    }
}
