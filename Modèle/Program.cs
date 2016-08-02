using System;
using ClassLibrary;

using static ClassLibrary.Formule;

class Program
{
    private double
               vs = 0.3,
               vc = 0.4,
               vt = 0.5,
               xt = 0.6,
               Do = 3,
               _as = 4,
               ao = 5,
               ac = 6,
               dt = 8,
               tt = 9,
               ts = 10,
               Ds = 11,
               Es = 12,
               L = 13,
               Et = 14,
               Ks = 15,
               Kt = 16,
               Kj = 17,
               betas = 18,
               ks = 19,
               h = 20,
               Dc = 21,
               tc = 22,
               betac = 23,
               Ec = 24,
               kc = 25,
               vet = 26,
               Eet = 27,
               A = 28,
               lambdas = 29,
               lambdac = 30,
               E = 31,
               K = 32,
               F = 33,
               rhos = 34,
               Phi = 35,
               Zv = 36,
               Zm = 37,
               Zd = 38,
               Q1 = 39,
               Zw = 40,
               Xa = 41,
               alphatm = 42,
               Ttm = 43,
               Ta = 44,
               alphasm = 45,
               Tsm = 46,
               deltas = 47,
               omegas = 48,
               rhoc = 49,
               deltac = 50,
               omegac = 51,
               Gc = 52,
               C = 53,
               G1 = 54,
               Gs = 55,
               xs = 56,
               Kst = 57,
               Dj = 58,
               Ps = 59,
               J = 60,
               Pt = 61,
               gamma = 62,
               U = 63,
               gammab = 64,
               Wet = 65,
               omegaets = 66,
               omegaetc = 67,
               QZ1 = 68,
               QZ2 = 69,
               Pps = 70,
               Ppt = 71,
               PW = 72,
               Pgamma = 73,
               Prim = 74,
               Q2 = 75,
               Pe = 76;
    static void Main()
    {
        Var P = new Var(Grec.Beta, 15);
        Var E = new Var("E", 0.5);
        Var R = new Var("R", 200);
        Var Ro = new Var("Ro", 250);
        Var t = new Var("t", 20);

        F_S_A13_2(P, E, R, t).ToConsole();
        F_S_A13_2bis(P, E, Ro, t).ToConsole();

        Var a = new Var("a", 1);
        Var b = new Var("b", 2);

        Formule c = a + b;
        c.ToConsole();
        

        Var xs = new Var("xs",56);
        Var vt =  new Var("vt",0.5);
        Var Kst = new Var("Kst",57);//, , , ,
        Var Ds = new Var("Ds",11);
        Var Do = new Var("Do",3);
        Var vs = new Var("vs",0.3);//, ,   
        Var rhos = new Var(Grec.rho + "s",34);
        Var J = new Var("J",60);
        Var Dj = new Var("Dj",58);
        Var Ps = new Var("Ps",59);

        
        Console.ReadKey();
    }

    /// <summary>
    /// Calcul de la contrainte maximale admissible pour une enveloppe sphérique a paroi épaisse avec R connu
    /// </summary>
    /// <param name="P">pression intérieure de calcul (voir UG-21)</param>
    /// <param name="E">coefficient de joint relatif au joint considéré dans une enveloppe sphérique</param>
    /// <param name="R">rayon intérieur de la portion d'enveloppe considérée</param>
    /// <param name="t">épaisseur minimale requise pour l'enveloppe</param>
    /// <returns></returns>
    public static Formule F_S_A13_2(Var P, Var E, Var R, Var t)
    {
        return P/(2*E*Formule.Ln((R + t)/R));
    }

    /// <summary>
    /// Calcul de la contrainte maximale admissible pour une enveloppe sphérique a paroi épaisse avec Ro connu
    /// </summary>
    /// <param name="P">pression intérieure de calcul (voir UG-21)</param>
    /// <param name="E">coefficient de joint relatif au joint considéré dans une enveloppe sphérique</param>
    /// <param name="Ro">rayon extérieur de la portion d'enveloppe considérée</param>
    /// <param name="t">épaisseur minimale requise pour l'enveloppe</param>
    /// <param name="S">valeur de la contrainte minimale admissible, (voir UG-23 et les limites de contraintes spécifiées en UG-24)</param>
    /// <returns></returns>
    public static Formule F_S_A13_2bis(Var P, Var E, Var Ro, Var t)
    {
        return P/(2*E*Formule.Ln(Ro/(Ro - t)));
    }

    
}

