using Microsoft.VisualStudio.TestTools.UnitTesting;
using Map = System.Collections.Generic.Dictionary<string, js.Object>;


namespace js.test {

	[TestClass()]
	public class Object_test {

		[TestMethod()]
		public void Object() {
			Assert.IsTrue(new Object().valueOf() is Map);
			Assert.IsTrue(new Object().valueOf() is Map);
		}
	}
}