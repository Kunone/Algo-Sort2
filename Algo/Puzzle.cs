using System;

namespace Algo
{
	public class Puzzle
	{
		public Puzzle ()
		{
		}

		#region Hanoi

		public static void Hanoi(int n)
		{
			Hanoi (n, "a", "b", "c");
		}
		static void Hanoi(int n, string from, string by, string to)
		{
			if (n == 1) {
				Console.WriteLine (from + " >> " + to);
				return;
			}

			Hanoi (n - 1, from, to, by);
			Console.WriteLine (from + " >> " + to);
			Hanoi (n - 1, by, from, to);
		}

		#endregion
	}
}

