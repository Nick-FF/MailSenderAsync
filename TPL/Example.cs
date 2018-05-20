using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	public class Example
	{
		public void Main()
		{
			Console.WriteLine("Start");
			var task1 = Task.Factory.StartNew(Method);
			var task2 = Task.Factory.StartNew(Method1);

			Console.WriteLine($"task1 {task1.Id}");
			Console.WriteLine($"task2 {task2.Id}");

			Task.WaitAll(task1, task2);

			task1.Dispose();
			task2.Dispose();

			Console.WriteLine("Stop");
			Console.ReadKey();
		}

		private void Method()
		{
			for (var i = 1; i <= 10; i++)
			{
				Thread.Sleep(500);
				Console.WriteLine($"Method #{Task.CurrentId} count {i}");
			}
		}

		private void Method1()
		{
			for (var i = 1; i <= 10; i++)
			{
				Thread.Sleep(501);
				Console.WriteLine($"Method #{Task.CurrentId} count {i}");
			}
		}
	}
}