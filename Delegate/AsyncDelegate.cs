using System;
using System.Threading;

namespace Delegate
{
	public class AsyncDelegate
	{
		public void Main()
		{
			var myDelegate = new Action(Method);

			IAsyncResult result = myDelegate.BeginInvoke(null, null);

			myDelegate.EndInvoke(result);

			for (var i = 0; i < 80; i++)
			{
				Thread.Sleep(50);
				Console.Write("L");
			}

			Console.ReadKey();
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