using MySql.Data.MySqlClient;
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
    public partial class Acceuil_formation : Form
    {
        public Acceuil_formation()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {



        }

        private void ajout_for_Click(object sender, EventArgs e)
        {
            Ajout_formation formulaire = new Ajout_formation();
            formulaire.ShowDialog();
        }

        public void affiche_formation()
        {
            ConnexionBd connexion = new ConnexionBd();
            string requete = "SELECT * FROM formation";
            connexion.monconnection = new MySql.Data.MySqlClient.MySqlConnection(connexion.chaine_de_connexion);
            connexion.command = new MySql.Data.MySqlClient.MySqlCommand(requete, connexion.monconnection);

            try
            {
                connexion.monconnection.Open();
                connexion.monreader = connexion.command.ExecuteReader();
                while (connexion.monreader.Read())
                {
                    string nom = connexion.monreader.GetString(0);
                    string domaine = connexion.monreader.GetString(1);
                    string duree = connexion.monreader.GetString(2);
                    double cout = connexion.monreader.GetDouble(3);
                    dataformation.Rows.Add(nom, domaine, duree, cout);

                }
                connexion.monreader.Close();
                connexion.monconnection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Une erreur s'est produite", ex.Message);
            }
            finally { connexion.monconnection.Close(); }

        }

        private void Acceuil_formation_Load(object sender, EventArgs e)
        {
            affiche_formation();
            dataformation.Refresh();

        }

        private void supp_Click(object sender, EventArgs e)
        {
            if (dataformation.SelectedRows.Count == 1)
            {
                int rowselected = dataformation.SelectedRows[0].Index;
                string nom = dataformation.Rows[rowselected].Cells["nom"].Value.ToString();
                MessageBox.Show(nom);

            }
        }

        private void supp_Click_1(object sender, EventArgs e)
        {

            ConnexionBd connexion = new ConnexionBd();

            if (dataformation.SelectedRows.Count == 1)
            {
                int rowselected = dataformation.SelectedRows[0].Index;
                string nom = dataformation.Rows[rowselected].Cells["nom"].Value.ToString();

                DialogResult resultat = MessageBox.Show("Voulez vous supprimer la formation " + nom, "Confirmation", MessageBoxButtons.YesNo);

                if (resultat == DialogResult.Yes)
                {
                    string requete = "DELETE FROM formation WHERE nomF = @nomf";

                    connexion.monconnection = new MySqlConnection(connexion.chaine_de_connexion);
                    connexion.command = new MySqlCommand(requete, connexion.monconnection);
                    connexion.command.Parameters.AddWithValue("@nomf", nom);
                    try
                    {
                        connexion.monconnection.Open();
                        connexion.command.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Une erreur s'est produite", ex.Message);
                    }
                    finally { connexion.monconnection.Close(); }


                    MessageBox.Show("La formation est supprimée avec succés");

                    dataformation.Rows.RemoveAt(rowselected);
                }




            }
        }

        private void modifier_formation_Click(object sender, EventArgs e)
        {
            if (dataformation.SelectedRows.Count == 1)
            {
                DataGridViewRow rowselected = dataformation.SelectedRows[0];

                Modifier_formation modifier_Formation = new Modifier_formation(rowselected);
                modifier_Formation.ShowDialog();

                dataformation.Refresh();
            }
            else
            {
                MessageBox.Show("Aucune ligne selectionné");
            }
        }
    }
}
