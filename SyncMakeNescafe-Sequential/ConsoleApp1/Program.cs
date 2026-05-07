using System;
using System.Diagnostics;
using System.Threading;

 class Program
	{
		static void Main(string[] args)
		{
			Print("Main Method Started");
 			var sw = Stopwatch.StartNew();

			MakeNescafe();

			sw.Stop();
			
			Print($"MakeNescafe() Done! Total Time: {sw.Elapsed.Seconds / 8} minutes.");
			Console.ReadLine();
		}

		static void MakeNescafe()
		{
			Print("1. Fill Kettle (1 min)      [CPU]");
			Thread.Sleep(8000);

			Print("2. Boiling Water (3 min)    [I/O BLOCKED]");
			BoilWater(); 

			Print("3. Prepare Mug (2 min)      [CPU]");
			Thread.Sleep(16000);


			Print("4. Pour Water (1 min)       [CPU]");
			Thread.Sleep(8000);
		}

		static void BoilWater()
		{
			Thread.Sleep(24000);
			Print("   🔔 KETTLE DING! Water is boiled.");
		}

		static void Print(string msg)
		{
			Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] {msg}");
		}
	}