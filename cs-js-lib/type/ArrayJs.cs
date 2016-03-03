using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace cs_js_lib.type {
	public class ArrayJs<T> {
		
		// internal list
		private List<T> o;
	
		// define an array
		public ArrayJs(int length=0) : this(new T[length]) { }
		public ArrayJs(IEnumerable<T> values) {
			o = new List<T>(values);
		}

		// automatic typecast
		public static implicit operator List<T>(ArrayJs<T> src) {
			return src.o;
		}
		public static implicit operator T[](ArrayJs<T> src) {
			return src.o.ToArray();
		}
		public static implicit operator ArrayJs<T>(List<T> src) {
			return new ArrayJs<T>(src);
		}
		public static implicit operator ArrayJs<T>(T[] src) {
			return new ArrayJs<T>(src);
		}

		// sets or returns the number of elements in an array
		public int Length {
			get { return o.Count; }
			set { if (value > o.Count) o.AddRange(new T[value - o.Count]); else o.RemoveRange(value, o.Count - value); }
		}

		// joins two or more arrays, and returns a copy of the joined arrays
		public ArrayJs<T> Concat(ArrayJs<T> src) {
			ArrayJs<T> dst = new ArrayJs<T>(o);
			dst.o.AddRange(src.o);
			return dst;
		}

		// copies array elements within the array, to and from specified positions
		public void CopyWithin(int target, int start, int end=-1) {
			// ?
		}

		// checks if every element in an array pass a test
		public bool Every(Func<T, int, ArrayJs<T>, bool> fn) {
			bool ans = true;
			for (int i = 0; i < o.Count; i++)
				ans = ans && fn(o[i], i, this);
			return ans;
		}

		// fill the elements in an array with a static value
		public void Fill(T value, int start=0, int end=-1) {
			for (int i = start, I = end < 0 ? o.Count : end; i < I; i++)
				o[i] = value;
		}

		// creates a new array with every element in an array that pass a test
		public ArrayJs<T> Filter(Func<T, int, ArrayJs<T>, bool> fn) {
			ArrayJs<T> dst = new ArrayJs<T>();
			for (int i = 0; i < o.Count; i++)
				if (fn(o[i], i, this)) dst.o.Add(o[i]);
			return dst;
		}

		// returns the value of the first element in an array that pass a test
		public T Find(Func<T, int, ArrayJs<T>, bool> fn) {
			for (int i = 0; i < o.Count; i++)
				if (fn(o[i], i, this)) return o[i];
			return default(T);
		}

		// returns the index of the first element in an array that pass a test
		public int FindIndex(Func<T, int, ArrayJs<T>, bool> fn) {
			for (int i = 0; i < o.Count; i++)
				if (fn(o[i], i, this)) return i;
			return -1;
		}

		// calls a function for each array element
		public void ForEach(Action<T, int, ArrayJs<T>> fn) {
			for (int i = 0; i < o.Count; i++)
				fn(o[i], i, this);
		}

		// search the array for an element and returns its position
		public int IndexOf(T item, int start=0) {
			return o.IndexOf(item, start);
		}

		// (TODO global object) checks whether an object is an array
		public bool IsArray() {
			return true;
		}

		// joins all elements of an array into a string
		public string Join(string separator=",") {
			StringBuilder str = new StringBuilder();
			for (int i = 0; i < o.Count; i++)
				str.Append(o[i]).Append(separator);
			return str.Remove(str.Length - separator.Length, separator.Length).ToString();
		}

		// search the array for an element, starting at the end, and returns its position
		public int LastIndexOf() {
			return -1;
		}
		/*
lastIndexOf()	Search the array for an element, starting at the end, and returns its position
map()	Creates a new array with the result of calling a function for each array element
pop()	Removes the last element of an array, and returns that element
push()	Adds new elements to the end of an array, and returns the new length
reduce()	Reduce the values of an array to a single value (going left-to-right)
reduceRight()	Reduce the values of an array to a single value (going right-to-left)
reverse()	Reverses the order of the elements in an array
shift()	Removes the first element of an array, and returns that element
slice()	Selects a part of an array, and returns the new array
some()	Checks if any of the elements in an array pass a test
sort()	Sorts the elements of an array
splice()	Adds/Removes elements from an array
toString()	Converts an array to a string, and returns the result
unshift()	Adds new elements to the beginning of an array, and returns the new length
valueOf()	Returns the primitive value of an array
		*/

		// 
		public override string ToString() {
			StringBuilder str = new StringBuilder();
			for(int i=0; i<o.Count; i++) 
				str.Append(o[i]).Append(',');
			return str.Remove(str.Length - 1, 1).ToString();
		}
	}
}
