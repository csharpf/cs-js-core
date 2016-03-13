using System;


namespace js {

	/// <summary>The Number JavaScript object is a wrapper object allowing you to work with numerical values.</summary>
	public class Number : Object {

		#region static data
		/// <summary>The smallest interval between two representable numbers.</summary>
		public static readonly double EPSILON = double.Epsilon;
		/// <summary>The maximum safe integer in JavaScript (2^53 - 1).</summary>
		public static readonly double MAX_SAFE_INTEGER = Math.Pow(2, 53) - 1;
		/// <summary>The largest positive representable number.</summary>
		public static readonly double MAX_VALUE = double.MaxValue;
		/// <summary>The minimum safe integer in JavaScript (-(2^53 - 1)).</summary>
		public static readonly double MIN_SAFE_INTEGER = -(Math.Pow(2, 53) - 1);
		/// <summary>The smallest positive representable number - that is, the positive number closest to zero (without actually being zero).</summary>
		public static readonly double MIN_VALUE = double.MinValue;
		/// <summary>Special "not a number" value.</summary>
		public static readonly double NaN = double.NaN;
		/// <summary>Special value representing negative infinity; returned on overflow.</summary>
		public static readonly double NEGATIVE_INFINITY = double.NegativeInfinity;
		/// <summary>Special value representing infinity; returned on overflow.</summary>
		public static readonly double POSITIVE_INFINITY = double.PositiveInfinity;
		#endregion


		#region data
		/// <summary>Internal value.</summary>
		private double o;
		#endregion


		#region static method
		/// <summary>Determine whether the passed value is NaN.</summary>
		/// <param name="value">The value to be tested for NaN.</param>
		/// <returns>Boolean indicating whether value is NaN.</returns>
		public static bool isNaN(object value) {
			if(value is Number) return double.IsNaN(((Number)value).o);
			return value is double || value is float ? isNaN((double)value) : false;
		}


		/// <summary>Determine whether the passed value is a finite number.</summary>
		/// <param name="value">The value to be tested for finiteness.</param>
		/// <returns>Boolean indicating whether value is a finite number.</returns>
		public static bool isFinite(object value) {
			if (value is Number) return !double.IsInfinity(((Number)value).o);
			return value is double || value is float ? isFinite((double)value) : false;
		}


		/// <summary>Determine whether the passed value is an integer.</summary>
		/// <param name="value">The value to be tested for being an integer.</param>
		/// <returns>Boolean indicating whether the target value is an integer (not NaN or infinite).</returns>
		public static bool isInteger(object value) {
			if (value is int || value is long || value is short || value is byte) return true;
			return isSafeInteger(value);
		}


		/// <summary>Determine whether the passed value is a safe integer (number between -(253 - 1) and 253 - 1).</summary>
		/// <param name="value">The value to be tested for being a safe integer.</param>
		/// <returns>Boolean indicating whether the provided value is a number that is a safe integer.</returns>
		public static bool isSafeInteger(object value) {
			if (value is Number) return (int)((Number)value).o == ((Number)value).o;
			return value is double || value is float || value is int || value is long || value is short || value is byte ? isSafeInteger(new Number((double)value)) : false;
		}


		/// <summary>Parses a string argument and returns a floating point number.</summary>
		/// <param name="str">A string that represents the value you want to parse.</param>
		/// <returns>Floating-point number representaion of the string, or NaN if the first character cannot be converted to a number.</returns>
		public static Number parseFloat(string str) {
			double val = double.NaN;
			double.TryParse(str, out val);
			return new Number(val);
		}


		/// <summary>Parses a string argument and returns an integer of the specified radix or base.</summary>
		/// <param name="str">
		///		The value to parse. If string is not a string, then it is converted to a string (using the
		///		ToString abstract operation). Leading whitespace in the string is ignored.
		/// </param>
		/// <param name="radix">
		///		An integer between 2 and 36 that represents the radix (the base in mathematical numeral
		///		systems) of the above mentioned string. Specify 10 for the decimal numeral system
		///		commonly used by humans. Always specify this parameter to eliminate reader confusion
		///		and to guarantee predictable behavior. Different implementations produce different results
		///		when a radix is not specified, usually defaulting the value to 10.
		/// </param>
		/// <returns></returns>
		public static Number parseInt(string str, int radix=10) {
			int val = int.MinValue;
			if(!int.TryParse(str, out val)) return Number.NaN;
			return val;
		}
		#endregion


		#region constructor
		public Number(double value) {
			o = value;
		}
		#endregion


		#region typecast
		public static implicit operator Number(double value) {
			return new Number(value);
		}

		public static implicit operator double(Number value) {
			return value.o;
		}

		public static implicit operator float(Number value) {
			return (float)value.o;
		}

		public static implicit operator long (Number value) {
			return (long)value.o;
		}

		public static implicit operator int(Number value) {
			return (int)value.o;
		}
		#endregion


		#region method
		/// <summary>Returns a string representing the number in exponential notation.</summary>
		/// <param name="fractionDigits">Optional. An integer specifying the number of digits after the decimal point. Defaults to as many digits as necessary to specify the number.</param>
		/// <returns>String of number in exponential form.</returns>
		public string toExponential(int fractionDigits) {
			return o.ToString("e" + fractionDigits);
		}
		/// <summary>Returns a string representing the number in exponential notation.</summary>
		/// <returns>String of number in exponential form.</returns>
		public string toExponential() {
			return o.ToString("e");
		}


		/// <summary>Formats a number using fixed-point notation.</summary>
		/// <param name="digits">Optional. The number of digits to appear after the decimal point; this may be a value between 0 and 20, inclusive, and implementations may optionally support a larger range of values. If this argument is omitted, it is treated as 0.</param>
		/// <returns>String of number in fixed-point notation.</returns>
		public string toFixed(int digits=0) {
			return o.ToString("f" + digits);
		}


		/// <summary>Returns a string representing the Number object to the specified precision.</summary>
		/// <param name="precision">Optional. An integer specifying the number of significant digits.</param>
		/// <returns>String of number in specified precision.</returns>
		public string toPrecision(int precision=6) {
			return o.ToString("g" + precision);
		}

		public override string toString() {
			return o.ToString();
		}
		#endregion
	}
}
