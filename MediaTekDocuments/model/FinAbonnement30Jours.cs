using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MediaTekDocuments.model
{
    public class FinAbonnement30Jours
    {
        public DateTime DateFinAbonnement { get; }
        public string Titre { get; }

        public FinAbonnement30Jours(string titre, string dateFinAbonnement)
        {
            this.Titre = titre;
            this.DateFinAbonnement = DateTime.Parse(dateFinAbonnement, CultureInfo.InvariantCulture);
        }
    }

}
