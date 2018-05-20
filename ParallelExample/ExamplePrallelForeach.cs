using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelExample
{
	public class ExamplePrallelForeach
	{
		public void Main()
		{
			List<int> collection = new List<int>() { 1, 3, 5, 7, 9, 11, 13, 15, 17 };
			ParallelLoopResult state = Parallel.ForEach(collection, ParallelMethod);
			if (!state.IsCompleted)
				Console.WriteLine("Terminated when collection index = {0}", state.LowestBreakIteration);
			Console.ReadKey();
		}

		private void ParallelMethod(int item, ParallelLoopState state)
		{
			Console.WriteLine("Item: {0}. Task: {1}", item, Task.CurrentId);
			if (item == 9)
				state.Break();
			Thread.Sleep(1000);
		}

	}
}