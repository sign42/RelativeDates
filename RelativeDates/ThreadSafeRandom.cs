using System;

namespace RelativeDates {
	internal static class ThreadSafeRandom {
		private static readonly Random rand = new Random();
		private static readonly object randLock = new object();
		public static double NextDouble() {
			lock (randLock) {
				return rand.NextDouble();
			}
		}
	}
}
