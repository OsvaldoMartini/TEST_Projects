using System;
using System.Collections.Generic;
using System.Text;

namespace QueueExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueDemo ThomastonBankandTrust;
            ThomastonBankandTrust = new QueueDemo();
            ThomastonBankandTrust.QueueCustomers();
            // pause
            Console.Read();
        }
    }
}
