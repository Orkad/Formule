using System;
using System.Diagnostics;
using System.Text;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestPerformance
    {
        [TestMethod]
        public void TestPerfEvaluation()
        {
            int it = 100000;
            TimeSpan ts_FormuleAvecEval = PerformanceTest(it, () => ASME.UHX13.F_Psp_UHX13(56, 0.5, 57, 11, 3, 0.3, 34, 60, 58, 59));
            Console.WriteLine("Formule avec eval {1} iterations ={0}ms", ts_FormuleAvecEval.TotalMilliseconds, it);

            TimeSpan ts_FormuleSansEval = PerformanceTest(it, () => ASME.UHX13.F_Psp_UHX13(56, 0.5, 57, 11, 3, 0.3, 34, 60, 58, 59));
            Console.WriteLine("Formule sans eval double {1} iterations ={0}ms soit {2}x plus rapide",
                ts_FormuleSansEval.TotalMilliseconds, it,
                ts_FormuleAvecEval.TotalMilliseconds/ts_FormuleSansEval.TotalMilliseconds);

            TimeSpan ts_dbl = PerformanceTest(it, () => ASME.UHX13.F_Psp_UHX13_Result(56, 0.5, 57, 11, 3, 0.3, 34, 60, 58, 59));
            Console.WriteLine("calcul de double {1} iterations ={0}ms soit {2}x plus rapide", ts_dbl.TotalMilliseconds,
                it, ts_FormuleAvecEval.TotalMilliseconds/ts_dbl.TotalMilliseconds);
        }

        [TestMethod]
        public void TestPerfOperation()
        {
            int it = 100000;
            Var a = new Var("a",2.4);
            Var b = new Var("b",6.8);
            TimeSpan ts_Add = PerformanceTest(it, () => { Formule f = a + b + a + b + a + b; });
            TimeSpan ts_Sub = PerformanceTest(it, () => { Formule f = a - b - a - b - a - b; });
            TimeSpan ts_Mul = PerformanceTest(it, () => { Formule f = a * b * a * b * a * b; });
            TimeSpan ts_Div = PerformanceTest(it, () => { Formule f = a / b / a / b / a / b; });
            Console.WriteLine("Addition ={0}ms", ts_Add.TotalMilliseconds);
            Console.WriteLine("Soustraction ={0}ms", ts_Sub.TotalMilliseconds);
            Console.WriteLine("Multiplication ={0}ms", ts_Mul.TotalMilliseconds);
            Console.WriteLine("Division ={0}ms", ts_Div.TotalMilliseconds);
        }

        [TestMethod]
        public void TestStringBuilder()
        {
            int iterations = 100000;
            int strLengt = 5;
            string strToConcat = string.Empty;
            for(int i = 0; i < strLengt; i++)
            {
                strToConcat += "a";
            }
            Console.WriteLine("For {0} iterations",iterations);
            StringBuilder sb = new StringBuilder();
            TimeSpan ts_sb = PerformanceTest(iterations, () => sb.Append(strToConcat));

            Console.WriteLine("StringBuilder  {0}ms", ts_sb.TotalMilliseconds);

            string str = string.Empty;
            TimeSpan ts_string = PerformanceTest(iterations, () => str += strToConcat);

            Console.WriteLine("string concat {0}ms", ts_string.TotalMilliseconds);

            Console.WriteLine("StringBuilder is {0}x more powerfull than string concat for {1} iterations", (ts_string.TotalMilliseconds/ts_sb.TotalMilliseconds).ToString("0.00"),iterations);
        }

        public static TimeSpan PerformanceTest(int iterations, Action action)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();

            return sw.Elapsed;
        }
    }
}
