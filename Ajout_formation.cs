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
    public partial class Ajout_formation : Form
    {
        public Ajout_formation()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void ajouter_formation_dansBd(object sender, EventArgs e)
        {
            FormationClasse formationClasse = new FormationClasse();

            ConnexionBd connexionBd = new ConnexionBd();
            formationClasse.nom = nom_formation.Text;
            formationClasse.domaine = domaine_formation.Text;
            formationClasse.duree = duree_formation.Text;
            formationClasse.cout = double.Parse(cout_formation.Text);



            String requete = "INSERT INTO formation(nomF, domaine, durée, cout, date_debut) VALUES (@nom, @domaine, @dure, @cout, @date)";



            try
            {
                connexionBd.monconnection = new MySqlConnection(connexionBd.chaine_de_connexion);
                connexionBd.command = new MySqlCommand(requete, connexionBd.monconnection);
                connexionBd.command.Parameters.AddWithValue("@nom", formationClasse.nom);
                connexionBd.command.Parameters.AddWithValue("@domaine", formationClasse.domaine);
                connexionBd.command.Parameters.AddWithValue("@dure", formationClasse.duree);
                connexionBd.command.Parameters.AddWithValue("@cout", formationClasse.cout);
                connexionBd.command.Parameters.AddWithValue("@date", datedebut.Value);
                connexionBd.monconnection.Open();
                connexionBd.command.ExecuteNonQuery();

                nom_formation.Text = string.Empty;
                duree_formation.Text = string.Empty;
                domaine_formation.Text = string.Empty;
                cout_formation.Text = string.Empty;
                datedebut.Text = string.Empty;


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("une erreur s'est produite", ex.Message);
            }
            finally
            {
                connexionBd.monconnection.Close();
            }

            this.Close();

        }

        private void Ajout_formation_Load(object sender, EventArgs e)
        {

        }

        private void duree_formation_TextChanged(object sender, EventArgs e)
        {

        }

        private void datedebut_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
