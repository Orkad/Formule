using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class TestFormuleSimple
	{
		//Variable Z = new Variable("Z", 0);
		Var A = new Var("A", 1);
		Var B = new Var("B", 2);
		//Variable C = new Variable("C", 3);

		[TestMethod]
		public void AddResultat()
		{
			Assert.AreEqual((A + A).Resultat, 2);
			Assert.AreEqual((A + B).Resultat, 3);
			Assert.AreEqual((B + A).Resultat, 3);
			Assert.AreEqual((B + B).Resultat, 4);
		}

		[TestMethod]
		public void AddLitterale()
		{
			Assert.AreEqual((A + A).Litterale, "A+A");
			Assert.AreEqual((A + B).Litterale, "A+B");
			Assert.AreEqual((B + A).Litterale, "B+A");
			Assert.AreEqual((B + B).Litterale, "B+B");
		}

		[TestMethod]
		public void AddNumerique()
		{
			Assert.AreEqual((A + A).Numerique, "1+1");
			Assert.AreEqual((A + B).Numerique, "1+2");
			Assert.AreEqual((B + A).Numerique, "2+1");
			Assert.AreEqual((B + B).Numerique, "2+2");
		}

		[TestMethod]
		public void SubResultat()
		{
			Assert.AreEqual((A - A).Resultat, 0);
			Assert.AreEqual((A - B).Resultat, -1);
			Assert.AreEqual((B - A).Resultat, 1);
			Assert.AreEqual((B - B).Resultat, 0);
		}

		[TestMethod]
		public void SubLitterale()
		{
			Assert.AreEqual((A - A).Litterale, "A-A");
			Assert.AreEqual((A - B).Litterale, "A-B");
			Assert.AreEqual((B - A).Litterale, "B-A");
			Assert.AreEqual((B - B).Litterale, "B-B");
		}

		[TestMethod]
		public void SubNumerique()
		{
			Assert.AreEqual((A - A).Numerique, "1-1");
			Assert.AreEqual((A - B).Numerique, "1-2");
			Assert.AreEqual((B - A).Numerique, "2-1");
			Assert.AreEqual((B - B).Numerique, "2-2");
		}

		[TestMethod]
		public void MulResultat()
		{
			Assert.AreEqual((A * A).Resultat, 1);
			Assert.AreEqual((A * B).Resultat, 2);
			Assert.AreEqual((B * A).Resultat, 2);
			Assert.AreEqual((B * B).Resultat, 4);
		}

		[TestMethod]
		public void MulLitterale()
		{
			Assert.AreEqual((A * A).Litterale, "A*A");
			Assert.AreEqual((A * B).Litterale, "A*B");
			Assert.AreEqual((B * A).Litterale, "B*A");
			Assert.AreEqual((B * B).Litterale, "B*B");
		}

		[TestMethod]
		public void MulNumerique()
		{
			Assert.AreEqual((A * A).Numerique, "1*1");
			Assert.AreEqual((A * B).Numerique, "1*2");
			Assert.AreEqual((B * A).Numerique, "2*1");
			Assert.AreEqual((B * B).Numerique, "2*2");
		}

		[TestMethod]
		public void DivResultat()
		{
			Assert.AreEqual((A / A).Resultat, 1);
			Assert.AreEqual((A / B).Resultat, 0.5);
			Assert.AreEqual((B / A).Resultat, 2);
			Assert.AreEqual((B / B).Resultat, 1);
		}

		[TestMethod]
		public void DivLitterale()
		{
			Assert.AreEqual((A / A).Litterale, "A/A");
			Assert.AreEqual((A / B).Litterale, "A/B");
			Assert.AreEqual((B / A).Litterale, "B/A");
			Assert.AreEqual((B / B).Litterale, "B/B");
		}

		[TestMethod]
		public void DivNumerique()
		{
			Assert.AreEqual((A / A).Numerique, "1/1");
			Assert.AreEqual((A / B).Numerique, "1/2");
			Assert.AreEqual((B / A).Numerique, "2/1");
			Assert.AreEqual((B / B).Numerique, "2/2");
		}
	}
}
