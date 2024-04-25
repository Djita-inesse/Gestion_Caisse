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
    public partial class Acceiul_etu : Form
    {
        public Acceiul_etu()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void etudiant_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        public void afficherEtudiant()
        {
            ConnexionBd connexion = new ConnexionBd();

            string requete = "SELECT * FROM etudiant";
            connexion.monconnection = new MySql.Data.MySqlClient.MySqlConnection(connexion.chaine_de_connexion);
            connexion.command = new MySql.Data.MySqlClient.MySqlCommand(requete, connexion.monconnection);

            try
            {
                connexion.monconnection.Open();
                connexion.monreader = connexion.command.ExecuteReader();

                while (connexion.monreader.Read())
                {
                    string matricule = connexion.monreader.GetString(0);
                    string nom = connexion.monreader.GetString(1);
                    string prenom = connexion.monreader.GetString(2);
                    string sexe = connexion.monreader.GetString(3);
                    DateTime date = connexion.monreader.GetDateTime(4);
                    string lieu = connexion.monreader.GetString(5);
                    string tel = connexion.monreader.GetString(6);
                    string formation = connexion.monreader.GetString(7);

                    dataetudiant.Rows.Add(matricule, nom, prenom, sexe, date, lieu, tel, formation);

                }

                connexion.monreader.Close();

                connexion.monconnection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Une erreur s'est produite" + ex.Message);
            }
            finally
            {
                connexion.monconnection.Close();
            }
        }

        private void acceuil_etudiant_Load(object sender, EventArgs e)
        {
            afficherEtudiant();

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void ajouter_etudiant(object sender, EventArgs e)
        {
            Ajout_etu etudiant = new Ajout_etu();
            etudiant.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void supprime_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void modifier_Click(object sender, EventArgs e)
        {
           if(dataetudiant.SelectedRows.Count != null)
            {
                DataGridViewRow ligne ;
                ligne = dataetudiant.SelectedRows[0];
                ModifierEtudiant modifie = new ModifierEtudiant(ligne);
                modifie.ShowDialog();
                dataetudiant.Refresh();

            }
           else
            {
                MessageBox.Show("aucune ligne n'a été selectionnée");
            }
            

            
        }
    }
}
