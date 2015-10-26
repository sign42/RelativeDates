using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeDates {
	/// <summary>
	/// Fluent Interface for adding multiple criteria to generate random dates
	/// </summary>
	public class DateGenerator {

		private DateTime _start = DateTime.MinValue;
		private DateTime _end = DateTime.MaxValue;
		private DateTime? _result = null;

		public DateGenerator AndNoEarlier(DateTime start) {
			if (start > _start)
				_start = start;
			_result = null;
			return this;
		}

		public DateGenerator AndNoLater(DateTime end) {
			if (end < _end)
				_end = end;
			_result = null;
			return this;
		}

		/// <summary>
		/// Generates a random date based on the 
		/// </summary>
		/// <returns></returns>
		public DateTime Generate() {
			if (!_result.HasValue) {
				_result = _start.AndNoLaterThanButBefore(_end);
			}
			return _result.Value;
		}

		public static implicit operator DateTime(DateGenerator generator) {
			return generator.Generate();
		}
	}
}
