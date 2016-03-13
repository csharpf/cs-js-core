using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace js.test {

	[TestClass()]
	public class Number_test {

		#region prepare
		[TestInitialize()]
		public void _begin() {
			Console.WriteLine("Number_test");
			Console.WriteLine("-----------");
		}

		[TestCleanup()]
		public void _end() {
			Console.WriteLine("\n");
		}
		#endregion

		#region static data
		[TestMethod()]
		public void EPSILON() {
			Assert.AreEqual(Number.EPSILON, 2.220446049250313e-16);
		}

		[TestMethod()]
		public void MAX_SAFE_INTEGER() {
			Assert.AreEqual(Number.MAX_SAFE_INTEGER, 9007199254740991);
		}

		[TestMethod()]
		public void MAX_VALUE() {
			Assert.AreEqual(Number.MAX_VALUE, 1.7976931348623157e+308);
		}

		[TestMethod()]
		public void MIN_SAFE_INTEGER() {
			Assert.AreEqual(Number.MIN_SAFE_INTEGER, -9007199254740991);
		}

		[TestMethod()]
		public void MIN_VALUE() {
			Assert.AreEqual(Number.MIN_VALUE, 5e-324);
		}

		[TestMethod()]
		public void NEGATIVE_INFINITY() {
			Assert.AreEqual(Number.NEGATIVE_INFINITY, -Number.MAX_VALUE * Number.MAX_VALUE);
		}

		[TestMethod()]
		public void NaN() {
			Assert.AreEqual(Number.NaN, 0.0 / 0.0);
		}

		[TestMethod()]
		public void POSITIVE_INFINITY() {
			Assert.AreEqual(Number.POSITIVE_INFINITY, Number.MAX_VALUE * Number.MAX_VALUE);
    }
		#endregion

		#region static method
		[TestMethod()]
		public void isFinite() {
			Console.WriteLine("These all return false.");
			Assert.AreEqual(Number.isFinite(Number.POSITIVE_INFINITY), false);
			Assert.AreEqual(Number.isFinite(Number.NaN), false);
			Assert.AreEqual(Number.isFinite(Number.NEGATIVE_INFINITY), false);
			Console.WriteLine("These all return true.");
			Assert.AreEqual(Number.isFinite(0), true);
			Assert.AreEqual(Number.isFinite(2e+64), true);
			Assert.AreEqual(Number.isFinite(new Number(10)), true);
			Console.WriteLine("These would have been true with global isFinite().");
			Assert.AreEqual(Number.isFinite("0"), false);
			Assert.AreEqual(Number.isFinite(null), false);
		}

		[TestMethod()]
		public void isInteger() {
			Console.WriteLine("These all return true.");
			Assert.AreEqual(Number.isInteger(0), true);
			Assert.AreEqual(Number.isInteger(1), true);
			Assert.AreEqual(Number.isInteger(-100000), true);
			Console.WriteLine("These all return false.");
			Assert.AreEqual(Number.isInteger(0.1), false);
			Assert.AreEqual(Number.isInteger(Math.PI), false);
			Console.WriteLine("These would have been true with global isInteger().");
			Assert.AreEqual(Number.isInteger(Number.POSITIVE_INFINITY), false);
			Assert.AreEqual(Number.isInteger(Number.NEGATIVE_INFINITY), false);
			Assert.AreEqual(Number.isInteger("10"), false);
			Assert.AreEqual(Number.isInteger(true), false);
			Assert.AreEqual(Number.isInteger(false), false);
			Assert.AreEqual(Number.isInteger(new int[] { 1 }), false);
		}

		[TestMethod()]
		public void isNaN() {
			Console.WriteLine("These all return true.");
			Assert.AreEqual(Number.isNaN(double.NaN), true);
			Assert.AreEqual(Number.isNaN(Number.NaN), true);
			Assert.AreEqual(Number.isNaN(0.0 / 0.0), true);
			Assert.AreEqual(Number.isNaN(new Number(0) / new Number(0)), true);
			Console.WriteLine("These would have been true with global isNaN().");
			Assert.AreEqual(Number.isNaN("NaN"), false);
			Assert.AreEqual(Number.isNaN(null), false);
			Assert.AreEqual(Number.isNaN(new Object()), false);
			Assert.AreEqual(Number.isNaN("blabla"), false);
			Console.WriteLine("These all return false.");
			Assert.AreEqual(Number.isNaN(true), false);
			Assert.AreEqual(Number.isNaN(null), false);
			Assert.AreEqual(Number.isNaN(37), false);
			Assert.AreEqual(Number.isNaN("37"), false);
			Assert.AreEqual(Number.isNaN("37.37"), false);
			Assert.AreEqual(Number.isNaN(""), false);
			Assert.AreEqual(Number.isNaN(" "), false);
		}

		[TestMethod()]
		public void isSafeInteger() {
			Assert.AreEqual(Number.isSafeInteger(3), true);
			Assert.AreEqual(Number.isSafeInteger(Math.Pow(2, 53)), false);
			Assert.AreEqual(Number.isSafeInteger(Math.Pow(2, 53) - 1), true);
			Assert.AreEqual(Number.isSafeInteger(Number.NaN), false);
			Assert.AreEqual(Number.isSafeInteger(Number.POSITIVE_INFINITY), false);
			Assert.AreEqual(Number.isSafeInteger('3'), false);
			Assert.AreEqual(Number.isSafeInteger(3.1), false);
			Assert.AreEqual(Number.isSafeInteger(3.0), true);
		}

		[TestMethod()]
		public void parseFloat() {
			Assert.AreEqual(Number.parseFloat("3.14"), 3.14);
			Assert.AreEqual(Number.parseFloat("314e-2"), 3.14);
			Assert.AreEqual(Number.parseFloat("0.0314E+2"), 3.14);
			Assert.AreEqual(Number.parseFloat("3.14more non-digit characters"), 3.14);
			Assert.AreEqual(Number.parseFloat("FF2"), Number.NaN);
		}

		[TestMethod()]
		public void parseInt() {
			Assert.Fail();
		}
		#endregion

		#region method
		[TestMethod()]
		public void toExponential() {
			Assert.Fail();
		}

		[TestMethod()]
		public void toExponential1() {
			Assert.Fail();
		}

		[TestMethod()]
		public void toFixed() {
			Assert.Fail();
		}

		[TestMethod()]
		public void toPrecision() {
			Assert.Fail();
		}

		[TestMethod()]
		public void toString() {
			Assert.Fail();
		}
		#endregion
	}
}