using System;
using System.Globalization;

namespace ClassLibrary
{
	public class Formule
	{
	    public static bool Evaluation = true;
	    public const string SymbolAdd = "+";
	    public const string SymbolSub = "-";
	    public const string SymbolMul = "*";
	    public const string SymbolDiv = "/";

		protected bool Equals(Formule other)
		{
			return Resultat.Equals(other.Resultat);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Formule) obj);
		}

		public override int GetHashCode()
		{
			return Resultat.GetHashCode();
		}

		#region CONST

		public const int PrioAdd = 1;
		public const int PrioSou = 2;
		public const int PrioMul = 3;
		public const int PrioDiv = 4;
		public const int PrioVar = 5;

		#endregion

		#region PROPRIETE

		/// <summary>
		/// Evaluation litterale de la formule
		/// </summary>
		public string Litterale { get; protected set; }

        /// <summary>
		/// Evaluation numérique de la formule
		/// </summary>
		public string Numerique { get; protected set; }

        /// <summary>
        /// Evaluation litterale de la formule entre parenthèse
        /// </summary>
        public string LitteraleParenthese => "(" + Litterale + ")";

		/// <summary>
		/// Evaluation numérique de la formule entre parenthèse
		/// </summary>
		public string NumeriqueParenthese => "(" + Numerique + ")";

	    /// <summary>
		/// Résultat de la formule
		/// </summary>
		public double Resultat { get; protected set; }

		/// <summary>
		/// Priorité de la dernière opération
		/// utilisé pour savoir si des parenthèses doivent être mise durant les opérations mathématiques
		/// </summary>
		private int Priorite{ get; }

	    /// <summary>
	    /// Cumul des opérations faites
	    /// </summary>
	    public int NombreOperations { get; } = 0;

        #endregion

        #region CONSTRUCTEURS

        /// <summary>
        ///     Constructeur avec évaluation
        /// </summary>
        /// <param name="litterale"></param>
        /// <param name="numerique"></param>
        /// <param name="resultat"></param>
        /// <param name="priorite"></param>
        /// <param name="nombreOperations"></param>
        protected Formule(string litterale, string numerique, double resultat, int priorite, int nombreOperations)
		{
			Litterale = litterale;
			Numerique = numerique;
			Resultat = resultat;
			Priorite = priorite;
            NombreOperations = nombreOperations;
		}

        /// <summary>
        ///     Contructeur sans évaluation
        /// </summary>
        /// <param name="resultat"></param>
	    private Formule(double resultat)
	    {
	        Resultat = resultat;
	    }

		#endregion

		#region OPERATEURS MATHEMATIQUE FORMULE / FORMULE

		public static Formule operator +(Formule f1, Formule f2)
		{
            if (!Evaluation)
		        return new Formule(f1.Resultat + f2.Resultat);
            //Il n'y aura jamais besoin de parenthese pour une addition entre formule, l'addition étant l'opérateur le moins prioritaire
            string lit = null;
            string num = null;
		    lit = f1.Litterale + SymbolAdd + f2.Litterale;
		    num = f1.Numerique + SymbolAdd + f2.Numerique;
			return new Formule(lit,num, f1.Resultat + f2.Resultat, PrioAdd,f1.NombreOperations + f2.NombreOperations + 1);
		}

		public static Formule operator -(Formule f1, Formule f2)
		{
            if(!Evaluation)
                return new Formule(f1.Resultat - f2.Resultat);
            //Il n'y aura jamais besoin de parenthese pour une formule de l'operande de gauche pour une soustraction
            //S'il y a une soustraction ou une addition dans l'operande de gauche la formule de droite doit être entre parenthese
            //Pour une multiplication ou une division pas besoin de parenthese car elles sont priotaire
            string lit = f1.Litterale + SymbolSub;
            string num = f1.Numerique + SymbolSub;
            if (f2.Priorite <= PrioSou)
		    {
		        lit += f2.LitteraleParenthese;
		        num += f2.NumeriqueParenthese;
		    }
		    else
		    {
		        lit += f2.Litterale;
		        num += f2.Numerique;
		    }
			return new Formule(lit, num, f1.Resultat - f2.Resultat, PrioSou, f1.NombreOperations + f2.NombreOperations + 1);
		}

		public static Formule operator *(Formule f1, Formule f2)
		{
		    if (!Evaluation)
		        return new Formule(f1.Resultat*f2.Resultat);
		    string lit = null;
		    string num = null;
            //Si une soustraction ou une addition a été effectué dans l'operande de gauche elle doit alors être mis entre parenthese
            if (f1.Priorite < PrioMul)
		    {
		        lit = f1.LitteraleParenthese;
		        num = f1.NumeriqueParenthese;
		    }
		    else
		    {
		        lit = f1.Litterale;
		        num = f1.Numerique;
		    }
		    lit += SymbolMul;
			num += SymbolMul;
			//Si une soustraction ou une addition a été effectué dans l'operande de droite elle doit alors être mis entre parenthese
			if (f2.Priorite < PrioMul)
			{
				lit += f2.LitteraleParenthese;
				num += f2.NumeriqueParenthese;
			}
			else
			{
				lit += f2.Litterale;
				num += f2.Numerique;
			}
			return new Formule(lit, num, f1.Resultat * f2.Resultat, PrioMul, f1.NombreOperations + f2.NombreOperations + 1);
		}

		/// <summary>
		/// Cas d'une division d'une formule par une autre formule
		/// </summary>
		/// <param name="f1">operande de gauche</param>
		/// <param name="f2">operande de droite</param>
		/// <returns></returns>
		public static Formule operator /(Formule f1, Formule f2)
		{
		    if (!Evaluation)
		        return new Formule(f1.Resultat/f2.Resultat);
		    string lit = null;
		    string num = null;
		    //Si la priorité est inférieure à celle d'une multiplication pour l'operande de gauche elle doit avoir des parenthèses
		    if (f1.Priorite < PrioMul)
		    {
		        lit = f1.LitteraleParenthese;
		        num = f1.NumeriqueParenthese;
		    }
		    else
		    {
		        lit = f1.Litterale;
		        num = f1.Numerique;
		    }
		    lit += SymbolDiv;
		    num += SymbolDiv;
		    //Meme s'il y a une division dans la formule de l'operande de droite elle doit être prioritaire car V / V / V != V / (V / V)
		    if (f2.Priorite <= PrioDiv)
		    {
		        lit += f2.LitteraleParenthese;
		        num += f2.NumeriqueParenthese;
		    }
		    else
		    {
		        lit += f2.Litterale;
		        num += f2.Numerique;
		    }
			return new Formule(lit, num, f1.Resultat / f2.Resultat, PrioDiv, f1.NombreOperations + f2.NombreOperations + 1);
		}

		#endregion

		#region OPERATEURS DE COMPARAISON FORMULE / FORMULE

		public static bool operator ==(Formule f1, Formule f2)
		{
			return f1 != null && f1.Equals(f2);
		}

		public static bool operator !=(Formule f1, Formule f2)
		{
			return !(f1 == f2);
		}

        #endregion

        public static implicit operator Formule(double d)
        {
            if(!Evaluation)
                return new Formule(d);
            return new Formule(d.ToString(CultureInfo.CurrentCulture),d.ToString(CultureInfo.CurrentCulture), d, PrioVar,0);
        }

        
	    public static implicit operator double(Formule f)
	    {
	        return f.Resultat;
	    }

        #region METHODES

        public Var ToVariable(string nom)
		{
			return new Var(nom, Resultat);
		}

		public void ToConsole()
		{
			Console.WriteLine("\n------------------------------   CALCUL   --------------------------------------");
			Console.WriteLine("Evaluation Litterale : " + Litterale);
			Console.WriteLine("Evaluation Numerique : " + Numerique);
			Console.WriteLine("Resultat :" + Resultat);
		}

		public void ConsoleUnitTest(string exLitterale)
		{
			Console.WriteLine("\n-------------------------------   TEST   ---------------------------------------");
			if (Litterale == exLitterale)
			{
				Console.WriteLine("Test Evaluation Litterale : Ok ");
				Console.WriteLine("Formule : " + Litterale);
			}
			else
			{
				Console.WriteLine("Test Evaluation Litterale : Echec ");
				Console.WriteLine("Calculée : " + Litterale);
				Console.WriteLine("Attendue : " + exLitterale);
			}
				
		}

		public void ConsoleUnitTest(string exLitterale, string exNumerique)
		{
			ConsoleUnitTest(exLitterale);
			Console.WriteLine(Numerique == exNumerique ? "Test Evaluation Numerique : Ok" : "Test Evaluation Numerique : Echec");
		}

		public void ConsoleUnitTest(string exLitterale, string exNumerique, double exResultat)
		{
			ConsoleUnitTest(exLitterale,exNumerique);
			Console.WriteLine(exResultat == Resultat ? "Test Resultat : Ok" : "Test Resultat : Echec");
		}

        #endregion

        #region FONCTIONS MATHEMATIQUES

        /// <summary>
        /// Fonction de puissance pour une variable
        /// </summary>
        /// <param name="formule"></param>
        /// <param name="puissance"></param>
        /// <returns></returns>
        public static Formule Pow(Formule formule, double puissance)
        {
            if (!Evaluation)
                return new Formule(Math.Pow(formule.Resultat, puissance));
            if(puissance == 2)
                return Pow2(formule);
            if (puissance == 3)
                return Pow3(formule);
            if (puissance == 4)
                return Pow4(formule);
            if (formule.Priorite == PrioVar)
                return new Formule(formule.Litterale + "^" + puissance, formule.Numerique + "^" + puissance,
                    Math.Pow(formule.Resultat, 2), PrioVar, formule.NombreOperations + 1);
            return new Formule(formule.LitteraleParenthese + "^" + puissance, formule.NumeriqueParenthese + "^" + puissance,
                Math.Pow(formule.Resultat, 2), PrioVar, formule.NombreOperations + 1);
        }

        /// <summary>
		/// Fonction carre
		/// </summary>
		/// <param name="formule"></param>
		/// <returns></returns>
		public static Formule Pow2(Formule formule)
        {
            if (!Evaluation)
                return new Formule(Math.Pow(formule.Resultat, 2));
            if(formule.Priorite == PrioVar)
                return new Formule(formule.Litterale + "²", formule.Numerique + "²",
                Math.Pow(formule.Resultat, 2), PrioVar, formule.NombreOperations + 1);
            return new Formule(formule.LitteraleParenthese + "²", formule.NumeriqueParenthese + "²",
                Math.Pow(formule.Resultat, 2), PrioVar, formule.NombreOperations + 1);
        }

        /// <summary>
        /// Fonction cube
        /// </summary>
        /// <param name="formule"></param>
        /// <returns></returns>
	    public static Formule Pow3(Formule formule)
	    {
            if (!Evaluation)
                return new Formule(Math.Pow(formule.Resultat, 3));
            if (formule.Priorite == PrioVar)
                return new Formule(formule.Litterale + "³", formule.Numerique + "³",
                Math.Pow(formule.Resultat, 3), PrioVar, formule.NombreOperations + 1);
            return new Formule(formule.LitteraleParenthese + "³", formule.NumeriqueParenthese + "³",
                Math.Pow(formule.Resultat, 3), PrioVar, formule.NombreOperations + 1);
        }

        /// <summary>
        /// Fonction cube
        /// </summary>
        /// <param name="formule"></param>
        /// <returns></returns>
	    public static Formule Pow4(Formule formule)
        {
            if (!Evaluation)
                return new Formule(Math.Pow(formule.Resultat, 2));
            if (formule.Priorite == PrioVar)
                return new Formule(formule.Litterale + "⁴", formule.Numerique + "⁴",
                Math.Pow(formule.Resultat, 3), PrioVar, formule.NombreOperations + 1);
            return new Formule(formule.LitteraleParenthese + "⁴", formule.NumeriqueParenthese + "⁴",
                Math.Pow(formule.Resultat, 3), PrioVar, formule.NombreOperations + 1);
        }

        /// <summary>
        /// Logarithme népérien pour une formule
        /// </summary>
        /// <param name="f">Formule concernée</param>
        /// <returns></returns>
        public static Formule Ln(Formule f)
		{
			if (f.Resultat <= 0)
				throw new ArithmeticException("Logarithme népérien négatif");
			return new Formule("ln" + f.LitteraleParenthese, "ln" + f.NumeriqueParenthese, Math.Log(f.Resultat), PrioVar, f.NombreOperations + 1);
		}

		/// <summary>
		/// Fonction Racine carre pour une formule
		/// </summary>
		/// <param name="f">formule concernée</param>
		/// <returns></returns>
		public static Formule Sqrt(Formule f)
		{
            if(!Evaluation)
                return new Formule(Math.Sqrt(f.Resultat));
			return new Formule("sqrt" + f.LitteraleParenthese, "sqrt" + f.NumeriqueParenthese, Math.Sqrt(f.Resultat), PrioVar, f.NombreOperations + 1);
		}


		/// <summary>
		/// Fonction Cosinus pour un angle en degrès
		/// </summary>
		/// <param name="deg">Variable de l'angle en degrès</param>
		/// <returns></returns>
		public static Formule CosDeg(Var deg)
		{
			return new Formule("cos(" + deg.Nom + ")", "cos(" + deg.Valeur + ")", Math.Cos(DegToRad(deg.Valeur)), PrioVar, deg.NombreOperations + 1);
		}

		/// <summary>
		/// Fonction Cosinus pour un angle en radian
		/// </summary>
		/// <param name="rad">Variable de l'angle en radian</param>
		/// <returns></returns>
		public static Formule CosRad(Var rad)
		{
			return new Formule("cos(" + rad.Nom + ")", "cos(" + RadToDeg(rad.Valeur) + ")", Math.Cos(rad.Valeur), PrioVar,rad.NombreOperations+1);
		}

		/// <summary>
		/// Fonction Sinus pour un angle en degrès
		/// </summary>
		/// <param name="deg">Variable de l'angle en degrès</param>
		/// <returns></returns>
		public static Formule SinDeg(Var deg)
		{
			return new Formule("sin(" + deg.Nom + ")", "sin(" + deg.Valeur + ")", Math.Sin(DegToRad(deg.Valeur)), PrioVar,deg.NombreOperations+1);
		}

		/// <summary>
		/// Fonction Sinus pour un angle en radian
		/// </summary>
		/// <param name="rad">Variable de l'angle en radian</param>
		/// <returns></returns>
		public static Formule SinRad(Var rad)
		{
			return new Formule("sin(" + rad.Nom + ")", "sin(" + RadToDeg(rad.Valeur) + ")", Math.Sin(rad.Valeur), PrioVar,rad.NombreOperations+1);
		}

		/// <summary>
		/// Conversion degrès en radian
		/// </summary>
		/// <param name="deg">Valeur en degrès</param>
		/// <returns></returns>
		public static double DegToRad(double deg)
		{
			return deg * Math.PI / 180;
		}

		/// <summary>
		/// Conversion radian en degrès
		/// </summary>
		/// <param name="rad">Valeur eb radian</param>
		/// <returns></returns>
		public static double RadToDeg(double rad)
		{
			return rad * 180 / Math.PI;
		}

		#endregion
	}
}
