
namespace RippleType
{
    class Program
    {
        static void Main(string[] args)
        {
            RippleImplementation xrp = new RippleImplementation("wss://s.altnet.rippletest.net:51233", debugger:true);
        }
    }
}
