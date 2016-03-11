/// BOOLEAN - The Boolean object is an object wrapper for a boolean value
using System;

namespace cs_js_lib.type {

	/// <summary>The Boolean object is an object wrapper for a boolean value.</summary>
	struct BooleanJs {

		#region data
		/// <summary>private: boolean data</summary>
		private bool o;
		#endregion


		#region constructor
		/// <summary>Creates a Boolean wrapper object for a boolean value</summary>
		/// <param name="value">Optional. The initial value of the Boolean object.</param>
		public BooleanJs(object value) {
			o = value != null ? true : false;
		}
		/// <summary>Creates a Boolean wrapper object for a boolean value</summary>
		/// <param name="value">Optional. The initial value of the Boolean object.</param>
		public BooleanJs(string value) {
			o = value.Length > 0 ? true : false;
		}
		/// <summary>Creates a Boolean wrapper object for a boolean value</summary>
		/// <param name="value">Optional. The initial value of the Boolean object.</param>
		public BooleanJs (double value) {
			o = value != 0 ? true : false;
		}
		/// <summary>Creates a Boolean wrapper object for a boolean value</summary>
		/// <param name="value">Optional. The initial value of the Boolean object.</param>
		public BooleanJs(long value) {
			o = value != 0 ? true : false;
		}
		/// <summary>Creates a Boolean wrapper object for a boolean value</summary>
		/// <param name="value">Optional. The initial value of the Boolean object.</param>
		public BooleanJs(bool value=false) {
			o = value;
		}
		#endregion


		#region convert
		/// <summary>Implicitly converts Boolean object to primitive boolean type</summary>
		/// <param name="value">Boolean object</param>
		public static implicit operator bool(BooleanJs value) {
			return value.o;
		}
		#endregion


		#region method
		/// <summary>Converts a boolean value to a string, and returns the result</summary>
		/// <returns>A String, either "true" or "false"</returns>
		public override String ToString() {
			return o ? "true" : "false";
		}


		/// <summary>Returns the primitive value of a boolean</summary>
		/// <returns>	A Boolean, either "true" or "false"</returns>
		public bool ValueOf() {
			return o;
		}
		#endregion
	}
}
