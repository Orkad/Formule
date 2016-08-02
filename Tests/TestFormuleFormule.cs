using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class TestFormulePrio
	{
		//Variable Z = new Variable("Z", 0);
		Var A = new Var("A", 2);
		Var B = new Var("B", 4);
		Var C = new Var("C", 8);
		Var D = new Var("D", 16);

		[TestMethod]
		public void AddSubResultat()
		{
			Assert.AreEqual((A + B - C + D).Resultat, 2 + 4 - 8 + 16);

		}

		[TestMethod]
		public void AddPriorityTest()
		{
			Assert.AreEqual(((A + B) + (C + D)).Litterale, "A+B+C+D");
			Assert.AreEqual(((A - B) + (C - D)).Litterale, "A-B+C-D");
			Assert.AreEqual(((A * B) + (C * D)).Litterale, "A*B+C*D");
			Assert.AreEqual(((A / B) + (C / D)).Litterale, "A/B+C/D");
		}

		[TestMethod]
		public void SubPriorityTest()
		{
			Assert.AreEqual(((A + B) - (C + D)).Litterale, "A+B-(C+D)");
			Assert.AreEqual(((A - B) - (C - D)).Litterale, "A-B-(C-D)");
			Assert.AreEqual(((A * B) - (C * D)).Litterale, "A*B-C*D");
			Assert.AreEqual(((A / B) - (C / D)).Litterale, "A/B-C/D");
		}

		[TestMethod]
		public void MulPriorityTest()
		{
			Assert.AreEqual(((A + B) * (C + D)).Litterale, "(A+B)*(C+D)");
			Assert.AreEqual(((A - B) * (C - D)).Litterale, "(A-B)*(C-D)");
			Assert.AreEqual(((A * B) * (C * D)).Litterale, "A*B*C*D");
			Assert.AreEqual(((A / B) * (C / D)).Litterale, "A/B*C/D");
		}

		[TestMethod]
		public void DivPriorityTest()
		{
			Assert.AreEqual(((A + B) / (C + D)).Litterale, "(A+B)/(C+D)");
			Assert.AreEqual(((A - B) / (C - D)).Litterale, "(A-B)/(C-D)");
			Assert.AreEqual(((A * B) / (C * D)).Litterale, "A*B/(C*D)");
			Assert.AreEqual(((A / B) / (C / D)).Litterale, "A/B/(C/D)");
		}
	}
}
