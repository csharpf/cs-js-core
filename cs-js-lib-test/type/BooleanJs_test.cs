/// BOOLEAN TEST - Unit test for Boolean
using System;
using cs_js_lib.type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cs_js_lib_test.type {
	
	[TestClass]
	public class BooleanJs_test {

		[TestMethod]
		public void BooleanJs() {
			Assert.AreEqual(false, new BooleanJs());
			Assert.AreEqual(false, new BooleanJs(0));
			Assert.AreEqual(false, new BooleanJs(null));
			Assert.AreEqual(false, new BooleanJs(""));
			Assert.AreEqual(false, new BooleanJs(false));
			Assert.AreEqual(true, new BooleanJs(true));
			Assert.AreEqual(true, new BooleanJs("true"));
			Assert.AreEqual(true, new BooleanJs("false"));
			Assert.AreEqual(true, new BooleanJs("Su Lin"));
			Assert.AreEqual(true, new BooleanJs(new int[0]));
			Assert.AreEqual(true, new BooleanJs(new object()));
			Assert.AreEqual(true, new BooleanJs(10 > 9));
		}


		[TestMethod]
		public new void ToString() {
			Assert.AreEqual("true", new BooleanJs(true).ToString());
		}


		[TestMethod]
		public void ValueOf() {
			Assert.AreEqual(false, new BooleanJs(false).ValueOf());
		}
	}
}
