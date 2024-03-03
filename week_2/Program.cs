using System.ComponentModel;
using System.Diagnostics;

class Program
{
    static  async Task Main1()
    {
        Console.WriteLine("Main Thread started");
        SyncOperation();
        Stopwatch sw = Stopwatch.StartNew();
        AsyncOperation(1);
        await AsyncOperation(2);
        sw.Stop();
        Console.WriteLine($"Both asycn methods completed in {sw.ElapsedMilliseconds} ms.");

        
    }

    static void SyncOperation()
    {
        Console.WriteLine("Synchronous operation started");
        Stopwatch syncStopWatch = Stopwatch.StartNew();
        for (int i = 0; i < 5; i++) {
            Console.WriteLine($"Sync Operation - Step {i + 1}");
            Thread.Sleep(1000);
        }
        syncStopWatch .Stop();
        Console.WriteLine($"Synchronous methods completed in {syncStopWatch.ElapsedMilliseconds} ms.\n\n");

    }

    static async Task AsyncOperation(int taskNum)
    {
        Console.WriteLine($"Asynchronous operation {taskNum} started");
        Stopwatch asyncStopWatch = Stopwatch.StartNew();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Async Operation {taskNum} - Step {i + 1}");
            await Task.Delay(1000);
        }
        asyncStopWatch.Stop();
        Console.WriteLine($"AsynchronousOperation {taskNum} completed in {asyncStopWatch.ElapsedMilliseconds} ms.\n\n");

    }
}
