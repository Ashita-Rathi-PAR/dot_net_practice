using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingApplication
{
    public class MyThread
    {
        public static int i=0;
        public static void Thread1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(20);
            }
        }

        public void Thread2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;
            t.Name = "MainThread";
            Console.WriteLine(t.Name);

            Thread t1 = new Thread(new ThreadStart(MyThread.Thread1));
            Thread t2 = new Thread(new ThreadStart(MyThread.Thread1));
            t1.Start();
            t2.Start();
            Console.ReadLine();
            
            /*
            MyThread mt = new MyThread();
            Thread st1 = new Thread(new ThreadStart(mt.Thread2));
            Thread st2 = new Thread(new ThreadStart(mt.Thread2));
            st1.Start();
            st2.Start();
            Console.ReadLine();*/
        }
    }
}
