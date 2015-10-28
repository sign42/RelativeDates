using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeDates {
	/// <summary>
	/// Fluent Interface for adding multiple criteria to generate random dates
	/// </summary>
	public class DateBuilder {

		private DateTime _start = DateTime.MinValue;
		private DateTime _end = DateTime.MaxValue;
		private DateTime? _result = null;

		/// <summary>
		/// Adds a constraint to the start of the acceptable period
		/// </summary>
		/// <param name="start">The earliest the resulting date can be</param>
		/// <returns>The updated object</returns>
		public DateBuilder AndNoEarlier(DateTime start) {
			if (start > _start)
				_start = start;
			_result = null;
			return this;
		}

		/// <summary>
		/// Adds a constraint to the end of the acceptable period
		/// </summary>
		/// <param name="end">The latest the resulting date can be</param>
		/// <returns>The updated object</returns>
		public DateBuilder AndNoLater(DateTime end) {
			if (end < _end)
				_end = end;
			_result = null;
			return this;
		}

		/// <summary>
		/// Generates a random date based on the current state. 
		/// </summary>
		/// <param name="regenerate">Force a new value to be generated</param>
		/// <returns>A DateTime in the specified range</returns>
		public DateTime Generate(bool regenerate = false) {
			if (regenerate || !_result.HasValue) {
				_result = _start.AndNoLaterThanButBefore(_end);
			}
			return _result.Value;
		}

		/// <summary>
		/// Implict conversion to DateTime
		/// </summary>
		/// <param name="builder"></param>
		public static implicit operator DateTime(DateBuilder builder) {
			return builder.Generate();
		}
	}
}
