using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RelativeDates;

namespace RelativeDatesTests {
	[TestClass]
	public class RelativeDateExtensionsTests {
		[TestMethod]
		public void BeforeMinDate() {
			var baseDate = DateTime.MinValue;
			var result = baseDate.Before();
			// Going to accept this result
			Assert.AreEqual(baseDate, result);
		}


		[TestMethod]
		public void BeforeNow() {
			var results = new List<DateTime>();
			var baseDate = DateTime.Now;
			for(int i=0; i< 100; i++) {
				var result = baseDate.Before();
				Assert.IsTrue(result < baseDate);
                results.Add(result);
			}
			// Check all of them against each other for uniqueness
			AssertAllDifferent(results);
		}

		private void AssertAllDifferent(List<DateTime> values) {
			for(int i=0; i<values.Count; i++) {
				for(int j=i+1; j<values.Count; j++) {
					Assert.AreNotEqual(values[i], values[j]);
				}
			}
		}
	}
}
