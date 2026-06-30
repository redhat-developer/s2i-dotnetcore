using System;

namespace EnvvarTest
{
	public static class Program
	{
		public static void Main()
		{
			#if DEBUG
				Console.WriteLine("Debug");
			#else
				Console.WriteLine("Release");
			#endif
		}
	}
}
