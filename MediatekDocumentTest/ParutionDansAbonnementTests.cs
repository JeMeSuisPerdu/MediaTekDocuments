using MediaTekDocuments.model;
using NUnit.Framework;
using System;

namespace MediatekDocumentTest
{
    public class ParutionDansAbonnementTests
    {
        // Cette m�thode est ex�cut�e avant chaque test
        [SetUp]
        public void Setup()
        {
        }

        // Test o� la date de parution est dans la plage
        [Test]
        public void ParutionDansAbonnement_ParutionDansPlage_DeRetourneVrai()
        {
            // Arrange : pr�paration des donn�es de test
            DateTime dateCommande = new DateTime(2025, 1, 1);
            DateTime dateFinAbonnement = new DateTime(2025, 12, 31);
            DateTime dateParution = new DateTime(2025, 6, 15);

            // Act : appel de la m�thode � tester
            bool result = Abonnement.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParution);

            // Assert : v�rification que le r�sultat est correct
            Assert.IsTrue(result);
        }

    }
}
