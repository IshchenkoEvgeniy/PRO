using System;
using System.Threading;

class Program
{
    static int x = 0;
    static int y = 0;

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        for (int i = 0; i < 10; i++)
        {
            Thread myThread;
            if (i < 5)
                myThread = new Thread(CountX);
            else
                myThread = new Thread(CountY);

            myThread.Name = "Потік " + i.ToString();
            myThread.Start();
        }

        Console.ReadLine();
    }

    static void CountX()
    {
        for (int i = 0; i < 5; i++)
        {
            x++;
            Console.WriteLine($"{Thread.CurrentThread.Name} = {x}");
            Thread.Sleep(100);
        }
    }

    static void CountY()
    {
        for (int i = 0; i < 5; i++)
        {
            y++;
            Console.WriteLine($"{Thread.CurrentThread.Name} = {y}");
            Thread.Sleep(100);
        }
    }
}