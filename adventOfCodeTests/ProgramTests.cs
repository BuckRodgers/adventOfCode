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
	}
}