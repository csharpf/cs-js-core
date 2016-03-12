using System;
using System.Text;

namespace js {
	
	/// <summary>The String global object is a constructor for strings, or a sequence of characters.</summary>
	public struct String {
		
		#region data
		/// <summary>private: string data</summary>
		private string o;
		#endregion


		#region constructor
		/// <summary>Creates a String wrapper object for a string value</summary>
		/// <param name="value">Optional. The initial value of the String object.</param>
		public String(object value) {
			o = value != null ? value.ToString() : null;
		}
		/// <summary>Creates a String wrapper object for a string value</summary>
		/// <param name="value">Optional. The initial value of the String object.</param>
		public String(string value) {
			o = value;
		}
		#endregion


		#region convert
		/// <summary>Implicitly converts primitive string type to string object</summary>
		/// <param name="value">string value</param>
		public static implicit operator String(string value) {
			return new String(value);
		}
		/// <summary>Implicitly converts Boolean object to primitive string type</summary>
		/// <param name="value">String object</param>
		public static implicit operator string(String value) {
			return value.o;
		}
		public static implicit operator String(char value) {
			return new String(value);
		}
		public static implicit operator char(String value) {
			if (value.Length != 1) throw new InvalidCastException("");
			return value.o[0];
		}
		#endregion


		#region property
		public char this[int index] {
			get { return o[index]; }
		}
		/// <summary>Returns the length of a string</summary>
		public int Length {
			get { return o.Length; }
		}
		#endregion


		#region static method
		/// <summary>Converts Unicode values to characters</summary>
		/// <param name="ns">Required. One or more Unicode values to be converted</param>
		/// <returns>A String, representing the character(s) representing the specified unicode number(s)</returns>
		public static string FromCharCode(params char[] ns) {
			return new string(ns);
		}
		#endregion


		#region method
		/// <summary>Returns the character at the specified index (position)</summary>
		/// <param name="index">Required. An integer representing the index of the character you want to return</param>
		/// <returns>A String, representing the character at the specified index, or an empty string if the index number is not found</returns>
		public String CharAt(int index) {
			return o.Substring(index, 1);
		}


		/// <summary>Returns the Unicode of the character at the specified index</summary>
		/// <param name="index">Required. A number representing the index of the character you want to return</param>
		/// <returns>A Number, representing the unicode of the character at the specified index.</returns>
		public int CharCodeAt(int index) {
			return o[index];
		}


		/// <summary>Joins two or more strings, and returns a new joined strings</summary>
		/// <param name="strings">Required. The strings to be joined</param>
		/// <returns>A new String, containing the text of the combined strings</returns>
		public String Concat(params string[] strings) {
			StringBuilder s = new StringBuilder(o);
			foreach (String str in strings)
				s.Append(str.o);
			return s.ToString();
		}


		/// <summary>Checks whether a string ends with specified string/characters</summary>
		/// <param name="searchvalue">Required. The string to search for</param>
		/// <param name="length">Optional. Specify the length of the string to search. If omitted, the default value is the length of the string</param>
		/// <returns>A Boolean. Returns true if the string ends with the value, otherwise it returns false</returns>
		public bool EndsWith(string searchvalue, int length) {
			return o.Substring(0, length).EndsWith(searchvalue);
		}
		/// <summary>Checks whether a string ends with specified string/characters</summary>
		/// <param name="searchvalue">Required. The string to search for</param>
		/// <returns>A Boolean. Returns true if the string ends with the value, otherwise it returns false</returns>
		public bool EndsWith(string searchvalue) {
			return EndsWith(searchvalue, Length);
		}


		/// <summary></summary>
		/// <param name="searchvalue">Required. The string to search for</param>
		/// <param name="start">Optional. Default 0. At which position to start the search</param>
		/// <returns>A Boolean. Returns true if the string contains the value, otherwise it returns false</returns>
		public bool Includes(string searchvalue, int start=0) {
			return o.Substring(start).Contains(searchvalue);
		}


		/// <summary>Returns the position of the first found occurrence of a specified value in a string</summary>
		/// <param name="searchvalue">Required. The string to search for</param>
		/// <param name="start">Optional. Default 0. At which position to start the search</param>
		/// <returns>A Number, representing the position where the specified searchvalue occurs for the first time, or -1 if it never occurs</returns>
		public int IndexOf(string searchvalue, int start=0) {
			return o.IndexOf(searchvalue, start);
		}


		/// <summary>Returns the position of the last found occurrence of a specified value in a string</summary>
		/// <param name="searchvalue">Required. The string to search for</param>
		/// <param name="start">Optional. The position where to start the search (searching backwards). If omitted, the default value is the length of the string</param>
		/// <returns>A Number, representing the position where the specified searchvalue occurs for the last time, or -1 if it never occurs</returns>
		public int LastIndexOf(string searchvalue, int start) {
			return o.LastIndexOf(searchvalue, start);
		}
		/// <summary>Returns the position of the last found occurrence of a specified value in a string</summary>
		/// <param name="searchvalue">Required. The string to search for</param>
		/// <returns>A Number, representing the position where the specified searchvalue occurs for the last time, or -1 if it never occurs</returns>
		public int LastIndexOf(string searchvalue) {
			return LastIndexOf(searchvalue, Length);
		}

		/// <summary>Converts a boolean value to a string, and returns the result</summary>
		/// <returns>A String, either "true" or "false"</returns>
		public override string ToString() {
			return null;
		}


		/// <summary>Returns the primitive value of a boolean</summary>
		/// <returns>	A Boolean, either "true" or "false"</returns>
		public string ValueOf() {
			return o;
		}
		#endregion
	}
}
