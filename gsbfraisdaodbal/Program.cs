using System;
using gsbfraisdaodbal.Business;
using gsbfraisdaodbal.Data;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dbal unDbal = new Dbal("gsb_frais_symfony");
            DaoEtat unDaoEtat = new DaoEtat(unDbal);

            List<Etat> lesEtats = unDaoEtat.SelectAll();

            foreach (Etat unEtat in lesEtats)
            {
                Console.WriteLine(unEtat.Id + "-" + unEtat.Libelle);
            }


        }
    }
}