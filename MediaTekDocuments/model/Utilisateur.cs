using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string MotDePasse { get; set; }
        public int IdService { get; set; }

        public Utilisateur(int idUser, string nom, string motDePasse, int idService)
        {
            this.Id = idUser;
            this.Nom = nom;
            this.MotDePasse = motDePasse;
            this.IdService = idService;
        }

    }
}
