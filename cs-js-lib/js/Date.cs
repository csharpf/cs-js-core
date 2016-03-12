using System;


namespace js {

	/// <summary>Creates a JavaScript Date instance that represents a single moment in time.</summary>
	class Date {

		#region data
		/// <summary>Local DateTime</summary>
		DateTime d;
		#endregion


		#region static data
		/// <summary>Unix date epoch</summary>
		static readonly long EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
		/// <summary>Number of ticks in a millisecond</summary>
		static readonly long MILLIS_TICKS = 10000;
		#endregion


		#region constructor
		// returns current date
		
		public Date(bool dummy=false) {
			d = DateTime.Now;
		}

		// return date specified by the the number of milliseconds since midnight Jan 1 1970
		public Date(long milliseconds) {
			d = new DateTime(_ticks(milliseconds), DateTimeKind.Utc).ToLocalTime();
		}

		// return date as specified by the string
		public Date(string dateString) {
			d = DateTime.Parse(dateString);
		}

		// return date from its components
		public Date(int year, int month, int day, int hours=0, int minutes=0, int seconds=0, int milliseconds=0) {
			d = new DateTime(year, month, day, hours, minutes, seconds, milliseconds);
		}
		#endregion

		// returns the number of milliseconds in a date since midnight of January 1, 1970, according to UTC time
		public static long UTC(int year, int month, int day, int hours = 0, int minutes = 0, int seconds = 0, int milliseconds = 0) {
			return _millis(new DateTime(year, month, day, hours, minutes, seconds, milliseconds, DateTimeKind.Utc).Ticks);
		}

		// returns the number of milliseconds since midnight Jan 1, 1970
		public static long now() {
			return _millis(DateTime.Now.ToUniversalTime().Ticks);
		}

		// parses a date string and returns the number of milliseconds since January 1, 1970
		public static long parse(string str) {
			return _millis(DateTime.Parse(str).ToUniversalTime().Ticks);
		}

		// returns the day of the month (from 1-31)
		public int getDate() {
			return d.Day;
		}

		// returns the day of the week (from 0-6)
		public int getDay() {
			return (int)d.DayOfWeek;
		}

		// returns the year (four digits)
		public int getFullYear() {
			return d.Year;
		}

		// returns the hour (from 0-23)
		public int getHours() {
			return d.Hour;
		}

		// returns the milliseconds (from 0-999)
		public int getMilliseconds() {
			return d.Millisecond;
		}

		// returns the minutes (from 0-59)
		public int getMinutes() {
			return d.Minute;
		}

		// returns the month (from 0-11)
		public int getMonth() {
			return d.Month-1;
		}

		// returns the seconds (from 0-59)
		public int getSeconds() {
			return d.Second;
		}

		// returns the number of milliseconds since midnight Jan 1 1970, and a specified date
		public long getTime() {
			return _millis(d.ToUniversalTime().Ticks);
		}

		// returns the time difference between UTC time and local time, in minutes
		public int getTimezoneOffset() {
			return TimeZoneInfo.Local.GetUtcOffset(d).Minutes;
		}

		// returns the day of the month, according to universal time (from 1-31)
		public int getUTCDate() {
			return d.ToUniversalTime().Day;
		}

		// returns the day of the week, according to universal time (from 0-6)
		public int getUTCDay() {
			return (int)d.ToUniversalTime().DayOfWeek;
		}

		// returns the year, according to universal time (four digits)
		public int getUTCFullYear() {
			return d.ToUniversalTime().Year;
		}

		// returns the hour, according to universal time (from 0-23)
		public int getUTCHours() {
			return d.ToUniversalTime().Hour;
		}

		// returns the milliseconds, according to universal time (from 0-999)
		public int getUTCMilliseconds() {
			return d.ToUniversalTime().Millisecond;
		}

		// returns the minutes, according to universal time (from 0-59)
		public int getUTCMinutes() {
			return d.ToUniversalTime().Minute;
		}

		// returns the month, according to universal time (from 0-11)
		public int getUTCMonth() {
			return d.ToUniversalTime().Month-1;
		}

		// returns the seconds, according to universal time (from 0-59)
		public int getUTCSeconds() {
			return d.ToUniversalTime().Second;
		}

		// sets the day of the month of a date object
		public void setDate(int val) {
			d = d.AddDays(-d.Day + val);
		}

		// sets the year (four digits) of a date object
		public void setFullYear(int val) {
			d = d.AddYears(-d.Year + val);
		}

		// sets the hour of a date object
		public void setHours(int val) {
			d = d.AddHours(-d.Hour + val);
		}

