using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Service
    {
        public int IdService { get; set; }
        public string NomService { get; set; }

        public Service(int idService, string nomService)
        {
            this.IdService = idService;
            this.NomService = nomService;
        }
    }
}
