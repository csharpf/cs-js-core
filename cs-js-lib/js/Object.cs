using System.Text;
using System.Collections;
using System.Collections.Generic;
using Map = System.Collections.Generic.Dictionary<string, js.Object>;
using Pair = System.Collections.Generic.KeyValuePair<string, js.Object>;


namespace js {

	/// <summary>The Object constructor creates an object wrapper.</summary>
	public class Object : Map, IEnumerable {

		#region property
		/// <summary>Get value stored in a key.</summary>
		/// <param name="key">Key.</param>
		/// <returns>Value.</returns>
		public Object this[object key] {
			get { return this[key.ToString()]; }
			set { this[key.ToString()] = value; }
		}


		/// <summary>
		/// Returns a reference to the Object function that created the instance's prototype. Note that the
		/// value of this property is a reference to the function itself, not a string containing the function's
		/// name. The value is only read-only for primitive values such as 1, true and "test".
		/// </summary>
		public object constructor {
			get { return null; }
		}
		#endregion


		#region static method
		/// <summary>Returns an array of a given object's own enumerable properties, in the same order as that provided by a for...in loop (the difference being that a for-in loop enumerates properties in the prototype chain as well).</summary>
		/// <returns>Array whose elements are strings corresponding to the enumerable properties found directly upon object.</returns>
		public static string[] keys(Object obj) {
			return null;
		}
		#endregion


		#region method
		/// <summary>The Object constructor creates an object wrapper for the given value</summary>
		/// <param name="value">Optional. If the value is null or undefined, it will create and return an empty object, otherwise, it will return an object of a Type that corresponds to the given value. If the value is an object already, it will return the value.</param>
		public Object(object value=null) {
			// Add("[[PrimitiveValue]]", value);
		}
		/// <summary>The Object constructor creates an object wrapper for the given value</summary>
		/// <param name="nameValuePairs">Pairs of names (strings) and values (any value) where the name is separated from the value by a colon.</param>
		public Object(params Pair[] nameValuePairs) {
			foreach (Pair pair in nameValuePairs)
				Add(pair.Key, pair.Value);
		}


		/// <summary>Returns a boolean indicating whether the object has the specified property.</summary>
		/// <param name="prop">The name of the property to test</param>
		/// <returns>Boolean indicating whether an object contains the specified property as a direct property of that object and not inherited through the prototype chain</returns>
		public bool hasOwnProperty(string prop) {
			return propertyIsEnumerable(prop);
		}


		/// <summary>Tests for an object in another object's prototype chain.</summary>
		/// <param name="obj">The object whose prototype chain will be searched</param>
		/// <returns>Boolean indicating whether an object contains the specified property as a direct property of that object and not inherited through the prototype chain</returns>
		public bool isPrototypeOf(Object obj) {
			for (; obj != null && obj.hasOwnProperty("prototype"); obj = obj["prototype"])
				if (obj == this) return true;
			return false;
		}


		/// <summary>Returns a Boolean indicating whether the specified property is enumerable.</summary>
		/// <param name="prop">The name of the property to test</param>
		/// <returns>Boolean indicating whether the specified property is enumerable</returns>
		public bool propertyIsEnumerable(string prop) {
			return ContainsKey(prop);
		}


		/// <summary>Returns a string representing the object. This method is meant to be overridden by derived objects for locale-specific purposes.</summary>
		/// <returns>Calls toString()</returns>
		public virtual string ToLocaleString() {
			return toString();
		}


		/// <summary>Returns a string representing object.</summary>
		/// <returns>String representation of the object</returns>
		public virtual string toString() {
			StringBuilder str = new StringBuilder('{');
			foreach (string key in this)
				str.AppendFormat("{0}: {1}, ", key, this[key]);
			if(str.Length > 1) str.Remove(str.Length - 2, 2);
			return str.Append('}').ToString();
		}
		/// <summary>Returns a string representing object.</summary>
		/// <returns>String representation of the object</returns>
		public override string ToString() {
			return toString();
		}


		/// <summary>Returns the primitive value of the specified object.</summary>
		/// <returns>Primitive value of the specified object</returns>
		public object valueOf() {
			return this;
		}


		/// <summary>Returns keys in an object that can be used in a for..in loop</summary>
		/// <returns>Enumerated keys</returns>
		public new IEnumerator<string> GetEnumerator() {
			foreach (string key in Keys)
				yield return key;
		}
		/// <summary>Returns keys in an object that can be used in a for..in loop</summary>
		/// <returns>Enumerated keys</returns>
		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
		#endregion
	}
}
