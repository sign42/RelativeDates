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
		public static DateTime AndNoLaterThanButBefore(this DateTime? periodStart, DateTime? periodEnd) {
			if (!periodStart.HasValue)
				periodStart = DateTime.MinValue;
			if (!periodEnd.HasValue)
				periodEnd = DateTime.MaxValue;
			return periodStart.Value.AndNoLaterThanButBefore(periodEnd.Value);
		}

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
		/// Adds a constraint to the end of the acceptable period
		/// </summary>
		/// <param name="end">The latest the resulting date can be</param>
		/// <returns>DateBuilder object with this constraint</returns>
		public static DateBuilder AndNoLater(this DateTime periodEnd) {
			return new DateBuilder().AndNoLater(periodEnd);
		}

		/// <summary>
		/// Adds a constraint to the start of the acceptable period
		/// </summary>
		/// <param name="start">The earliest the resulting date can be</param>
		/// <returns>DateBuilder object with this constraint</returns>
		public static DateBuilder AndNoEarlier(this DateTime periodStart) {
			return new DateBuilder().AndNoEarlier(periodStart);
		}

		/// <summary>
		/// Adds a constraint to the end of the acceptable period
		/// </summary>
		/// <param name="end">The latest the resulting date can be</param>
		/// <returns>DateBuilder object with this constraint</returns>
		public static DateBuilder AndNoLater(this DateTime? periodEnd) {
			return new DateBuilder().AndNoLater(periodEnd ?? DateTime.MaxValue);
		}

		/// <summary>
		/// Adds a constraint to the start of the acceptable period
		/// </summary>
		/// <param name="start">The earliest the resulting date can be</param>
		/// <returns>DateBuilder object with this constraint</returns>
		public static DateBuilder AndNoEarlier(this DateTime? periodStart) {
			return new DateBuilder().AndNoEarlier(periodStart ?? DateTime.MinValue);
		}
	}
}
