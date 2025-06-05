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
        Thread thread1 = new Thread(PrintNumbers);
        Thread thread2 = new Thread(PrintNumbers);
        Thread thread3 = new Thread(PrintNumbers);

        // Запуск потоків
        thread1.Start("Потік 1");
        thread2.Start("Потік 2");
        thread3.Start("Потік 3");

        // Очікування завершення
        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("Всі потоки завершили роботу.");
    }

    static void PrintNumbers(object threadName)
    {
        for (int i = 0; i < 10; i++)
        {
            // Генерація випадкового числа від 0 до 9
            int randomNumber = random.Value.Next(0, 10);
            Console.WriteLine($"{threadName}: {randomNumber}");
            Thread.Sleep(50);
        }
    }
}