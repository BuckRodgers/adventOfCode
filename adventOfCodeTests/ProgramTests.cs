using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace adventOfCode.Tests
{
	[TestClass()]
	public class ProgramTests
	{
		[TestMethod()]
		public void SlidingWindowTest()
		{
			List<string> lines = new List<string>() { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };
			var result = Program.SlidingWindow(lines);
			if (result != 5)
				Assert.Fail();
		}

		[TestMethod()]
		public void ProductOfHorizontalAndDepthPositionTest()
		{
			List<string> lines = new List<string>(){
				"forward 5",
				"down 5",
				"forward 8",
				"up 3",
				"down 8	 ",
				"forward 2",};
			var result = Program.ProductOfHorizontalAndDepthPosition(lines);
			if (result != 150)
				Assert.Fail();
		}

		[TestMethod()]
		public void ProductOfHorizontalAndDepthPositionWithAimTest()
		{
			List<string> lines = new List<string>(){
				"forward 5",
				"down 5",
				"forward 8",
				"up 3",
				"down 8	 ",
				"forward 2",};
			var result = Program.ProductOfHorizontalAndDepthPositionWithAim(lines);
			if (result != 900)
				Assert.Fail();
		}

		[TestMethod()]
		public void GetGammaRate2Test()
		{

			if (Program.GetLifeSuppportRating(input3) != 230)
				Assert.Fail();
		}

		[TestMethod()]
		public void GetGammaRateTest()
		{

			if (Program.getPowerConsumption(input3) != 198)
				Assert.Fail();
		}

		List<string> input3 = new List<string>()
		{
			"00100",
			"11110",
			"10110",
			"10111",
			"10101",
			"01111",
			"00111",
			"11100",
			"10000",
			"11001",
			"00010",
			"01010"
		};

		[TestMethod()]
		public void GetLifeSuppportRatingTest()
		{
			if (Program.GetLifeSuppportRating(input3) != 230)
				Assert.Fail();
		}

		[TestMethod()]
		public void GetCo2RatingTest()
		{
			if (Program.GetCo2Rating(input3) != 10)
				Assert.Fail();
		}

		[TestMethod()]
		public void GetOxygenGeneratorRatingTest()
		{
			if (Program.GetOxygenGeneratorRating(input3) != 23)
				Assert.Fail();
		}

		private List<string> input4 = new List<string>()
		{
			"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
			"",
			"22 13 17 11  0",
			"8  2 23  4 24 ",
			"21  9 14 16  7",
			"6 10  3 18  5",
			"1 12 20 15 19",
			"			   ",
			"3 15  0  2 22",
			"9 18 13 17  5",
			"19  8  7 25 23",
			"20 11 10 24  4",
			"14 21 16 12  6",
			"			   ",
			"14 21 17 24  4",
			"10 16 15  9 19",
			"18  8 23 26 20",
			"22 11 13  6  5",
			"2  0 12  3  7 "
		};

		[TestMethod()]
		public void PlayBingoTest()
		{
			int playBingo = Program.PlayBingo(input4);
			if (playBingo != 1924)
				Assert.Fail();
		}

		private List<string> input5 = new List<string>()
		{
			"0,9 -> 5,9",
			"8,0 -> 0,8",
			"9,4 -> 3,4",
			"2,2 -> 2,1",
			"7,0 -> 7,4",
			"6,4 -> 2,0",
			"0,9 -> 2,9",
			"3,4 -> 1,4",
			"0,0 -> 8,8",
			"5,5 -> 8,2"
		};

		[TestMethod()]
		public void GetNumberOfPointsWhereAtLeast2LinesOverLapTest()
		{
			var result = Program.GetNumberOfPointsWhereAtLeast2LinesOverLap(input5);
			if(result!= 5)
				Assert.Fail();
		}
	}
}