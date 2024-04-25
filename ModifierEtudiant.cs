using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_caise
{
    public partial class ModifierEtudiant : Form
    {
        private DataGridViewRow rowselected;
        private ConnexionBd connexionbd = new ConnexionBd();

        public ModifierEtudiant(DataGridViewRow row)
        {
            InitializeComponent();
            rowselected = row;
        }


        private void ModifierEtudiant_Load_1(object sender, EventArgs e)
        {
            if (rowselected != null)
            {
                string matricul = rowselected.Cells["matricule"].Value.ToString();
                string nomE = rowselected.Cells["nom"].Value.ToString();
                string prenomE = rowselected.Cells["prenom"].Value.ToString();
                string sex = rowselected.Cells["sexe"].Value.ToString();
                DateTime date_na =(DateTime)rowselected.Cells["date"].Value;
                string lieu_na = rowselected.Cells["lieu"].Value.ToString();
                string telephone = rowselected.Cells["tel"].Value.ToString();
                string nomformation = rowselected.Cells["nomf"].Value.ToString();

                matricule.Text = matricul;
                nom.Text = nomE;
                prenom.Text = prenomE;
                sexe.Text = sex;
                date_naiss.Value = date_na;
                lieu_naiss.Text = lieu_na;
                telephon.Text = telephone;
                listeformation.SelectedItem = nomformation;





            }
            else
            {
                MessageBox.Show("Aucune ligne selectionné");
            }

        }

        private void sexe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
