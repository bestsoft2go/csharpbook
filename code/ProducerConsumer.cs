using System;
using System.Threading;
using System.Collections.Generic;

class ProducerConsumer
{
    static readonly int BUFFER_SIZE = 4;
    static Queue<int> circularBuffer = new Queue<int>(BUFFER_SIZE);
    static Semaphore semaFilledSlots = new Semaphore(0, BUFFER_SIZE);
    static Semaphore semaUnfilledSlots = new Semaphore(BUFFER_SIZE, BUFFER_SIZE);
    static Mutex mutex = new Mutex(false);

    static void Main(string[] args)
    {
        Thread producer = new Thread(new ThreadStart(produce));
        Thread consumer = new Thread(new ThreadStart(consume));
        producer.Start();
        consumer.Start();
        producer.Join();
        consumer.Join();
    }

    static Random random = new Random();

    private static void produce()
    {
        while (true)
        {
            Thread.Sleep(random.Next(0, 500));
            int produceNumber = random.Next(0, 20);
            Console.WriteLine("Produce: {0}", produceNumber);

            semaUnfilledSlots.WaitOne(); 	// wait(semaUnfilledSlots)
            mutex.WaitOne();				// wait(mutex)

            queue.Enqueue(produceNumber);

            mutex.ReleaseMutex();           // signal(mutex)
            semaFilledSlots.Release();		// signal(semaFilledSlots)

            if (produceNumber == 0)
                break;
        }
    }

    private static void consume()
    {
        while (true)
        {
            semaFilledSlots.WaitOne(); 		// wait(semaFilledSlots)
            mutex.WaitOne();				// wait(mutex)
            int number = circularBuffer.Dequeue();
            Console.WriteLine("Consume: {0}", number);

            mutex.ReleaseMutex();       	// signal(mutex)
            semaUnfilledSlots.Release();	// signal(semaUnfilledSlots)
            if (number == 0)
                break;
            Thread.Sleep(random.Next(0, 1000));
        }
    }
}