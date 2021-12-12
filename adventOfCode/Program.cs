using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace adventOfCode
{
	public class Program
	{
		static void Main(string[] args)
		{
			//Day1();
			//Day2();
			//Day3();
			//Day4();
			Day5();
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


		public static void Day3()
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

		public static void Day4()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input4.txt").ToList();
			int result = PlayBingo(lines);
			Console.WriteLine(result);
		}

		public static int PlayBingo(List<string> lines)
		{
			int[] randomNumbers = GetRandomeNumbers(lines);
			if (randomNumbers == null) return 0;
			if (!randomNumbers.Any()) return 0;
			lines.RemoveAt(0);
			List<List<int[]>> tables = GetTables(lines);

			List<List<bool[]>> results = GetBlanks(tables);

			List<int> remainingTablesToWin = new List<int>();
			for (int i = 0; i < tables.Count; i++)
			{
				remainingTablesToWin.Add(i);
			}

			foreach (int randomNumber in randomNumbers)
			{
				for (var tableIndex = 0; tableIndex < tables.Count; tableIndex++)
				{
					List<int[]> board = tables[tableIndex];
					List<bool[]> markedTable = results[tableIndex];

					for (var i = 0; i < board.Count; i++)
					{
						int[] row = board[i];

						for (int j = 0; j < row.Length; j++)
						{
							if (row[j] != randomNumber) continue;

							markedTable[i][j] = true;
							if (!BoardHasWon(markedTable, j, i)) continue;
							remainingTablesToWin.Remove(tableIndex);
							
							if(remainingTablesToWin.Any()) continue;

							int unMarkedNumbersSum = GetUnmarkedNumbersSum(markedTable, board);
							return unMarkedNumbersSum * randomNumber;
						}
					}
				}
				
			}

			return 0;
		}

		private static bool BoardHasWon(List<bool[]> markedTable, int j, int i)
		{
			return RowIsComplete(markedTable, j) || ColumnIsComplete(markedTable[i]);
		}

		public static int GetUnmarkedNumbersSum(List<bool[]> markedTable, List<int[]> board)
		{
			var sum = 0;
			for (int i = 0; i < board.Count; i++)
			{
				for (int j = 0; j < board[i].Length; j++)
				{
					if (!markedTable[i][j])
						sum += board[i][j];
				}
			}

			return sum;
		}

		public static bool BoardHasWon(List<bool[]> markedTable)
		{
			foreach (bool[] mark in markedTable)
			{
				if (ColumnIsComplete(mark))
					return true;
				for (var j = 0; j < mark.Length; j++)
				{
					if (RowIsComplete(markedTable, j))
						return true;
				}
			}
			return false;
		}

		private static bool ColumnIsComplete(bool[] markedRow)
		{
			return markedRow.All(o => o);
		}

		private static bool RowIsComplete(List<bool[]> results, int j)
		{
			return results.All(o => o[j]);
		}

		private static List<List<bool[]>> GetBlanks(List<List<int[]>> tables)
		{
			List<List<bool[]>> blankTables = new List<List<bool[]>>();
			foreach (List<int[]> table in tables)
			{
				var columns = table.First().Length;
				var rows = table.Count;
				List<bool[]> blankTable = new List<bool[]>(rows);
				for (int i = 0; i < rows; i++)
				{
					blankTable.Add(new bool[columns]);	
				}
				blankTables.Add(blankTable);

			}

			return blankTables;
		}

		private static List<List<int[]>> GetTables(List<string> tableLines)
		{
			List<List<int[]>> tables = new List<List<int[]>>();
			List<int[]> table = new List<int[]>();
			foreach (string tableLine in tableLines)
			{
				if (string.IsNullOrWhiteSpace(tableLine))
				{
					if (table.Any())
					{
						tables.Add(table.ToList());
						table = new List<int[]>();
						
					}
					continue;

				}

				string[] strings = tableLine.Trim().Split(' ').Where(o=>!string.IsNullOrWhiteSpace(o)).ToArray();
				int[] lineSplit = strings.Select(int.Parse).ToArray();
				table.Add(lineSplit);
			}
			if (table.Any())
			{
				tables.Add(table.ToList());
			}

			return tables;
		}

		private static int[] GetRandomeNumbers(List<string> lines)
		{
			string firstLine = lines.FirstOrDefault(o => !string.IsNullOrEmpty(o.Trim()));
			if (firstLine == null) return new int[0];
			string[] strings = firstLine.Split(',');
			return strings.Select(int.Parse).ToArray();
		}


		public static void Day5()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input5.txt").ToList();
			int increasesCount = GetNumberOfPointsWhereAtLeast2LinesOverLap(lines);
			Console.WriteLine(increasesCount);
		}

		class Vector2D
		{
			public int x, y;
		}

		class HydroThermalVentsCoordinates
		{
			public Vector2D MinCoordinates = new Vector2D(){x = int.MaxValue, y= int.MaxValue};
			public Vector2D MaxCoordinates = new Vector2D(){x = int.MinValue, y = int.MinValue };

			public List<Vector2D[]> HydrothermalVentsCoordinates = new List<Vector2D[]>();
		}
		public static int GetNumberOfPointsWhereAtLeast2LinesOverLap(List<string> lines)
		{
			HydroThermalVentsCoordinates coordintates = GetHydroThermalCoordinates(lines);
			int[,] map = new int[coordintates.MaxCoordinates.x +1 , coordintates.MaxCoordinates.y +1]; 
			foreach (Vector2D[] coordinates in coordintates.HydrothermalVentsCoordinates)
			{
				var from2D = coordinates[0];
				var to2D = coordinates[1];

				if (to2D.x != from2D.x && from2D.y != to2D.y) continue;

				AddLineToMap(from2D, to2D, map);

			}

			var overlapCount = 0;
			for (int i = coordintates.MinCoordinates.x; i < map.GetLength(0); i++)
			{
				for (int j = coordintates.MinCoordinates.y; j < map.GetLength(1); j++)
				{
					if (map[i, j] > 1)
						overlapCount++;
				}
			}


			return overlapCount;
		}

		private static void AddLineToMap(Vector2D from2D, Vector2D to2D, int[,] map)
		{
			var fromX = from2D.x;
			var fromY = from2D.y;
			var toX = to2D.x;
			var toY = to2D.y;


			if (from2D.x > to2D.x)
			{
				toX = fromX;
				fromX = to2D.x;
			}

			if (from2D.y > to2D.y)
			{
				toY = fromY;
				fromY = to2D.y;
			}

			for (int i = fromX; i <= toX; i++)
			{
				for (int j = fromY; j <= toY; j++)
				{
					map[i, j] = map[i,j]+1;
				}
			}
		}

		private static HydroThermalVentsCoordinates GetHydroThermalCoordinates(List<string> lines)
		{
			HydroThermalVentsCoordinates coordinates = new HydroThermalVentsCoordinates();
			foreach (string line in lines)
			{
				var lineSplit = line.Split("->");

				string from = lineSplit[0];
				string to = lineSplit[1];
				List<string> fromSplit = @from.Split(',').Where(o => !string.IsNullOrWhiteSpace(o)).ToList();
				List<string> toSplit = to.Split(',').Where(o => !string.IsNullOrWhiteSpace(o)).ToList();

				Vector2D from2D = GetCoordinate(fromSplit);
				Vector2D to2D = GetCoordinate(toSplit);

				coordinates.HydrothermalVentsCoordinates.Add(new Vector2D[] {from2D, to2D});

				
				if (from2D.x < coordinates.MinCoordinates.x)
					coordinates.MinCoordinates.x = from2D.x;
				if (from2D.x > coordinates.MaxCoordinates.x)
					coordinates.MaxCoordinates.x = from2D.x;

				if (from2D.y < coordinates.MinCoordinates.y)
					coordinates.MinCoordinates.y = from2D.y;
				if (from2D.y > coordinates.MaxCoordinates.y)
					coordinates.MaxCoordinates.y = from2D.y;

				if (to2D.x < coordinates.MinCoordinates.x)
					coordinates.MinCoordinates.x = to2D.x;
				if (to2D.x > coordinates.MaxCoordinates.x)
					coordinates.MaxCoordinates.x = to2D.x;

				if (to2D.y < coordinates.MinCoordinates.y)
					coordinates.MinCoordinates.y = to2D.y;
				if (to2D.y > coordinates.MaxCoordinates.y)
					coordinates.MaxCoordinates.y = to2D.y;
			}

			return coordinates;
		}

		private static Vector2D GetCoordinate(List<string> coordinateString)
		{
			Vector2D from2D = new Vector2D();
			if (int.TryParse(coordinateString[0], out int fromX) && int.TryParse(coordinateString[1], out int fromY))
			{
				from2D = new Vector2D() {x = fromX, y = fromY};
			}
			return from2D;
		}
	}


}
