using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	public class TaskResult
	{
		public void Main()
		{
			Console.WriteLine("Start");

			Task<int> task = Task<int>.Factory.StartNew(() => Method(10));

			Console.WriteLine($"Result = {task.Result}");

			task.Wait();
			task.Dispose();

			Console.WriteLine("Stop");
			Console.ReadKey();
		}

		private int Method(int value)
		{
			int result = 0;
			for (var i = 1; i <= value; i++)
			{
				result += i;
			}

			Thread.Sleep(5000);
			return result;
		}
	}
}