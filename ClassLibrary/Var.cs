using System;
using System.Globalization;

namespace ClassLibrary
{
	public class Var : Formule
	{
		#region PROPRIETES

		/// <summary>
		/// Nom de la variable
		/// </summary>
		public string Nom { get; }

	    /// <summary>
	    /// Valeur de la variable
	    /// </summary>
	    public double Valeur => Resultat;

		#endregion

		#region CONSTRUCTEUR

	    public Var(string nom, double valeur) : base(nom, valeur.ToString(CultureInfo.CurrentCulture), valeur, PrioVar,0)
        {
	        Nom = nom;
	    }

		#endregion
    }

    public static class VariableExtension
    {
        public static Var ToVar(this double val, string nom)
        {
            return new Var(nom,val);
        }

        public static Var ToVar(this Formule formule, string nom)
        {
            return new Var(nom,formule);
        }
    }
}
