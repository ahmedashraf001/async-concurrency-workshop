 class Program
	{
		static async Task Main(string[] args) 
		{ 
			Print("Line01-main");
			Print("Line02-main");

			var task = CalculateSalaryAsync();

			Print("Line03-main");
			Print("Line04-main");

			var salary = await task;
			
			Print("Line05-main");
			Print("Line06-main");
		}
		
		static async Task<float> CalculateSalaryAsync()
		{
			float salary = 7000f;
			Print("Line01-Calc");
		 
			
			var result = await Task.Run( () =>
            {
                Print("Line02-Calc");
                Thread.Sleep(6000); 
                    
                Print("Line03-Calc");
                return salary * 1.2f;
            });
			
            return result;
		}

		static void Print(string msg)
		{
			Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] {msg}");
		}
	}