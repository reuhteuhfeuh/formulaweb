using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YAGUI_GESTION_CIRCUIT
{
    public partial class FenetreDebug : Form
    {
        public FenetreDebug()
        {
            InitializeComponent();
        }

        public void FenetreDebug_Affichage(string Message)
        {
            Fenetre_Debug.Text = Fenetre_Debug.Text + Environment.NewLine + Message;
        }

        private void Debug_Load(object sender, EventArgs e)
        {

        }
    }
}
