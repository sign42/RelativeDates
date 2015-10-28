using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelativeDates;

namespace RelativeDatesTests {
	[TestClass]
	public class DateBuilderTests {
		[TestMethod]
		public void DateGeneratorOnlyGeneratesOneDate() {
			var item = new DateBuilder();
			var result1 = item.Generate();
			var result2 = item.Generate();

			Assert.AreEqual(result1, result2);
		}

		[TestMethod]
		public void Regenerate() {
			var item = new DateBuilder();
			var result1 = item.Generate();
			var result2 = item.Generate(true);

			Assert.AreNotEqual(result1, result2);
		}
	}
}
