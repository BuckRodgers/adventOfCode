using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventOfCode
{
	public class Program
	{
		static void Main(string[] args)
		{
			Day1();
			Day2();
		}

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

		public static void Day2()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input2.txt").ToList();
			int increasesCount = ProductOfHorizontalAndDepthPosition(lines);
			Console.WriteLine(increasesCount);
			increasesCount = ProductOfHorizontalAndDepthPositionWithAim(lines);
			Console.WriteLine(increasesCount);
		}

		enum command
		{
			forward,
			down,
			up
		}
		public static int ProductOfHorizontalAndDepthPosition(List<string> lines)
		{
			int TotalDepth = 0;
			int TotalHorizontal = 0;

			for (var index = 0; index < lines.Count; index++)
			{
				string line = lines[index].Trim();
				var lineSplit = line.Split(" ");

				if (lineSplit == null || lineSplit.Length != 2) continue;
				if (!int.TryParse(lineSplit[1], out int amount)) continue;
				if (!Enum.TryParse(lineSplit[0], out command horizontal)) continue;
				
				switch (horizontal)
				{
					case command.forward:
					{
						TotalHorizontal += amount;
					}
						break;
					case command.down:
					{
						TotalDepth += amount;
					}
						break;
					case command.up:
					{
						TotalDepth -= amount;
					}
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			return TotalDepth*TotalHorizontal;
		}



		public static int ProductOfHorizontalAndDepthPositionWithAim(List<string> lines)
		{
			var TotalDepth = 0;
			var TotalHorizontal = 0;
			var totalAim = 0;

			for (var index = 0; index < lines.Count; index++)
			{
				string line = lines[index].Trim();
				var lineSplit = line.Split(" ");

				if (lineSplit == null || lineSplit.Length != 2) continue;
				if (!int.TryParse(lineSplit[1], out int amount)) continue;
				if (!Enum.TryParse(lineSplit[0], out command horizontal)) continue;
				
				switch (horizontal)
				{
					case command.forward:
					{
						TotalHorizontal += amount;
						TotalDepth += totalAim * amount;

					}
						break;
					case command.down:
					{
						totalAim += amount;
					}
						break;
					case command.up:
					{
						totalAim -= amount;
					}
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			return TotalDepth*TotalHorizontal;
		}

	}
}
