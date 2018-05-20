using System;
using System.Threading;

namespace Delegate
{
	public class ResultDelegate
	{
		public void Main()
		{
			var myDelegate = new Func<int, int, int>(Method);

			IAsyncResult asyncResult = myDelegate.BeginInvoke(2, 2, null, null);

			while (!asyncResult.IsCompleted)
			{
				Console.Write(".");
				Thread.Sleep(100);
				Console.Write(".");
				Thread.Sleep(100);
				Console.Write(".");
				Thread.Sleep(100);
				Console.Clear();
			}

			var result = myDelegate.EndInvoke(asyncResult);

			Console.Write(result);
			Console.ReadKey();
		}

		private int Method(int a, int b)
		{
			Thread.Sleep(5000);
			return a * b;
		}
	}
}