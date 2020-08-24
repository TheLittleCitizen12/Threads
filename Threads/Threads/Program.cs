using System;
using System.Threading;
using System.Linq;

namespace Threads
{
    class Program
    {
        private static int _count = 0;
        private static int _countEmmpire = 0;
        private static int _countMamas = 0;
        private static object _locker = new object();
        static void Main(string[] args)
        {
            
            Thread t1 = new Thread(() => Print());
            Thread t2 = new Thread(() => Print());

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("empire: {0} mamas:{1} ", _countEmmpire, _countMamas);



        }

        static void Print()
        {
            

            while (_count < 10000)
            {
                if (_count % 2 == 1)
                {
                    Console.WriteLine("Empire");
                    _countEmmpire++;
                    

                }
                else
                {
                    Console.WriteLine("Mamas");

                    _countMamas++;
                    
                }
                lock (_locker)
                {
                    _count++;
                }
                
                


            }
            


        }

    }
        




    
    
}
