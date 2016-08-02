using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	/// <summary>
	/// Description résumée pour TestFormuleComplexe
	/// </summary>
	[TestClass]
	public class TestFormuleVariable
	{
		//private readonly Variable Z = new Variable("Z", 0);
		private readonly Var A = new Var("A", 2);
		private readonly Var B = new Var("B", 4);
		private readonly Var C = new Var("C", 8);

		// -------------------- ADD ADD ---------------------

		[TestMethod]
		public void AddAddResultat()
		{
			Assert.AreEqual((A + B + C).Resultat, 2 + 4 + 8);
			Assert.AreEqual(((A + B) + C).Resultat, (2 + 4) + 8);
			Assert.AreEqual((A + (B + C)).Resultat, 2 + (4 + 8));
		}

		[TestMethod]
		public void AddAddLitterale()
		{
			Assert.AreEqual((A + B + C).Litterale, "A+B+C");
			Assert.AreEqual(((A + B) + C).Litterale, "A+B+C");
			Assert.AreEqual((A + (B + C)).Litterale, "A+B+C");
		}

		[TestMethod]
		public void AddAddNumerique()
		{
			Assert.AreEqual((A + B + C).Numerique, "2+4+8");
			Assert.AreEqual(((A + B) + C).Numerique, "2+4+8");
			Assert.AreEqual((A + (B + C)).Numerique, "2+4+8");
		}

		// -------------------- ADD SUB ---------------------

		[TestMethod]
		public void AddSubResultat()
		{
			Assert.AreEqual((A + B - C).Resultat, 2 + 4 - 8);
			Assert.AreEqual(((A + B) - C).Resultat, (2 + 4) - 8);
			Assert.AreEqual((A + (B - C)).Resultat, 2 + (4 - 8));
		}

		[TestMethod]
		public void AddSubLitterale()
		{
			Assert.AreEqual((A + B - C).Litterale, "A+B-C");
			Assert.AreEqual(((A + B) - C).Litterale, "A+B-C");
			Assert.AreEqual((A + (B - C)).Litterale, "A+B-C");
		}

		[TestMethod]
		public void AddSubNumerique()
		{
			Assert.AreEqual((A + B - C).Numerique, "2+4-8");
			Assert.AreEqual(((A + B) - C).Numerique, "2+4-8");
			Assert.AreEqual((A + (B - C)).Numerique, "2+4-8");
		}

		// -------------------- ADD MUL ---------------------

		[TestMethod]
		public void AddMulResultat(){
			Assert.AreEqual((A + B * C).Resultat, 2 + 4 * 8);
			Assert.AreEqual(((A + B) * C).Resultat, (2 + 4) * 8);
			Assert.AreEqual((A + (B * C)).Resultat, 2 + (4 * 8));
		}

		[TestMethod]
		public void AddMulLitterale()
		{
			Assert.AreEqual((A + B * C).Litterale, "A+B*C");
			Assert.AreEqual(((A + B) * C).Litterale, "(A+B)*C");
			Assert.AreEqual((A + (B * C)).Litterale, "A+B*C");
		}

		[TestMethod]
		public void AddMulNumerique()
		{
			Assert.AreEqual((A + B * C).Numerique, "2+4*8");
			Assert.AreEqual(((A + B) * C).Numerique, "(2+4)*8");
			Assert.AreEqual((A + (B * C)).Numerique, "2+4*8");
		}

		// -------------------- ADD DIV ---------------------

		[TestMethod]
		public void AddDivResultat()
		{
			Assert.AreEqual((A + B / C).Resultat, 2 + 4 / 8.0);
			Assert.AreEqual(((A + B) / C).Resultat, (2 + 4) / 8.0);
			Assert.AreEqual((A + (B / C)).Resultat, 2 + (4 / 8.0));
		}

		[TestMethod]
		public void AddDivLitterale()
		{
			Assert.AreEqual((A + B / C).Litterale, "A+B/C");
			Assert.AreEqual(((A + B) / C).Litterale, "(A+B)/C");
			Assert.AreEqual((A + (B / C)).Litterale, "A+B/C");
		}

		[TestMethod]
		public void AddDivNumerique()
		{
			Assert.AreEqual((A + B / C).Numerique, "2+4/8");
			Assert.AreEqual(((A + B) / C).Numerique, "(2+4)/8");
			Assert.AreEqual((A + (B / C)).Numerique, "2+4/8");
		}

		// -------------------- SUB ADD ---------------------

		[TestMethod]
		public void SubAddResultat()
		{
			Assert.AreEqual((A - B + C).Resultat, 2 - 4 + 8);
			Assert.AreEqual(((A - B) + C).Resultat, (2 - 4) + 8);
			Assert.AreEqual((A - (B + C)).Resultat, 2 - (4 + 8));
		}

		[TestMethod]
		public void SubAddLitterale()
		{
			Assert.AreEqual((A - B + C).Litterale, "A-B+C");
			Assert.AreEqual(((A - B) + C).Litterale, "A-B+C");
			Assert.AreEqual((A - (B + C)).Litterale, "A-(B+C)");
		}

		[TestMethod]
		public void SubAddNumerique()
		{
			Assert.AreEqual((A - B + C).Numerique, "2-4+8");
			Assert.AreEqual(((A - B) + C).Numerique, "2-4+8");
			Assert.AreEqual((A - (B + C)).Numerique, "2-(4+8)");
		}

		// -------------------- SUB SUB ---------------------

		[TestMethod]
		public void SubSubResultat()
		{
			Assert.AreEqual((A - B - C).Resultat, 2 - 4 - 8);
			Assert.AreEqual(((A - B) - C).Resultat, (2 - 4) - 8);
			Assert.AreEqual((A - (B - C)).Resultat, 2 - (4 - 8));
		}

		[TestMethod]
		public void SubSubLitterale()
		{
			Assert.AreEqual((A - B - C).Litterale, "A-B-C");
			Assert.AreEqual(((A - B) - C).Litterale, "A-B-C");
			Assert.AreEqual((A - (B - C)).Litterale, "A-(B-C)");
		}

		[TestMethod]
		public void SubSubNumerique()
		{
			Assert.AreEqual((A - B - C).Numerique, "2-4-8");
			Assert.AreEqual(((A - B) - C).Numerique, "2-4-8");
			Assert.AreEqual((A - (B - C)).Numerique, "2-(4-8)");
		}

		// -------------------- SUB MUL ---------------------

		[TestMethod]
		public void SubMulResultat()
		{
			Assert.AreEqual((A - B * C).Resultat, 2 - 4 * 8);
			Assert.AreEqual(((A - B) * C).Resultat, (2 - 4) * 8);
			Assert.AreEqual((A - (B * C)).Resultat, 2 - (4 * 8));
		}

		[TestMethod]
		public void SubMulLitterale()
		{
			Assert.AreEqual((A - B * C).Litterale, "A-B*C");
			Assert.AreEqual(((A - B) * C).Litterale, "(A-B)*C");
			Assert.AreEqual((A - (B * C)).Litterale, "A-B*C");
		}

		[TestMethod]
		public void SubMulNumerique()
		{
			Assert.AreEqual((A - B * C).Numerique, "2-4*8");
			Assert.AreEqual(((A - B) * C).Numerique, "(2-4)*8");
			Assert.AreEqual((A - (B * C)).Numerique, "2-4*8");
		}

		// -------------------- SUB DIV ---------------------

		[TestMethod]
		public void SubDivResultat()
		{
			Assert.AreEqual((A - B / C).Resultat, 2 - 4 / 8.0);
			Assert.AreEqual(((A - B) / C).Resultat, (2 - 4) / 8.0);
			Assert.AreEqual((A - (B / C)).Resultat, 2 - (4 / 8.0));
		}

		[TestMethod]
		public void SubDivLitterale()
		{
			Assert.AreEqual((A - B / C).Litterale, "A-B/C");
			Assert.AreEqual(((A - B) / C).Litterale, "(A-B)/C");
			Assert.AreEqual((A - (B / C)).Litterale, "A-B/C");
		}

		[TestMethod]
		public void SubDivNumerique()
		{
			Assert.AreEqual((A - B / C).Numerique, "2-4/8");
			Assert.AreEqual(((A - B) / C).Numerique, "(2-4)/8");
			Assert.AreEqual((A - (B / C)).Numerique, "2-4/8");
		}

		// -------------------- MUL ADD ---------------------

		[TestMethod]
		public void MulAddResultat()
		{
			Assert.AreEqual((A * B + C).Resultat, 2 * 4 + 8);
			Assert.AreEqual(((A * B) + C).Resultat, (2 * 4) + 8);
			Assert.AreEqual((A * (B + C)).Resultat, 2 * (4 + 8));
		}

		[TestMethod]
		public void MulAddLitterale()
		{
			Assert.AreEqual((A * B + C).Litterale, "A*B+C");
			Assert.AreEqual(((A * B) + C).Litterale, "A*B+C");
			Assert.AreEqual((A * (B + C)).Litterale, "A*(B+C)");
		}

		[TestMethod]
		public void MulAddNumerique()
		{
			Assert.AreEqual((A * B + C).Numerique, "2*4+8");
			Assert.AreEqual(((A * B) + C).Numerique, "2*4+8");
			Assert.AreEqual((A * (B + C)).Numerique, "2*(4+8)");
		}

		// -------------------- MUL SUB ---------------------

		[TestMethod]
		public void MulSubResultat()
		{
			Assert.AreEqual((A * B - C).Resultat, 2 * 4 - 8);
			Assert.AreEqual(((A * B) - C).Resultat, (2 * 4) - 8);
			Assert.AreEqual((A * (B - C)).Resultat, 2 * (4 - 8));
		}

		[TestMethod]
		public void MulSubLitterale()
		{
			Assert.AreEqual((A * B - C).Litterale, "A*B-C");
			Assert.AreEqual(((A * B) - C).Litterale, "A*B-C");
			Assert.AreEqual((A * (B - C)).Litterale, "A*(B-C)");
		}

		[TestMethod]
		public void MulSubNumerique()
		{
			Assert.AreEqual((A * B - C).Numerique, "2*4-8");
			Assert.AreEqual(((A * B) - C).Numerique, "2*4-8");
			Assert.AreEqual((A * (B - C)).Numerique, "2*(4-8)");
		}

		// -------------------- MUL MUL ---------------------

		[TestMethod]
		public void MulMulResultat()
		{
			Assert.AreEqual((A * B * C).Resultat, 2 * 4 * 8);
			Assert.AreEqual(((A * B) * C).Resultat, (2 * 4) * 8);
			Assert.AreEqual((A * (B * C)).Resultat, 2 * (4 * 8));
		}

		[TestMethod]
		public void MulMulLitterale()
		{
			Assert.AreEqual((A * B * C).Litterale, "A*B*C");
			Assert.AreEqual(((A * B) * C).Litterale, "A*B*C");
			Assert.AreEqual((A * (B * C)).Litterale, "A*B*C");
		}

		[TestMethod]
		public void MulMulNumerique()
		{
			Assert.AreEqual((A * B * C).Numerique, "2*4*8");
			Assert.AreEqual(((A * B) * C).Numerique, "2*4*8");
			Assert.AreEqual((A * (B * C)).Numerique, "2*4*8");
		}

		// -------------------- MUL DIV ---------------------

		[TestMethod]
		public void MulDivResultat()
		{
			Assert.AreEqual((A * B / C).Resultat, 2 * 4 / 8.0);
			Assert.AreEqual(((A * B) / C).Resultat, (2 * 4) / 8.0);
			Assert.AreEqual((A * (B / C)).Resultat, 2 * (4 / 8.0));
		}

		[TestMethod]
		public void MulDivLitterale()
		{
			Assert.AreEqual((A * B / C).Litterale, "A*B/C");
			Assert.AreEqual(((A * B) / C).Litterale, "A*B/C");
			Assert.AreEqual((A * (B / C)).Litterale, "A*B/C");
		}

		[TestMethod]
		public void MulDivNumerique()
		{
			Assert.AreEqual((A * B / C).Numerique, "2*4/8");
			Assert.AreEqual(((A * B) / C).Numerique, "2*4/8");
			Assert.AreEqual((A * (B / C)).Numerique, "2*4/8");
		}

		// -------------------- DIV ADD ---------------------

		[TestMethod]
		public void DivAddResultat()
		{
			Assert.AreEqual((A / B + C).Resultat, 2.0 / 4.0 + 8);
			Assert.AreEqual(((A / B) + C).Resultat, (2.0 / 4.0) + 8.0);
			Assert.AreEqual((A / (B + C)).Resultat, 2.0 / (4.0 + 8.0));
		}

		[TestMethod]
		public void DivAddLitterale()
		{
			Assert.AreEqual((A / B + C).Litterale, "A/B+C");
			Assert.AreEqual(((A / B) + C).Litterale, "A/B+C");
			Assert.AreEqual((A / (B + C)).Litterale, "A/(B+C)");
		}

		[TestMethod]
		public void DivAddNumerique()
		{
			Assert.AreEqual((A / B + C).Numerique, "2/4+8");
			Assert.AreEqual(((A / B) + C).Numerique, "2/4+8");
			Assert.AreEqual((A / (B + C)).Numerique, "2/(4+8)");
		}

		// -------------------- DIV SUB ---------------------

		[TestMethod]
		public void DivSubResultat()
		{
			Assert.AreEqual((A / B - C).Resultat, 2.0 / 4.0 - 8);
			Assert.AreEqual(((A / B) - C).Resultat, (2.0 / 4.0) - 8.0);
			Assert.AreEqual((A / (B - C)).Resultat, 2.0 / (4.0 - 8.0));
		}

		[TestMethod]
		public void DivSubLitterale()
		{
			Assert.AreEqual((A / B - C).Litterale, "A/B-C");
			Assert.AreEqual(((A / B) - C).Litterale, "A/B-C");
			Assert.AreEqual((A / (B - C)).Litterale, "A/(B-C)");
		}

		[TestMethod]
		public void DivSubNumerique()
		{
			Assert.AreEqual((A / B - C).Numerique, "2/4-8");
			Assert.AreEqual(((A / B) - C).Numerique, "2/4-8");
			Assert.AreEqual((A / (B - C)).Numerique, "2/(4-8)");
		}

		// -------------------- DIV MUL ---------------------

		[TestMethod]
		public void DivMulResultat()
		{
			Assert.AreEqual((A / B * C).Resultat, 2.0 / 4.0 * 8);
			Assert.AreEqual(((A / B) * C).Resultat, (2.0 / 4.0) * 8.0);
			Assert.AreEqual((A / (B * C)).Resultat, 2.0 / (4.0 * 8.0));
		}

		[TestMethod]
		public void DivMulLitterale()
		{
			Assert.AreEqual((A / B * C).Litterale, "A/B*C");
			Assert.AreEqual(((A / B) * C).Litterale, "A/B*C");
			Assert.AreEqual((A / (B * C)).Litterale, "A/(B*C)");
		}

		[TestMethod]
		public void DivMulNumerique()
		{
			Assert.AreEqual((A / B * C).Numerique, "2/4*8");
			Assert.AreEqual(((A / B) * C).Numerique, "2/4*8");
			Assert.AreEqual((A / (B * C)).Numerique, "2/(4*8)");
		}

		// -------------------- DIV DIV ---------------------

		[TestMethod]
		public void DivDivResultat()
		{
			Assert.AreEqual((A / B / C).Resultat, 2.0 / 4.0 / 8);
			Assert.AreEqual(((A / B) / C).Resultat, (2.0 / 4.0) / 8.0);
			Assert.AreEqual((A / (B / C)).Resultat, 2.0 / (4.0 / 8.0));
		}

		[TestMethod]
		public void DivDivLitterale()
		{
			Assert.AreEqual((A / B / C).Litterale, "A/B/C");
			Assert.AreEqual(((A / B) / C).Litterale, "A/B/C");
			Assert.AreEqual((A / (B / C)).Litterale, "A/(B/C)");
		}

		[TestMethod]
		public void DivDivNumerique()
		{
			Assert.AreEqual((A / B / C).Numerique, "2/4/8");
			Assert.AreEqual(((A / B) / C).Numerique, "2/4/8");
			Assert.AreEqual((A / (B / C)).Numerique, "2/(4/8)");
		}
	}
}
