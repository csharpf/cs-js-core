using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cs_js_lib.type {
	class MathJs {

		/// <summary>Returns Euler's number (approx. 2.718)</summary>
		public static readonly double E = Math.E;
		/// <summary>Returns the natural logarithm of 2 (approx. 0.693)</summary>
		public static readonly double LN2 = Math.Log(2);
		/// <summary>Returns the natural logarithm of 10 (approx. 2.302)</summary>
		public static readonly double LN10 = Math.Log(10);
		/// <summary>Returns the base-2 logarithm of E (approx. 1.442)</summary>
		public static readonly double LOG2E = 1 / Math.Log(2);
		/// <summary>Returns the base-10 logarithm of E (approx. 0.434)</summary>
		public static readonly double LOG10E = 1 / Math.Log(10);
		/// <summary>Returns PI (approx. 3.14)</summary>
		public static readonly double PI = Math.PI;
		/// <summary>Returns the square root of 1/2 (approx. 0.707)</summary>
		public static readonly double SQRT1_2 = 1 / Math.Sqrt(2);
		/// <summary>Returns the square root of 2 (approx. 1.414)</summary>
		public static readonly double SQRT2 = Math.Sqrt(2);


		/// <summary>Returns the absolute value of x</summary>
		/// <param name="x">Required. A number</param>
		/// <returns>A Number, representing the absolute value of the specified number, or NaN if the value is not a number, or 0 if the value is null</returns>
		public static double Abs(double x) { return Math.Abs(x); }

	}
}
