using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	public class ContinueTask
	{
		public void Main()
		{
			Console.WriteLine("Start");
			var task = new Task(Method);

			Task taskCon = task.ContinueWith(myT =>
			{
				Console.WriteLine("Continue Start");
				for (var i = 1; i <= 10; i++)
				{
					Thread.Sleep(500);
					Console.WriteLine($"Continue count {i}");
				}
				Console.WriteLine("Continue Stop");
			});

			task.Start();

			taskCon.Wait();
			task.Dispose();
			taskCon.Dispose();

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
	}
}