using MediaTekDocuments.model;
using NUnit.Framework;
using System;

namespace MediatekDocumentTest
{
    public class ParutionDansAbonnementTests
    {
        // Cette méthode est exécutée avant chaque test
        [SetUp]
        public void Setup()
        {
        }

        // Test où la date de parution est dans la plage
        [Test]
        public void ParutionDansAbonnement_ParutionDansPlage_DeRetourneVrai()
        {
            // Arrange : préparation des données de test
            DateTime dateCommande = new DateTime(2025, 1, 1);
            DateTime dateFinAbonnement = new DateTime(2025, 12, 31);
            DateTime dateParution = new DateTime(2025, 6, 15);

            // Act : appel de la méthode à tester
            bool result = Abonnement.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution);

            // Assert : vérification que le résultat est correct
            Assert.IsTrue(result);
        }

    }
}
