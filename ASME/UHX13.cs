using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using static ClassLibrary.Formule;

namespace ASME
{
    public static class UHX13
    {
        public static double F_Psp_UHX13_Result(double xs, double vt, double Kst, double Ds, double Do,
            double vs, double rhos, double J, double Dj, double Ps)
        {
            return (xs + 2 * (1 - xs) * vt + 2 / Kst * Math.Pow(Ds / Do,2) * vs - (Math.Pow(rhos,2) - 1) / (J * Kst) -
                    (1 - J) / (2 * J * Kst) * (Math.Pow(Dj,2) - Math.Pow(Ds,2)) / Math.Pow(Do,2)) * Ps;
        }

        public static Formule F_Psp_UHX13(double xs, double vt, double Kst, double Ds, double Do,
        double vs, double rhos, double J, double Dj, double Ps)
        {
            return F_Psp_UHX13(
                xs.ToVar("xs"),
                vt.ToVar("vt"),
                Kst.ToVar("Kst"),
                Ds.ToVar("Ds"),
                Do.ToVar("Do"),
                vs.ToVar("vs"),
                rhos.ToVar(Grec.rho + "s"),
                J.ToVar("J"),
                Dj.ToVar("Dj"),
                Ps.ToVar("Ps"));
        }

        private static Formule F_Psp_UHX13(Var xs, Var vt, Var Kst, Var Ds, Var Do,
        Var vs, Var rhos, Var J, Var Dj, Var Ps)
        {
            return (xs + 2 * (1 - xs) * vt + 2 / Kst * Pow2(Ds / Do) * vs - (Pow2(rhos) - 1) / (J * Kst) -
                    (1 - J) / (2 * J * Kst) * (Pow2(Dj) - Pow2(Ds)) / Pow2(Do)) * Ps;
        }
    }
}
