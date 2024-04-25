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
    public partial class Modifier_formation : Form
    {
        private DataGridViewRow rowselected;

        private ConnexionBd connexionBd = new ConnexionBd();
        public Modifier_formation(DataGridViewRow row)
        {
            InitializeComponent();
            rowselected = row;
        }

        private void Modifier_formation_Load(object sender, EventArgs e)
        {
            if (rowselected != null)
            {
                string nomf = rowselected.Cells["nom"].Value.ToString();
                string domainef = rowselected.Cells["domaine"].Value.ToString();
                string dureef = rowselected.Cells["duree"].Value.ToString();
                double coutf = Convert.ToDouble(rowselected.Cells["cout"].Value);

                nom_formation.Text = nomf;
                domaine_formation.Text = domainef;
                duree_formation.Text = dureef;
                cout_formation.Text = coutf.ToString();
            }
        }


        private void modifier_formation(object sender, EventArgs e)
        { 
            if(rowselected != null)
            {
                string nouvelle_nom = nom_formation.Text;
                string nouvelle_domaine = domaine_formation.Text;
                string nouvelle_duree = duree_formation.Text;
                double nouvelle_cout = double.Parse(cout_formation.Text);

                rowselected.Cells["nom"].Value = nouvelle_nom;
                rowselected.Cells["domaine"].Value = nouvelle_domaine;
                rowselected.Cells["duree"].Value = nouvelle_duree;
                rowselected.Cells["cout"].Value = nouvelle_cout;

                string requete = "UPDATE formation SET domaine='"+nouvelle_domaine+"', durée='"+nouvelle_duree+"', cout='"+nouvelle_cout+"' WHERE nomF='"+nouvelle_nom+"'";

                connexionBd.monconnection = new MySql.Data.MySqlClient.MySqlConnection(connexionBd.chaine_de_connexion);
               
                connexionBd.command = new MySql.Data.MySqlClient.MySqlCommand(requete, connexionBd.monconnection);

                

                try
                {
                    connexionBd.monconnection.Open();
                    connexionBd.command.ExecuteNonQuery();
                    MessageBox.Show("modification effectuée avec succé");
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show("Une erreur s'est produite" + ex.Message);

                }
                finally
                {
                    connexionBd.monconnection.Close();
                }

                this.Close();
            }

        }
    }
}
