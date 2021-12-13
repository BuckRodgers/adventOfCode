using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventOfCode
{
	public class Day1Challenge
	{
		public static void Day1()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input.txt").ToList();
			int increasesCount = SlidingWindow(lines);
			Console.WriteLine(increasesCount);
		}

		public static int SlidingWindow(List<string> lines)
		{
			int increasesCount = 0;
			int previousSum = int.MinValue;
			int[] currentWindow = new int[4] {0, 0, 0, 0};
			int[] currentWindowCount = new int[4] {0, 0, 0, 0};

			for (var index = 0; index < lines.Count; index++)
			{
				string line = lines[index];
				if (!int.TryParse(line, out int depth)) continue;

				for (int i = 0; i < currentWindowCount.Length; i++)
				{
					if (currentWindowCount[i] == 3)
					{
						if (previousSum != int.MinValue && currentWindow[i] > previousSum)
							increasesCount++;
						previousSum = currentWindow[i];
						currentWindowCount[i] = 0;
						currentWindow[i] = 0;
					}
					else
					{
						if ((index - i) % currentWindowCount.Length < 0) continue;

						currentWindow[i] += depth;
						currentWindowCount[i]++;
					}

				}
			}

			for (var i = 0; i < currentWindowCount.Length; i++)
			{
				if (currentWindowCount[i] != 3) continue;

				if (previousSum != int.MinValue && currentWindow[i] > previousSum)
					increasesCount++;
				previousSum = currentWindow[i];
				currentWindowCount[i] = 0;
				currentWindow[i] = 0;

			}

			return increasesCount;
		}

	}
}