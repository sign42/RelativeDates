using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RelativeDates
{
    public static class RelativeDateExtensions
    {
		/// <summary>
		/// Generates a random date, if one exists
		/// </summary>
		/// <param name="periodStart">When the generated date must be after</param>
		/// <param name="periodEnd">When the generated date must be before</param>
		/// <throws name="ArgumentException">If periodStart is greater than periodEnd</throws>
		/// <returns>A random date in the periodn</returns>
		public static DateTime AndNoLaterThanButBefore(this DateTime periodStart, DateTime periodEnd) {
			if (periodEnd < periodStart)
				throw new ArgumentException("periodEnd must be greater than periodStart");
			var rand = ThreadSafeRandom.NextDouble();
			var range = periodEnd - periodStart;
			var adjustedTicksFromStart = (range.Ticks + 1) * rand;
			return periodStart + TimeSpan.FromTicks((long)adjustedTicksFromStart);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="periodEnd"></param>
		/// <returns></returns>
		public static DateGenerator AndNoLater(this DateTime periodEnd) {
			return new DateGenerator().AndNoLater(periodEnd);
		}

		public static DateGenerator AndNoEarlier(this DateTime periodStart) {
			return new DateGenerator().AndNoEarlier(periodStart);
		}
	}
}
