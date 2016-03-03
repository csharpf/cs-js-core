using System;
using cs_js_lib.type;


namespace cs_js_lib {
	class Program {
		static void Main(string[] args) {
			ArrayJs<int> a = new ArrayJs<int>();
			a.Length = 10;
			a.Length = 5;
			Console.WriteLine(a);
			Console.ReadKey();
		}
	}
}
