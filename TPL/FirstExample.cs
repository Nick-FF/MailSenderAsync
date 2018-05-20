using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
	public class FirstExample
	{
		public void Main()
		{
			Task task = new Task(TaskMethod);
			task.Start();
			Console.WriteLine("Ждем окончания работы задачи.");
			task.Wait();
			Console.ReadKey();
		}
		private void TaskMethod()
		{
			Console.WriteLine("Задача {0} выполняется.", Task.CurrentId);
			Thread.Sleep(2000);
			Console.WriteLine("Задача {0} завершена.", Task.CurrentId);
		}

	}
}