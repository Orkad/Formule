using System;
using System.Text;
using System.Collections.Generic;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ClassLibrary.Formule;

namespace Tests
{
    /// <summary>
    /// Description résumée pour TestFormuleASME
    /// </summary>
    [TestClass]
    public class TestFormuleASME
    {
        public TestFormuleASME()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_Psp_UHX13()
        {

            Formule Psp = ASME.UHX13.F_Psp_UHX13(56, 0.5, 57, 11, 3, 0.3, 34, 60, 58, 59);
            Assert.AreEqual(230.804434697856, Psp.Resultat, 0.00001);
            Assert.AreEqual("(xs+2*(1-xs)*vt+2/Kst*(Ds/Do)²*vs-(ρs²-1)/(J*Kst)-(1-J)/(2*J*Kst)*(Dj²-Ds²)/Do²)*Ps", Psp.Litterale);
            Assert.AreEqual("(56+2*(1-56)*0,5+2/57*(11/3)²*0,3-(34²-1)/(60*57)-(1-60)/(2*60*57)*(58²-11²)/3²)*59", Psp.Numerique);
        }
    }
}
