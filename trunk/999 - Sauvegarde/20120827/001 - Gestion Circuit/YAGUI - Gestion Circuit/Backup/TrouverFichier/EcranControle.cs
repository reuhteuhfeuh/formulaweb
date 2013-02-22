using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TrouverFichier
{
    public partial class EcranControle : Form
    {
        public EcranControle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Ouvrir un fichier de type XML";
            ofd.Multiselect = false;     //valeur par défaut 
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Filter = "Fichiers XML(*.xml) | *.xml";
            ofd.FilterIndex = 2;         //valeur par défaut. L'index commence à partir de 1 
            ofd.ShowHelp = false;        //valeur par défaut 
            ofd.ReadOnlyChecked = false; //valeur par défaut 
            ofd.ShowReadOnly = false;    //valeur par défaut 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string FichierCircuit = ofd.FileName;
            } 
        }
    }
}
