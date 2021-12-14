using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace adventOfCode
{
	public class Day6Challenge
	{
		public static void Run()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input6.txt").ToList();
			int increasesCount = SimulateFish(lines, 256);
			Console.WriteLine(increasesCount);
		}

		class LanternFish
		{
			private int daysToBirth = 0;
			List<LanternFish> children = new List<LanternFish>();
			public LanternFish(int initialDaysToBirth)
			{
				daysToBirth = initialDaysToBirth;
			}

			public void OnNewDay()
			{
				
				//Debug.Write(daysToBirth + ",");
				foreach (LanternFish lanternFish in children)
				{
					lanternFish.OnNewDay();
				}
				NewDay();
			}
			private void NewDay()
			{
				daysToBirth--;
				if (daysToBirth >= 0) return;
				daysToBirth = 6;
				SpawnNewFish();
			}

			private void SpawnNewFish()
			{
				children.Add(new LanternFish(8));
			}

			public int GetAncestorCount()
			{
				return children.Count + children.Sum(o => o.GetAncestorCount());
			}
		}

		public static int SimulateFish(List<string> input, int daysToSimulate)
		{

			int[] initialState = input[0].Split(',').Where(o => !string.IsNullOrWhiteSpace(o)).Select(o => int.Parse(o))
				.ToArray();
			List<LanternFish> fish = new List<LanternFish>();
			foreach (int i in initialState)
			{
				fish.Add(new LanternFish(i));
			}

			for (var i = 0; i < daysToSimulate; i++)
			{
				foreach (LanternFish lanternFish in fish)
				{
					lanternFish.OnNewDay();
				}
				//Debug.WriteLine("   " + i + ":" + fish.Count + fish.Sum(o => o.GetAncestorCount()));
			}

			var total = fish.Count + fish.Sum(o => o.GetAncestorCount());
			return total;
		}
	}
}