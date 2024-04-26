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
                DateTime date_na = (DateTime)rowselected.Cells["date"].Value;
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
                nomf.Text = nomformation;





            }
            else
            {
                MessageBox.Show("Aucune ligne selectionné");
            }

        }

        private void sexe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (rowselected != null)
            {
                string nouvel_matricule=matricule.Text;
                string nouvel_nom = nom.Text;
                string nouvel_prenom = prenom.Text;
                string nouvel_sexe=sexe.Text;
                string nouvel_date=date_naiss.Text;
                string nouvel_lieu=lieu_naiss.Text;
                string nouvel_telephon=telephon.Text;
                string nouvel_nomfor = nomf.Text;

                rowselected.Cells["matricule"].Value=nouvel_matricule;
                rowselected.Cells["nom"].Value= nouvel_nom;
                rowselected.Cells["prenom"].Value = nouvel_prenom;
                rowselected.Cells["sexe"].Value = nouvel_sexe;
                rowselected.Cells["date"].Value=nouvel_date;
                rowselected.Cells["lieu"].Value=nouvel_lieu;
                rowselected.Cells["tel"].Value=nouvel_telephon;
                rowselected.Cells["nomf"].Value=nouvel_nomfor;
                

               string requete= " UPDATE etudiant SET matricule ='" + nouvel_matricule + "' , nomE='"+ nouvel_nom +"',prenom='"+ nouvel_prenom  +"',sexe='" +nouvel_sexe+ "',date_naissance='" + nouvel_date+ "',lieu_naissance='" + nouvel_lieu+"',telephone='"+nouvel_telephon+"',nomF='"+nouvel_nomfor+"'";
                connexionbd.monconnection=new MySql.Data.MySqlClient.MySqlConnection(connexionbd.chaine_de_connexion);
               connexionbd.command=new MySql.Data.MySqlClient.MySqlCommand(requete,connexionbd.monconnection);
               
                try
                {
                    connexionbd.monconnection.Open();
                    connexionbd.command.ExecuteNonQuery();
                    MessageBox.Show("la modification a été effectuée");
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show("une erreur s'est produite" + ex.Message);
                }
                finally
                {
                    connexionbd.monconnection.Close();
                }
                this.Close();
                
            }
        }
    }
}
