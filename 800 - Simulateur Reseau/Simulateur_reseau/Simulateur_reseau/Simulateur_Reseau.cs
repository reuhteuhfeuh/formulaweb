using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Traceur;
using Gestion_Reseau;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulateur_reseau
{
    public partial class Simulateur_Reseau : Form
    {
        Traceur.Traceur Simulateur_Log = new Traceur.Traceur();
        Gestion_Reseau.Reseau Simulateur_Net = new Gestion_Reseau.Reseau();

        public Simulateur_Reseau()
        {
            InitializeComponent();
        }

        private void Simulateur_Reseau_Load(object sender, EventArgs e)
        {

        }

        private void Japan_button_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
