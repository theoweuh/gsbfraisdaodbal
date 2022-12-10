using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbfraisdaodbal.Business
{
    public class Etat
    {
        public Etat(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        private int id { get; set; }
        private string libelle { get; set; }

    }
}
