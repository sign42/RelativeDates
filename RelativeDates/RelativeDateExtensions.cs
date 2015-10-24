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
		/// <returns>A random date befor periodEnd</returns>
		public static DateTime Before(this DateTime periodEnd) {
			var rand = ThreadSafeRandom.NextDouble();
			var start = DateTime.MinValue;
			var range = periodEnd - start;
			var adjustedTicksFromStart = (range.Ticks-1) * rand;
            return start + TimeSpan.FromTicks((long)adjustedTicksFromStart);
		}
    }
}
