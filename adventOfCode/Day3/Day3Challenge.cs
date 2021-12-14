using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventOfCode
{
	public class Day3Challenge
	{
		public static void Run()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input3.txt").ToList();
			int result = GetLifeSuppportRating(lines);
			Console.WriteLine(result);
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