using System;
using cs_js_lib.type;


namespace cs_js_lib {
	class Program {
		static void Main(string[] args) {
			var date = new Date();
			Console.WriteLine(Date.now());
			Console.WriteLine(new Date(Date.now()).ToString());
			Console.WriteLine(new Date(Date.now()).getTime());
			Console.ReadKey();
		}
	}
}
