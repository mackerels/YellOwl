using System;

namespace YellOwl
{
    public class Program
    {
        public static void Main()
        {
            var host = new YellOwlHost("http://localhost:11002");
            host.Start();
            Console.ReadKey();
        }
    }
}