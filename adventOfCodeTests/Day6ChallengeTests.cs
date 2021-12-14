using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace adventOfCode.Tests
{
	[TestClass()]
	public class Day6ChallengeTests
	{
		private List<string> input = new List<string>()
		{
			"3,4,3,1,2										   ",
			"2,3,2,0,1										   ",
			"1,2,1,6,0,8										   ",
			"0,1,0,5,6,7,8									   ",
			"6,0,6,4,5,6,7,8,8								   ",
			"5,6,5,3,4,5,6,7,7,8								   ",
			"4,5,4,2,3,4,5,6,6,7								   ",
			"3,4,3,1,2,3,4,5,5,6								   ",
			"2,3,2,0,1,2,3,4,4,5								   ",
			"1,2,1,6,0,1,2,3,3,4,8							   ",
			"0,1,0,5,6,0,1,2,2,3,7,8							   ",
			"6,0,6,4,5,6,0,1,1,2,6,7,8,8,8					   ",
			"5,6,5,3,4,5,6,0,0,1,5,6,7,7,7,8,8				   ",
			"4,5,4,2,3,4,5,6,6,0,4,5,6,6,6,7,7,8,8			   ",
			"3,4,3,1,2,3,4,5,5,6,3,4,5,5,5,6,6,7,7,8			   ",
			"2,3,2,0,1,2,3,4,4,5,2,3,4,4,4,5,5,6,6,7			   ",
			"1,2,1,6,0,1,2,3,3,4,1,2,3,3,3,4,4,5,5,6,8		   ",
			"0,1,0,5,6,0,1,2,2,3,0,1,2,2,2,3,3,4,4,5,7,8		   ",
			"6,0,6,4,5,6,0,1,1,2,6,0,1,1,1,2,2,3,3,4,6,7,8,8,8,8"
		};

		[TestMethod()]
		public void SimualteFishTest()
		{
			int simulateFish = Day6Challenge.SimulateFish(input, 18);
			if(simulateFish != 26)
				Assert.Fail();
			simulateFish = Day6Challenge.SimulateFish(input, 80);
			if(simulateFish != 5934)
				Assert.Fail();
			simulateFish = Day6Challenge.SimulateFish(input, 256);
			if(simulateFish != 26984457539)
				Assert.Fail();
		}
	}
}