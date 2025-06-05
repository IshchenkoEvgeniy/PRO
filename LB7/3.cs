using System;
using System.Threading;

class Program
{
    // Лічильник, який визначає поточне число
    static int counter = 0;
    static object locker = new object();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Default;

        // Створення трьох потоків
        Thread thread1 = new Thread(PrintSequential);
        Thread thread2 = new Thread(PrintSequential);
        Thread thread3 = new Thread(PrintSequential);

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

    static void PrintSequential(object threadName)
    {
        while (true)
        {
            lock (locker) // Блокування доступу до лічильника
            {
                if (counter > 29) break; // Завершення при досягненні 30

                // Вивід числа у суворій послідовності
                Console.WriteLine($"{threadName}: {counter}");
                counter++;
            }
            // Коротка затримка для імітації реальної роботи
            Thread.Sleep(50);
        }
    }
}