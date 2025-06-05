using System;
using System.Threading;

class Program
{
    static int x = 0;

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Default;
        for (int i = 0; i < 5; i++)
        {
            Thread myThread = new Thread(Count);
            myThread.Name = "Потік " + i.ToString();
            myThread.Start();
        }

        Console.ReadLine();
    }

    static void Count()
    {
        for (int i = 0; i < 5; i++)
        {
            x++;
            Console.WriteLine($"{Thread.CurrentThread.Name} = {x}");
            Thread.Sleep(100);
        }
    }
}