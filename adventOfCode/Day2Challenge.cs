using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventOfCode
{
	public class Day2Challenge
	{
		public static void Day2()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input2.txt").ToList();
			int result = ProductOfHorizontalAndDepthPosition(lines);
			Console.WriteLine(result);
			result = ProductOfHorizontalAndDepthPositionWithAim(lines);
			Console.WriteLine(result);
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