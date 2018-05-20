using System;
using System.Threading;

namespace Delegate
{
	public class AsyncCallbackDelegate
	{
		public void Main()
		{
			var myDelegate = new Action(Method);
			var callback = new AsyncCallback(HandleComletion);
			IAsyncResult result = myDelegate.BeginInvoke(callback, "Method Com");

			myDelegate.EndInvoke(result);

			for (var i = 0; i < 80; i++)
			{
				Thread.Sleep(50);
				Console.Write("L");
			}

			Console.ReadKey();
		}

		private void HandleComletion(IAsyncResult ar)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(ar.AsyncState);
			Console.WriteLine();
		}

		private void Method()
		{
			for (var i = 0; i < 80; i++)
			{
				Thread.Sleep(50);
				Console.Write("R");
			}
		}
	}
}