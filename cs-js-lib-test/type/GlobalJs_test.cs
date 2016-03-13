using Microsoft.VisualStudio.TestTools.UnitTesting;
using js.web;

namespace cs_js_lib.type.test {

	[TestClass()]
	public class Window_test {


		[TestMethod()]
		public void DecodeURI() {
			string uri = "my test.asp?name=ståle&car=saab";
			string enc = Window.encodeURI(uri);
			string dec = Window.decodeURI(uri);
			Assert.AreEqual(dec, uri);
		}


		[TestMethod()]
		public void DecodeURIComponent() {
			var uri = "http://w3schools.com/my test.asp?name=ståle&car=saab";
			var enc = Window.encodeURIComponent(uri);
			var dec = Window.decodeURIComponent(enc);
			Assert.AreEqual(dec, uri);
		}


		[TestMethod()]
		public void EncodeURI() {
			string uri = "my test.asp?name=ståle&car=saab";
			string enc = Window.encodeURI(uri);
			Assert.AreEqual(enc, "my%20test.asp?name=st%C3%A5le&car=saab");
		}


		[TestMethod()]
		public void EncodeURIComponent() {
			var uri = "http://w3schools.com/my test.asp?name=ståle&car=saab";
			var enc = Window.encodeURIComponent(uri);
			Assert.AreEqual(enc, "http%3A%2F%2Fw3schools.com%2Fmy%20test.asp%3Fname%3Dst%C3%A5le%26car%3Dsaab");
		}


		[TestMethod()]
		public void IsFinite() {
			Assert.Fail();
		}


		[TestMethod()]
		public void IsNaN() {
			Assert.Fail();
		}


		[TestMethod()]
		public void ParseFloat() {
			Assert.AreEqual(Window.parseFloat("10"), 10.0);
			Assert.AreEqual(Window.parseFloat("10.00"), 10.0);
			Assert.AreEqual(Window.parseFloat("10.33"), 10.33);
			Assert.AreEqual(Window.parseFloat("34 45 66"), 34.0);
			Assert.AreEqual(Window.parseFloat(" 60 "), 60.0);
			Assert.AreEqual(Window.parseFloat("40 years"), 40.0);
			Assert.AreEqual(Window.parseFloat("He was 40"), double.NaN);
		}


		[TestMethod()]
		public void ParseInt() {
			Assert.Fail();
		}
	}
}