		// sets the milliseconds of a date object
		public void setMilliseconds(int val) {
			d = d.AddMilliseconds(-d.Millisecond + val);
		}

		// set the minutes of a date object
		public void setMinutes(int val) {
			d = d.AddMinutes(-d.Minute + val);
		}

		// sets the month of a date object
		public void setMonth(int val) {
			d = d.AddMonths(-d.Month + val+1);
		}

		// sets the seconds of a date object
		public void setSeconds(int val) {
			d = d.AddSeconds(-d.Second + val);
		}

		// sets a date to a specified number of milliseconds after/before January 1, 1970
		public void setTime(long milliseconds) {
			d = new DateTime(_ticks(milliseconds), DateTimeKind.Utc).ToLocalTime();
		}

		// sets the day of the month of a date object, according to universal time
		public void setUTCDate(int val) {
			DateTime vutc = d.ToUniversalTime();
			d = vutc.AddDays(-vutc.Day + val).ToLocalTime();
		}

		// sets the year of a date object, according to universal time (four digits)
		public void setUTCFullYear(int val) {
			DateTime vutc = d.ToUniversalTime();
			d = vutc.AddYears(-vutc.Year + val).ToLocalTime();
		}

		// sets the year of a date object, according to universal time (four digits)
		public void setUTCHours(int val) {
			DateTime vutc = d.ToUniversalTime();
			d = vutc.AddHours(-vutc.Hour + val).ToLocalTime();
		}

		// sets the milliseconds of a date object, according to universal time
		public void setUTCMilliseconds(int val) {
			DateTime vutc = d.ToUniversalTime();
			d = vutc.AddMilliseconds(-vutc.Millisecond + val).ToLocalTime();
		}

		// set the minutes of a date object, according to universal time
		public void setUTCMinutes(int val) {
			DateTime vutc = d.ToUniversalTime();
			d = vutc.AddMinutes(-vutc.Minute + val).ToLocalTime();
		}

		// sets the month of a date object, according to universal time
		public void setUTCMonth(int val) {
			DateTime vutc = d.ToUniversalTime();
			d = vutc.AddMonths(-vutc.Month + val+1).ToLocalTime();
		}

		// set the seconds of a date object, according to universal time
		public void setUTCSeconds(int val) {
			DateTime vutc = d.ToUniversalTime();
			d = vutc.AddSeconds(-vutc.Second + val).ToLocalTime();
		}

		// converts the date portion of a Date object into a readable string
		public string toDateString() {
			return d.ToString("ddd MMM dd yyyy");
		}

		// returns the date as a string, using the ISO standard
		public string toISOString() {
			return d.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
		}

		// TODO: returns the date as a string, formatted as a JSON date
		public object toJSON() {
			return null;
		}

		// returns the date portion of a Date object as a string, using locale conventions
		public string toLocaleDateString() {
			return d.ToString("dd/mm/yyyy");
		}

		// returns the time portion of a Date object as a string, using locale conventions
		public string toLocateTimeString() {
			return d.ToString("HH:mm:ss");
		}

		// converts a Date object to a string, using locale conventions
		public string toLocaleString() {
			return d.ToString("dd/mm/yyyy, HH:mm:ss");
		}

		// converts a Date object to a string
		public string toString() {
      return d.ToString("ddd MMM dd yyyy HH:mm:ss ") + _utcOffString();
		}

		// converts the time portion of a Date object to a string
		public string toTimeString() {
			return d.ToString("HH:mm:ss ") + _utcOffString();
		}

		// converts a Date object to a string, according to universal time
		public string toUTCString() {
			return d.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss")+" GMT";
		}

		// returns the primitive value of a Date object
		public long valueOf() {
			return getTime();
		}

		// to string
		public override string ToString() {
			return toString();
		}

		// private: get UTC offset string
		private static string _utcOffString() {
			TimeSpan utcOff = TimeZoneInfo.Local.BaseUtcOffset;
			return string.Format("GMT{0}{1} ({2})", utcOff > TimeSpan.Zero ? "+" : "", utcOff.ToString("hhmm"), TimeZoneInfo.Local.StandardName);
		}

		// private: convert ticks to milliseconds since midnight of January 1, 1970
		private static long _millis(long ticks) {
			return (ticks - EPOCH) / MILLIS_TICKS;
		}

		// private: convert milliseconds since midnight of January 1, 1970 to ticks
		private static long _ticks(long milliseconds) {
			return EPOCH + milliseconds * MILLIS_TICKS;
		}
	}
}
