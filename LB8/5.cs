using System;
using System.Threading;

class Program
{
    static int x = 0;
    static int y = 0;
    static AutoResetEvent autoEventX = new AutoResetEvent(true);
    static AutoResetEvent autoEventY = new AutoResetEvent(false);

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
            autoEventX.WaitOne(); // Очікування дозволу для X
            x++;
            Console.WriteLine($"{Thread.CurrentThread.Name} = {x}");
            autoEventY.Set(); // Дозволяємо потокам Y працювати
            Thread.Sleep(100);
        }
    }

    static void CountY()
    {
        for (int i = 0; i < 5; i++)
        {
            autoEventY.WaitOne(); // Очікування дозволу для Y
            y++;
            Console.WriteLine($"{Thread.CurrentThread.Name} = {y}");
            autoEventX.Set(); // Дозволяємо потокам X працювати
            Thread.Sleep(100);
        }
    }
}