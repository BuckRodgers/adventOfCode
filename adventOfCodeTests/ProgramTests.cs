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
			if(Program.GetLifeSuppportRating(input3)!=230)
				Assert.Fail();
		}

		[TestMethod()]
		public void GetCo2RatingTest()
		{
			if(Program.GetCo2Rating(input3)!=10)
				Assert.Fail();
		}

		[TestMethod()]
		public void GetOxygenGeneratorRatingTest()
		{
			if(Program.GetOxygenGeneratorRating(input3)!=23)
				Assert.Fail();
		}
	}
}