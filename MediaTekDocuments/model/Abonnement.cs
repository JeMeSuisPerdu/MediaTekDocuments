using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Abonnement
    {
        public int? Id { get;  set;}
        public string IdRevue { get; }
        public DateTime DateCommande { get; }
        public double Montant { get; }
        public DateTime? DateFinAbonnement { get; set; }

        public Abonnement(int? idCommande, DateTime dateCommande, double montant, DateTime? dateFinAbonnement, string idRevue)
        {
            this.Id = idCommande;
            this.IdRevue = idRevue;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.DateFinAbonnement = dateFinAbonnement;
        }

        public static bool ParutionDansAbonnement(DateTime dateCommande, DateTime dateFinAbonnement, DateTime dateParution)
        {
            return dateParution >= dateCommande && dateParution <= dateFinAbonnement;
        }

    }
}
