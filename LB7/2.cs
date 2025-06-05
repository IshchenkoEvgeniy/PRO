using System;
using System.Threading;

class Program
{
    // ThreadLocal для забезпечення унікального Random для кожного потоку
    private static ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random());

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Default;

        // Створення трьох потоків
        Thread thread1 = new Thread(PrintRange);
        Thread thread2 = new Thread(PrintRange);
        Thread thread3 = new Thread(PrintRange);

        // Запуск потоків із різними діапазонами
        thread1.Start((0, 9, "Потік 1"));
        thread2.Start((10, 19, "Потік 2"));
        thread3.Start((20, 29, "Потік 3"));

        // Очікування завершення
        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("Всі потоки завершили роботу.");
    }

    static void PrintRange(object param)
    {
        var (start, end, threadName) = ((int, int, string))param;

        for (int i = 0; i < 10; i++)
        {
            // Генерація випадкового числа в заданому діапазоні
            int randomNumber = random.Value.Next(start, end + 1);
            Console.WriteLine($"{threadName}: {randomNumber}");
            Thread.Sleep(50);
        }
    }
}