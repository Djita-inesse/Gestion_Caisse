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
    public partial class Ajout_etu : Form
    {
        public Ajout_etu()
        {
            InitializeComponent();
        }

        private void ajout_etudiant_Load(object sender, EventArgs e)
        {
            ConnexionBd connexion = new ConnexionBd();
            string requete = "SELECT nomF FROM formation";

            connexion.monconnection = new MySql.Data.MySqlClient.MySqlConnection(connexion.chaine_de_connexion);
            connexion.command = new MySql.Data.MySqlClient.MySqlCommand(requete, connexion.monconnection);

            try
            {
                connexion.monconnection.Open();
                connexion.monreader = connexion.command.ExecuteReader();

                while (connexion.monreader.Read())
                {
                    string nom = connexion.monreader.GetString(0);

                    listeformation.Items.Add(nom);
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void enregistrer_etudiant(object sender, EventArgs e)
        {
            EtudiantClasse etudiantClasse = new EtudiantClasse();
            etudiantClasse.matricule = matricule.Text;
            etudiantClasse.nomE = nom.Text;
            etudiantClasse.prenom = prenom.Text;
            etudiantClasse.sexe = sexe.SelectedItem.ToString();
           
            etudiantClasse.lieu = lieu_naiss.Text;
            etudiantClasse.tel = telephon.Text;
            etudiantClasse.nomF = listeformation.SelectedItem.ToString();




            ConnexionBd connexion = new ConnexionBd();
            string requete = "INSERT INTO etudiant(matricule, nomE, prenom, sexe, date_naissance, lieu_naissance, telephone, nomF) VALUES(@matricule,@nom,@prenom,@sexe,@date,@lieu,@tel,@nomF)";

            
            try
            {
                connexion.monconnection = new MySqlConnection(connexion.chaine_de_connexion);
                connexion.command = new MySqlCommand(requete, connexion.monconnection);
                
               
                connexion.command.Parameters.AddWithValue("@matricule", etudiantClasse.matricule);
                connexion.command.Parameters.AddWithValue("@nom", etudiantClasse.nomE);
                connexion.command.Parameters.AddWithValue("@prenom", etudiantClasse.prenom);
                connexion.command.Parameters.AddWithValue("@sexe", etudiantClasse.sexe);
                connexion.command.Parameters.AddWithValue("@date", date_naiss.Value);
                connexion.command.Parameters.AddWithValue("@lieu", etudiantClasse.lieu);
                connexion.command.Parameters.AddWithValue("@tel", etudiantClasse.tel);
                connexion.command.Parameters.AddWithValue("@nomF", etudiantClasse.nomF);

                connexion.monconnection.Open();
                connexion.command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("une erreur s'est produite", ex.Message);

            }
            finally
            {
                connexion.monconnection.Close();
            }


        }

        private void prenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void date_naiss_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
