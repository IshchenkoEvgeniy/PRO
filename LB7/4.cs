using System;
using System.Threading;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Default;

        do
        {
            Console.WriteLine("\nВведіть режим роботи (1 - фоновий, 2 - основний):");
            string input = Console.ReadLine();
            bool isBackground = input == "1";

            Thread workerThread = new Thread(CountNumbers);
            workerThread.IsBackground = isBackground; // Встановлення режиму (фоновий або основний)
            Console.WriteLine($"\nЗапуск робітничого потоку... (Фоновий: {workerThread.IsBackground})");

            // Вимірювання часу виконання
            Stopwatch stopwatch = Stopwatch.StartNew();
            workerThread.Start();

            while (workerThread.IsAlive) // Працює, поки робітничий потік не завершився
            {
                Console.WriteLine("Основний потік працює...");
                Thread.Sleep(150); // 150 мс
                Console.WriteLine("Основний потік працює...");
                Thread.Sleep(200); // 200 мс
            }

            stopwatch.Stop();
            Console.WriteLine($"\nОсновний потік завершено.");
            Console.WriteLine($"Час виконання: {stopwatch.ElapsedMilliseconds} мс");

            Console.WriteLine("\nБажаєте повторити роботу? (Так - y, Ні - n):");
        }
        while (Console.ReadLine() == "y");

        Console.WriteLine("Програма завершена.");
    }

    static void CountNumbers()
    {
        Stopwatch workerStopwatch = Stopwatch.StartNew();

        for (int i = 0; i <= 10000000; i++)
        {
            if (i % 1000000 == 0) // Щоб не засмічувати консоль
                Console.WriteLine($"Робітничий потік: {i}");
        }

        workerStopwatch.Stop();
        Console.WriteLine($"Робітничий потік завершено. Час виконання: {workerStopwatch.ElapsedMilliseconds} мс");
    }
}