using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RelativeDates;

namespace RelativeDatesTests {
	[TestClass]
	public class RelativeDateExtensionsTests {
		private void TestInLoop(Func<DateTime> generator) {
			var results = new List<DateTime>();
			var baseDate = DateTime.Now;
			for (int i = 0; i < 100; i++) {
				results.Add(generator());
			}
			// Check all of them against each other for uniqueness
			AssertAllDifferent(results);
		}
	
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void BeforeAndAfterWithNoValidResult() {
			var start = DateTime.MaxValue;
			var end = DateTime.MinValue;
			start.AndNoLaterThanButBefore(end);
		}

		[TestMethod]
		public void BeforeAndAfterSameValue() {
			var date = DateTime.Now;
			var result = date.AndNoLaterThanButBefore(date);
			Assert.AreEqual(date, result);
		}

		[TestMethod]
		public void BeforeAndAfter() {
			var start = DateTime.Now;
			var end = start.AddDays(1);
			TestInLoop(() => {
				var result = start.AndNoLaterThanButBefore(end);
				Assert.IsTrue(result > start);
				Assert.IsTrue(result < end);
				return result;
			});
		}

		private static void AssertAllDifferent(List<DateTime> values) {
			for(int i=0; i<values.Count; i++) {
				for(int j=i+1; j<values.Count; j++) {
					Assert.AreNotEqual(values[i], values[j]);
				}
			}
		}

		[TestMethod]
		public void MultipleLaters() {
			var baseDate = DateTime.Now;
			var secondDate = baseDate.AddDays(-1);
            TestInLoop(() => {
				var result = baseDate.AndNoLater().AndNoLater(secondDate);
				Assert.IsTrue(result < secondDate);
				return result;
			});
		}

		[TestMethod]
		public void MultipleEarliers() {
			var baseDate = DateTime.Now;
			var secondDate = baseDate.AddDays(1);
			TestInLoop(() => {
				var result = baseDate.AndNoEarlier().AndNoEarlier(secondDate);
				Assert.IsTrue(result > baseDate);
				return result;
			});
		}

		[TestMethod]
		public void MultipleEarliersAndLaters() {
			var start = DateTime.Now;
			var secondStart = start.AddDays(-1);
			var end = start.AddDays(10);
			var secondEnd = end.AddDays(1);
			TestInLoop(() => {
				var result = start.AndNoEarlier().AndNoEarlier(secondStart).AndNoLater(end).AndNoLater(secondEnd);
				Assert.IsTrue(result > start);
				Assert.IsTrue(result < end);
				return result;
			});
		}
	}
}
