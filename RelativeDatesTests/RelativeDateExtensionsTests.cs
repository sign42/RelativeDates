﻿using System;
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
		public void BeforeNow() {
			var baseDate = DateTime.Now;
			TestInLoop(() => {
				var result = baseDate.Before();
				Assert.IsTrue(result < baseDate);
				return result;
			});
		}

		[TestMethod]
		public void AfterMaxDate() {
			var baseDate = DateTime.MaxValue;
			var result = baseDate.After();
			// Going to accept this result
			Assert.AreEqual(baseDate, result);
		}

		[TestMethod]
		public void AfterNow() {
			var baseDate = DateTime.Now;
			TestInLoop(() => {
				var result = baseDate.After();
				Assert.IsTrue(result > baseDate);
				return result;
			});
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void BeforeAndAfterWithNoValidResult() {
			var start = DateTime.MaxValue;
			var end = DateTime.MinValue;
			start.BeforeAndAfter(end);
		}

		[TestMethod]
		public void BeforeAndAfterSameValue() {
			var date = DateTime.Now;
			var result = date.BeforeAndAfter(date);
			Assert.AreEqual(date, result);
		}

		[TestMethod]
		public void BeforeAndAfter() {
			var start = DateTime.Now;
			var end = start.AddDays(1);
			TestInLoop(() => {
				var result = start.BeforeAndAfter(end);
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
	}
}
