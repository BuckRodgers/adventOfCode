using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventOfCode
{
	public class Day4Challenge
	{
		public static void Run()
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

	}
}