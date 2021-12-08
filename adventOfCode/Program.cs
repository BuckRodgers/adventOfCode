using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace adventOfCode
{
	public class Program
	{
		static void Main(string[] args)
		{
			//Day1();
			//Day2();
			Day3();
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


		public static void Day3()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input3.txt").ToList();
			int increasesCount = GetLifeSuppportRating(lines);
			Console.WriteLine(increasesCount);
			//increasesCount = GetGammaRate2(lines);
			//Console.WriteLine(increasesCount);
		}

		public static int GetLifeSuppportRating(List<string> lines)
		{
			//get first bit


			GetOxygenGeneratorRating(lines);

			int OxygenRating = GetOxygenGeneratorRating(lines);
			int CO2Rating = GetCo2Rating(lines);


			return OxygenRating * CO2Rating;

		}

		public static int GetCo2Rating(List<string> lines)
		{
			int mostCommonBitsLength = GetMostCommonBits(lines).Length;
			List<string> o2Lines = new List<string>(lines);
			for (int i = 0; i < mostCommonBitsLength; i++)
			{
				int[] mostCommonBits = GetMostCommonBits(o2Lines);
				if (mostCommonBits[i] == 1)
				{
					o2Lines = o2Lines.Where(o => o[i]==('0')).ToList();
				}
				else
				{
					o2Lines = o2Lines.Where(o => o[i]==('1')).ToList();
				}
				if (o2Lines.Count == 1)
					break;

			}
			

			string r1 = string.Join("", o2Lines.First());
			var ans1 = Convert.ToInt32(r1, 2);
			return ans1;

		}

		public static int GetOxygenGeneratorRating(List<string> lines)
		{
			int mostCommonBitsLength = GetMostCommonBits(lines).Length;
			List<string> o2Lines = new List<string>(lines);
			for (int i = 0; i < mostCommonBitsLength; i++)
			{
				int[] mostCommonBits = GetMostCommonBits(o2Lines);
				if (mostCommonBits[i] == 1)
				{
					o2Lines = o2Lines.Where(o => o[i]==('1')).ToList();
				}
				else
				{
					o2Lines = o2Lines.Where(o => o[i]==('0')).ToList();
				}

				if (o2Lines.Count == 1)
					break;
			}

			string r1 = string.Join("", o2Lines.First());
			var ans1 = Convert.ToInt32(r1, 2);
			return ans1;

		}

		public static int getPowerConsumption(List<string> lines)
		{
			var result = GetMostCommonBits(lines);
			if (result == null) return 0;

			int[] result2 = GetFlippedBits(result);

			string r1 = string.Join("", result);
			var ans1 = Convert.ToInt32(r1, 2);

			string r = string.Join("", result2);
			var ans = Convert.ToInt32(r, 2);

			return ans*ans1;
		}

		private static int[] GetFlippedBits(int[] result)
		{
			var result2 = new int[result.Length];
			for (int j = 0; j < result.Length; j++)
			{
				result2[j] = (result[j] == 1 ? 0 : 1);
			}

			return result2;
		}

		private static int[] GetMostCommonBits(List<string> lines)
		{
			if (!lines.Any()) return null;
			var length = lines[0].Length;
			int[] counter = new int[length];
			Array.Clear(counter, 0, counter.Length);
			foreach (string line in lines)
			{
				for (var j = 0; j < line.Length; j++)
				{
					if(line[j] == '1')
						counter[j] += 1;
				}
			}

			int lineCount = lines.Count;
			int[] result = new int[counter.Length];
			for (int j = 0; j < counter.Length; j++)
			{
				if(counter[j] >= lineCount/2.0)
					result[j] = 1;
				else
				{
					result[j] = 0;
				}
			}

			return result;
		}
	}
}
