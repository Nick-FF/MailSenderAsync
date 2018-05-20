namespace Delegate
{
	internal class Program
	{
		private static void Main()
		{
			var test = new AsyncCallbackDelegate();
			test.Main();
			System.Console.ReadKey();
		}
	}
}
