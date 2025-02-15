using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTest
{
    [TestClass]
    public class LivreTest
    {
        // Vérifie que le constructeur assigne correctement les valeurs pour Livre
        [TestMethod]
        public void Livre_Constructeur_AssigneValeursCorrectement()
        {
            Livre livreCible = new Livre("L001", "Le Seigneur des Anneaux", "lotr.jpg", "978-3-16-148410-0", "J.R.R. Tolkien", "Les classiques",
                "G001", "Fantasy", "P001", "Adulte", "R001", "Fiction");

            Assert.AreEqual("L001", livreCible.Id);
            Assert.AreEqual("Le Seigneur des Anneaux", livreCible.Titre);
            Assert.AreEqual("lotr.jpg", livreCible.Image);
            Assert.AreEqual("G001", livreCible.IdGenre);
            Assert.AreEqual("Fantasy", livreCible.Genre);
            Assert.AreEqual("P001", livreCible.IdPublic);
            Assert.AreEqual("Adulte", livreCible.Public);
            Assert.AreEqual("R001", livreCible.IdRayon);
            Assert.AreEqual("Fiction", livreCible.Rayon);

            Assert.AreEqual("978-3-16-148410-0", livreCible.Isbn);
            Assert.AreEqual("J.R.R. Tolkien", livreCible.Auteur);
            Assert.AreEqual("Les classiques", livreCible.Collection);
        }

        // Test des valeurs spécifiques au Livre
        [TestMethod]
        public void Livre_ProprietesSpecificites_LivreCorrectes()
        {
            Livre livreCible = new Livre("L002", "1984", "1984.jpg", "978-0-452-28423-4", "George Orwell", "Dystopia",
                "G002", "Dystopian", "P002", "Adulte", "R002", "Science Fiction");

            Assert.AreEqual("978-0-452-28423-4", livreCible.Isbn);
            Assert.AreEqual("George Orwell", livreCible.Auteur);
            Assert.AreEqual("Dystopia", livreCible.Collection);
        }
    }
}
