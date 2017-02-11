using System;
using System.Collections.Generic;
using YellOwl;

namespace VkPublisher
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var host = new YellOwlHost("http://localhost:11002");
            host.Start();
            Console.ReadKey();
        }
    }
}
