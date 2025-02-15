using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTest
{
    [TestClass]
    public class ServiceTest
    {
        // Vérifie que le constructeur assigne correctement les valeurs
        [TestMethod]
        public void Service_Constructeur_AssigneValeursCorrectement()
        {
            Service service = new Service(1, "Informatique");

            Assert.AreEqual(1, service.IdService);
            Assert.AreEqual("Informatique", service.NomService);
        }

        // Vérifie la gestion d'un nom de service vide
        [TestMethod]
        public void Service_Initialisation_NomServiceVide()
        {
            Service service = new Service(2, "");
            Assert.AreEqual(2, service.IdService);
            Assert.AreEqual("", service.NomService);
        }

        // Vérifie la modification des propriétés après l'initialisation
        [TestMethod]
        public void Service_Modification_Proprietes()
        {
            Service service = new Service(3, "RH");
            service.IdService = 4;
            service.NomService = "Logistique";
            Assert.AreEqual(4, service.IdService);
            Assert.AreEqual("Logistique", service.NomService);
        }
    }
}
