using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelExample
{
	public class Example
	{
		public void Main()
		{
			Console.WriteLine("Start");

			var options = new ParallelOptions
			{
				MaxDegreeOfParallelism = 2
			};

			Parallel.Invoke(options,
				Method,
				Method,
				Method,
				Method
			);

			Console.WriteLine("Stop");
			Console.ReadKey();
		}

		private void Method()
		{
			Console.WriteLine("Task: {0} start.", Task.CurrentId);
			Thread.Sleep(5000);
			Console.WriteLine("Task: {0} done.", Task.CurrentId);
		}
	}
}