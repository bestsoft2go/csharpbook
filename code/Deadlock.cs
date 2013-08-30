using System;
using System.Threading;
using System.Text;

class ThreadTest
{
    static String A = "A";
    static String B = "B";

    public static void Main(String[] args)
    {
        Thread thread1 = new Thread(AB);
        Thread thread2 = new Thread(BA);
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
    }

    public static void AB()
    {
        lock (A)
        {
            Console.WriteLine("AB.lock(A)");
            Thread.Sleep(1000);
            lock (B)
            {
                Console.WriteLine("AB.lock(B)");
            }
        }
    }

    public static void BA()
    {
        lock (B)
        {
            Console.WriteLine("BA.lock(B)");
            Thread.Sleep(1000);
            lock (A)
            {
                Console.WriteLine("BA.lock(A)");
            }
        }
    }
}