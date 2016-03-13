using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace js.test {

	[TestClass()]
	public class Number_test {

		[TestMethod()]
		public void isNaN() {
			try {
				// These are return true
				Assert.AreEqual(true, Number.isNaN(double.NaN));
				Assert.AreEqual(true, Number.isNaN(Number.NaN));
				Assert.AreEqual(true, Number.isNaN(0.0 / 0.0));
				Assert.AreEqual(true, Number.isNaN(new Number(0) / new Number(0)));
				// These would have been true with global isNaN()
				Assert.AreEqual(false, Number.isNaN("NaN"));
				Assert.AreEqual(false, Number.isNaN(null));
				Assert.AreEqual(false, Number.isNaN(new Object()));
				Assert.AreEqual(false, Number.isNaN("blabla"));
				// These all return false
				Assert.AreEqual(false, Number.isNaN(true));
				Assert.AreEqual(false, Number.isNaN(null));
				Assert.AreEqual(false, Number.isNaN(37));
				Assert.AreEqual(false, Number.isNaN("37"));
				Assert.AreEqual(false, Number.isNaN("37.37"));
				Assert.AreEqual(false, Number.isNaN(""));
				Assert.AreEqual(false, Number.isNaN(" "));
			}
			catch (Exception) { Assert.Fail(); }
		}

		[TestMethod()]
		public void isFinite() {
			Assert.Fail();
		}

		[TestMethod()]
		public void isInteger() {
			Assert.Fail();
		}

		[TestMethod()]
		public void isSafeInteger() {
			Assert.Fail();
		}

		[TestMethod()]
		public void parseFloat() {
			Assert.Fail();
		}

		[TestMethod()]
		public void parseInt() {
			Assert.Fail();
		}

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
	}
}