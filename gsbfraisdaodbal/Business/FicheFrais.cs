using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbfraisdaodbal.Business
{
    public class FicheFrais
    {
        public FicheFrais(int id, string mois, int nbJustificatifs, decimal montantValid, DateTime dateModif)
        {
            this.id = id;
            this.mois = mois;
            this.nbJustificatifs = nbJustificatifs;
            this.montantValid = montantValid;
            this.dateModif = dateModif;
        }

        private int id { get; set; }
        private string mois { get; set; }
        private int nbJustificatifs { get; set; }
        private decimal montantValid { get; set; }
        private DateTime dateModif { get; set; }

    }
}
