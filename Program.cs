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
            RippleImplementation xrp = new RippleImplementation("wss://s.altnet.rippletest.net:51233", debugger: false);
            xrp.RippleServerInfo();
            var t = new Thread(() => xrp.RippleSocketRun());
            t.Start();

            while(true)
            {
                if(xrp.incoming.Count > 0)
                {

                Console.WriteLine(xrp.incoming.Dequeue()["status"]);
                }
            }
        }
    }
}
