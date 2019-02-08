using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace RippleType
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(new RippleNumbers().RippleToUnit("1.234567"));
            Console.ReadLine();
        }
    }
}
