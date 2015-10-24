using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RelativeDates
{
    public static class RelativeDateExtensions
    {
		/// <summary>
		/// Generates a random date before the this date, if one exists
		/// </summary>
		/// <param name="periodEnd">The date the random should be before</param>
		/// <returns>A random date before periodEnd</returns>
		public static DateTime Before(this DateTime periodEnd) {
			var rand = ThreadSafeRandom.NextDouble();
			var start = DateTime.MinValue;
			var range = periodEnd - start;
			var adjustedTicksFromStart = (range.Ticks) * rand;
            return start + TimeSpan.FromTicks((long)adjustedTicksFromStart);
		}

		/// <summary>
		/// Generates a random date after this date, if one exists
		/// </summary>
		/// <param name="periodStart">The date after which the result should be</param>
		/// <returns>A random date after periodStart</returns>
		public static DateTime After(this DateTime periodStart) {
			var rand = ThreadSafeRandom.NextDouble();
			var end = DateTime.MaxValue;
			var range = end - periodStart;
			var adjustedTicksFromStart = (range.Ticks + 1) * rand;
			return periodStart + TimeSpan.FromTicks((long)adjustedTicksFromStart);
		}

		/// <summary>
		/// Generates a random date, if one exists
		/// </summary>
		/// <param name="periodStart">When the generated date must be after</param>
		/// <param name="periodEnd">When the generated date must be before</param>
		/// <throws name="ArgumentException">If periodStart is greater than periodEnd</throws>
		/// <returns>A random date in the periodn</returns>
		public static DateTime BeforeAndAfter(this DateTime periodStart, DateTime periodEnd) {
			if (periodEnd < periodStart)
				throw new ArgumentException("periodEnd must be greater than periodStart");
			var rand = ThreadSafeRandom.NextDouble();
			var range = periodEnd - periodStart;
			var adjustedTicksFromStart = (range.Ticks + 1) * rand;
			return periodStart + TimeSpan.FromTicks((long)adjustedTicksFromStart);
		}
    }
}
