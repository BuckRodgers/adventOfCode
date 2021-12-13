using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;

namespace adventOfCode
{
	public class Day5Challenge
	{
		public static void Day5()
		{
			var lines = File.ReadAllLines(@"C:\Users\rjl\Documents\adventofcode\input5.txt").ToList();
			int increasesCount = GetNumberOfPointsWhereAtLeast2LinesOverLap(lines);
			Console.WriteLine(increasesCount);
		}

		//class Vector2D
		//{
		//	public Vector2 v = new Vector2();
		//	public int x
		//	{
		//		get => (int) v.X;
		//		set => v.X = value;
		//	}
			
		//	public int y
		//	{
		//		get => (int) v.Y;
		//		set => v.Y = value;
		//	}

		//	//public int x, y;
		//}

		class HydroThermalVentsCoordinates
		{
			public Vector2 MinCoordinates = new Vector2(){X = int.MaxValue, Y= int.MaxValue};
			public Vector2 MaxCoordinates = new Vector2(){X = int.MinValue, Y = int.MinValue };

			public List<Line> HydrothermalVentsCoordinates = new List<Line>();
		}

		class Line
		{
			public Vector2 from;
			public Vector2 to;

			public List<Vector2> Points = new List<Vector2>();

			private List<Vector2> GetPoints()
			{
				var p = new List<Vector2>();

				var fromX = from.X;
				var fromY = from.Y;
				var toX = to.X;
				var toY = to.Y;

				if (to.X == from.X || from.Y == to.Y)
				{
					if (from.X > to.X)
					{
						toX = fromX;
						fromX = to.X;
					}

					if (from.Y > to.Y)
					{
						toY = fromY;
						fromY = to.Y;
					}

					for (int i = (int)fromX; i <= toX; i++)
					{
						for (int j = (int)fromY; j <= toY; j++)
						{
							p.Add(new Vector2(){X = i, Y = j});
						}
					}
				}
				else
				{

					var f = new Vector2(@from.X, @from.Y);
					var t = new Vector2(to.X, to.Y);
					while (!f.Equals(t))
					{
						p.Add(f);
						if (f.X < t.X)
						{
							f.X += 1;
						}
						else
						{
							f.X -= 1;
						}
						if (f.Y < t.Y)
						{
							f.Y += 1;
						}
						else
						{
							f.Y -= 1;
						}
					}
					p.Add(t);

				}

				return p;
			}


			public void SetPoints()
			{
				Points = GetPoints();
			}
		}
		public static int GetNumberOfPointsWhereAtLeast2LinesOverLap(List<string> input)
		{
			HydroThermalVentsCoordinates lines = GetHydroThermalLines(input);
			int[,] map = new int[(int)lines.MaxCoordinates.X +1 , (int)lines.MaxCoordinates.Y +1]; 
			foreach (Line line in lines.HydrothermalVentsCoordinates)
			{
				AddLineToMap(line, map);
			}

			var overlapCount = 0;
			for (int i = (int)lines.MinCoordinates.X; i < map.GetLength(0); i++)
			{
				for (int j = (int)lines.MinCoordinates.Y; j < map.GetLength(1); j++)
				{
					if (map[i, j] > 1)
						overlapCount++;
				}
			}


			return overlapCount;
		}

		private static void AddLineToMap(Line line, int[,] map)
		{
			foreach (Vector2 point in line.Points)
			{
				map[(int) point.X, (int) point.Y]++;
			}
		}

		private static HydroThermalVentsCoordinates GetHydroThermalLines(List<string> lines)
		{
			HydroThermalVentsCoordinates coordinates = new HydroThermalVentsCoordinates();
			foreach (string line in lines)
			{
				var lineSplit = line.Split("->");

				string from = lineSplit[0];
				string to = lineSplit[1];
				List<string> fromSplit = @from.Split(',').Where(o => !string.IsNullOrWhiteSpace(o)).ToList();
				List<string> toSplit = to.Split(',').Where(o => !string.IsNullOrWhiteSpace(o)).ToList();

				Vector2 from2D = GetCoordinate(fromSplit);
				Vector2 to2D = GetCoordinate(toSplit);

				Line l = new Line(){from = from2D, to = to2D};
				l.SetPoints();

				coordinates.HydrothermalVentsCoordinates.Add(l);

				
				if (from2D.X < coordinates.MinCoordinates.X)
					coordinates.MinCoordinates.X = from2D.X;
				if (from2D.X > coordinates.MaxCoordinates.X)
					coordinates.MaxCoordinates.X = from2D.X;

				if (from2D.Y < coordinates.MinCoordinates.Y)
					coordinates.MinCoordinates.Y = from2D.Y;
				if (from2D.Y > coordinates.MaxCoordinates.Y)
					coordinates.MaxCoordinates.Y = from2D.Y;

				if (to2D.X < coordinates.MinCoordinates.X)
					coordinates.MinCoordinates.X = to2D.X;
				if (to2D.X > coordinates.MaxCoordinates.X)
					coordinates.MaxCoordinates.X = to2D.X;

				if (to2D.Y < coordinates.MinCoordinates.Y)
					coordinates.MinCoordinates.Y = to2D.Y;
				if (to2D.Y > coordinates.MaxCoordinates.Y)
					coordinates.MaxCoordinates.Y = to2D.Y;
			}

			return coordinates;
		}

		private static Vector2 GetCoordinate(List<string> coordinateString)
		{
			Vector2 from2D = new Vector2();
			if (int.TryParse(coordinateString[0], out int fromX) && int.TryParse(coordinateString[1], out int fromY))
			{
				from2D = new Vector2() {X = fromX, Y = fromY};
			}
			return from2D;
		}
	}
}