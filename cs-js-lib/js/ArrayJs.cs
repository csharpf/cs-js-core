using System;
using System.Text;


namespace cs_js_lib.type {
	public class ArrayJs<T> {
		/*

		// data
		private T[] Arr;
		private int Off, Len;


		// define an array
		public ArrayJs(int length=0) {
			Arr = new T[length];
			Len = length;
			Off = 0;
		}
		public ArrayJs(params T[] items) : this(items.Length) {
			Array.Copy(items, 0, Arr, Off, Len);
		}
		public ArrayJs(ArrayJs<T> array) : this(array.Len) {
			Array.Copy(array.Arr, array.Off, Arr, Off, Len);
		}


		// automatic typecast
		public static implicit operator T[](ArrayJs<T> src) {
			return (new ArrayJs<T>(src.Arr)).Arr;
		}
		public static implicit operator ArrayJs<T>(T[] src) {
			return new ArrayJs<T>(src);
		}


		// sets or returns the number of elements in an array
		public int Length {
			get { return Len; }
			set { if (value > o.Count) o.AddRange(new T[value - o.Count]); else o.RemoveRange(value, o.Count - value); }
		}

		// joins two or more arrays, and returns a copy of the joined arrays
		public ArrayJs<T> Concat(params ArrayJs<T>[] arrays) {
			int len = 0, off = 0;
			foreach (ArrayJs<T> array in arrays)
				len += array.Length;
			ArrayJs<T> dst = new ArrayJs<T>(len);
			foreach(ArrayJs<T> array in arrays) {
				Array.Copy(array, 0, dst, off, array.Length);
				off += array.Length;
			}
			return dst;
		}

		// copies array elements within the array, to and from specified positions
		public void CopyWithin(int target, int start, int end) {
			Array.Copy(Arr, start, Arr, target, end - start);
		}
		public void CopyWithin(int target, int start) {
			CopyWithin(target, start, Len);
		}

		// checks if every element in an array pass a test
		public bool Every(Func<T, int, ArrayJs<T>, bool> fn) {
			bool ans = true;
			for (int i = 0; i < Len; i++)
				ans = ans && fn(Arr[i], i, this);
			return ans;
		}

		// fill the elements in an array with a static value
		public void Fill(T value, int start, int end) {
			for (int i = start; i < end; i++)
				Arr[i] = value;
		}
		public void Fill(T value, int start=0) {
			Fill(value, start, Len);
		}

		// creates a new array with every element in an array that pass a test
		public ArrayJs<T> Filter(Func<T, int, ArrayJs<T>, bool> fn) {
			ArrayJs<T> dst = new ArrayJs<T>();
			for (int i = 0; i < Len; i++)
				if (fn(Arr[i], i, this)) dst.Push(Arr[i]);
			return dst;
		}

		// returns the value of the first element in an array that pass a test
		public T Find(Func<T, int, ArrayJs<T>, bool> fn) {
			for (int i = 0; i < Len; i++)
				if (fn(Arr[i], i, this)) return Arr[i];
			return default(T);
		}

		// returns the index of the first element in an array that pass a test
		public int FindIndex(Func<T, int, ArrayJs<T>, bool> fn) {
			for (int i = 0; i < Len; i++)
				if (fn(Arr[i], i, this)) return i;
			return -1;
		}

		// calls a function for each array element
		public void ForEach(Action<T, int, ArrayJs<T>> fn) {
			for (int i = 0; i < Len; i++)
				fn(Arr[i], i, this);
		}

		// search the array for an element and returns its position
		public int IndexOf(T item, int start=0) {
			return Array.IndexOf(Arr, item, start);
		}

		// (TODO global object) checks whether an object is an array
		public bool IsArray() {
			return true;
		}

		// joins all elements of an array into a string
		public string Join(string separator=",") {
			StringBuilder str = new StringBuilder();
			for (int i = 0; i < Len; i++)
				str.Append(Arr[i]).Append(separator);
			return str.Remove(str.Length - separator.Length, separator.Length).ToString();
		}

		// search the array for an element, starting at the end, and returns its position
		public int LastIndexOf(T item, int start=0) {
			return Array.LastIndexOf(Arr, item, start);
		}

		// creates a new array with the result of calling a function for each array element
		public ArrayJs<Tr> Map<Tr>(Func<T, int, ArrayJs<T>, Tr> fn) {
			ArrayJs<Tr> dst = new ArrayJs<Tr>(Len);
			for (int i = 0; i < Len; i++)
				dst.Arr[i] = fn(Arr[i], i, this);
			return dst;
		}

		// removes the last element of an array, and returns that element
		public T Pop() {
			return Arr[--Length];
		}

		// TODO: bug here: adds new elements to the end of an array, and returns the new length
		public int Push(params T[] items) {
			Length += items.Length;
			Array.Copy(items, 0, Arr, Len, items.Length);
			return Len;
		}

		// Reduce the values of an array to a single value (going left-to-right)
		public T Reduce(Func<T, T, int, ArrayJs<T>, T> fn, T initialValue=default(T)) {
			T total = initialValue;
			for (int i = 0; i < Len; i++)
				total = fn(total, Arr[i], i, this);
			return total;
		}

		// Reduce the values of an array to a single value (going left-to-right)
		public T ReduceRight(Func<T, T, int, ArrayJs<T>, T> fn, T initialValue = default(T)) {
			T total = initialValue;
			for (int i = Len - 1; i >= 0; i--)
				total = fn(total, Arr[i], i, this);
			return total;
		}

		// Reverses the order of the elements in an array
		public ArrayJs<T> Reverse() {
			ArrayJs<T> dst = new ArrayJs<T>(Arr);
			Array.Reverse(dst.Arr);
			return dst;
		}

		// Removes the first element of an array, and returns that element
		public T Shift() {
			return default(T);
		}

		// Selects a part of an array, and returns the new array
		public ArrayJs<T> Slice() {
			return null;
		}

		// Checks if any of the elements in an array pass a test
		public bool Some() {
			return false;
		}

		// Sorts the elements of an array
		public void Sort() {
		}

		// Adds/Removes elements from an array
		public void Splice() {

		}

		// Adds new elements to the beginning of an array, and returns the new length
		public void Unshift() {

		}

		// Returns the primitive value of an array
		public void ValueOf() {

		}

		// Converts an array to a string, and returns the result
		public override string ToString() {
			StringBuilder str = new StringBuilder();
			for(int i=0; i<o.Count; i++) 
				str.Append(o[i]).Append(',');
			return str.Remove(str.Length - 1, 1).ToString();
		}
		*/
	}
}
