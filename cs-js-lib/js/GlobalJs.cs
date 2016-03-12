using System;


namespace cs_js_lib.type {
	public class GlobalJs {


		/// <summary>Decodes a URI</summary>
		/// <param name="uri">Required. The URI to be decoded</param>
		/// <returns>A String, representing the decoded URI</returns>
		public static string DecodeURI(string uri) {
			return Uri.UnescapeDataString(uri);
		}


		/// <summary>Decodes a URI component</summary>
		/// <param name="uri">Required. The URI to be decoded</param>
		/// <returns>A String, representing the decoded URI</returns>
		public static string DecodeURIComponent(string uri) {
			return Uri.UnescapeDataString(uri);
		}


		/// <summary>Encodes a URI</summary>
		/// <param name="uri">Required. The URI to be encoded</param>
		/// <returns>A String, representing the encoded URI</returns>
		public static string EncodeURI(string uri) {
			return Uri.EscapeUriString(uri);
		}


		/// <summary>Encodes a URI component</summary>
		/// <param name="uri">Required. The URI to be encoded</param>
		/// <returns>A String, representing the encoded URI</returns>
		public static string EncodeURIComponent(string uri) {
			return Uri.EscapeDataString(uri);
		}


		// TODO: eval


		/// <summary>Determines whether a value is a finite, legal number</summary>
		/// <param name="value">Required. The value to be tested</param>
		/// <returns>A Boolean. Returns false if the value is +infinity, -infinity, or NaN, otherwise it returns true.</returns>
		public static bool IsFinite(double value) {
			return !(double.IsInfinity(value) || double.IsNaN(value));
		}


		/// <summary>Determines whether a value is an illegal number</summary>
		/// <param name="value">Required. The value to be tested</param>
		/// <returns>A Boolean. Returns true if the value is NaN, otherwise it returns false</returns>
		public static bool IsNaN(double value) {
			return double.IsNaN(value);
		}


		/// <summary>Parses a string and returns a floating point number</summary>
		/// <param name="str">Required. The string to be parsed</param>
		/// <returns>A Number. If the first character cannot be converted to a number, NaN is returned</returns>
		public static double ParseFloat(string str) {
			double o = double.NaN;
			double.TryParse(str, out o);
			return o;
		}


		/// <summary>Parses a string and returns an integer</summary>
		/// <param name="str">Required. The string to be parsed</param>
		/// <param name="radix">Optional. A number (from 2 to 36) that represents the numeral system to be used</param>
		/// <returns>A Number. If the first character cannot be converted to a number, MinValue is returned</returns>
		public static double ParseInt(string str, int radix=10) {
			int o = int.MinValue;
			return o;
		}
	}
}
