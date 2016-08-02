using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Unite
{
    public enum PrefixeUnite
    {
        Yotta = 24,
        Zetta = 21,
        Exa = 18,
        Peta = 15,
        Tera = 12,
        Giga = 9,
        Mega = 6,
        Kilo = 3,
        Hecto = 2,
        Deca = 1,
        Aucun = 0,
        Deci = -1,
        Centi = -2,
        Milli = -3,
        Micro = -6,
        Nano = -9,
        Pico = -12,
        Femta = -15,
        Atto = -18,
        Zepto = -21,
        Yocto = -24
    }

    public abstract class UniteMesure : Var
    {
        protected PrefixeUnite Prefixe;
        protected string Unite;

        protected UniteMesure(string nom, double valeur, string unite, PrefixeUnite prefixe) : base(nom, ToUniteBase(valeur,prefixe))
        {
            Prefixe = prefixe;
        }

        private static double ToUniteBase(double valeur, PrefixeUnite prefixe)
        {
            return valeur*Math.Pow(10, (int) prefixe);
        }

        private static double ToUnitePrefixe(double valeurBase, PrefixeUnite prefixe)
        {
            return valeurBase / Math.Pow(10, (int)prefixe);
        }

        private static string SymbolePrefixe(PrefixeUnite prefixe)
        {
            switch (prefixe)
            {
                case PrefixeUnite.Yotta:
                    return "Y";
                case PrefixeUnite.Zetta:
                    return "Z";
                case PrefixeUnite.Exa:
                    return "E";
                case PrefixeUnite.Peta :
                    return "P";
                case PrefixeUnite.Tera :
                    return "T";
                case PrefixeUnite.Giga :
                    return "G";
                case PrefixeUnite.Mega :
                    return "M";
                case PrefixeUnite.Kilo :
                    return "k";
                case PrefixeUnite.Hecto:
                    return "h";
                case PrefixeUnite.Deca :
                    return "da";
                case PrefixeUnite.Aucun:
                    return "";
                case PrefixeUnite.Deci :
                    return "d";
                case PrefixeUnite.Centi:
                    return "c";
                case PrefixeUnite.Milli:
                    return "m";
                case PrefixeUnite.Micro:
                    return "µ";
                case PrefixeUnite.Nano :
                    return "n";
                case PrefixeUnite.Pico :
                    return "p";
                case PrefixeUnite.Femta:
                    return "f";
                case PrefixeUnite.Atto :
                    return "a";
                case PrefixeUnite.Zepto:
                    return "z";
                case PrefixeUnite.Yocto:
                    return "y";
            }
            return "";
        }

        public string SymboleUnite => SymbolePrefixe(Prefixe) + Unite;
    }

    public class Pression : UniteMesure
    {
        public enum Unite
        {
            /// <summary>
            ///     Pascal
            /// </summary>
            Pa,

            /// <summary>
            ///     bar
            /// </summary>
            bar,

            /// <summary>
            ///     Atmosphère technique
            /// </summary>
            at,

            /// <summary>
            ///     Atmosphère normale
            /// </summary>
            atm,

            /// <summary>
            ///     torr (millimètre de mercure)
            /// </summary>
            Torr,

            /// <summary>
            ///     livre par pouce carré
            /// </summary>
            psi
        }

        public Pression(string nom, double valeur, Unite unite, PrefixeUnite prefixe = PrefixeUnite.Aucun) : base(nom, valeur, unite.ToString(), prefixe)
        {
        }
    }
}
