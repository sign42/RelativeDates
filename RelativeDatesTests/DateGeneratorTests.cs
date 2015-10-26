using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelativeDates;

namespace RelativeDatesTests {
	[TestClass]
	public class DateGeneratorTests {
		[TestMethod]
		public void DateGeneratorOnlyGeneratesOneDate() {
			var item = new DateGenerator();
			var result1 = item.Generate();
			var result2 = item.Generate();

			Assert.AreEqual(result1, result2);
		}
	}
}
