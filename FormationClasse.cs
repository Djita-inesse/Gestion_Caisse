using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_caise
{
    internal class FormationClasse
    {
        public String nom;
        public String domaine;
        public String duree;
        public Double cout;
        public DateTime datedebut;

        public  FormationClasse()
        {

        }

        public  FormationClasse(String lenom, String ledomaine, String leduree, Double lecout, DateTime datedebut)
        {
            this.nom = ledomaine;
            this.domaine = ledomaine;
            this.duree = leduree;
            this.cout = lecout;
            this.datedebut = datedebut;
        }

        


    }
}
