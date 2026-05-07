using System;
using System.Diagnostics;
using System.Threading;

 class Program
	{
		static async Task Main(string[] args)
		{
			Print("Main Method Started");
 			var sw = Stopwatch.StartNew();

			await MakeNescafeAsync();

			sw.Stop();
			
			Print($"MakeNescafeAsync() Done! Total Time: {sw.Elapsed.Seconds / 8} minutes.");
			Console.ReadLine();
		}

		static async Task MakeNescafeAsync()
		{
			Print("1. Fill Kettle (1 min)      [CPU]");
			Thread.Sleep(8000);

			Print("2. Boiling Water (3 min)    [I/O Triggered without await , So Current Thread can do some other work while waiting for External I/O to complete]");
			var task = BoilWaterAsync(); 

			Print("3. Prepare Mug (2 min)      [CPU]");
			Thread.Sleep(16000);

            Print("await here, so the Current Thread freed to The Thread pool until a hardware interrupt signal");
            await task;

			Print("4. Pour Water (1 min)       [CPU]");
			Thread.Sleep(8000);
		}

		static async Task BoilWaterAsync()
		{
			await Task.Delay(24000);
			Print("   🔔 KETTLE DING! Water is boiled.");
		}

		static void Print(string msg)
		{
			Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] {msg}");
		}
	}