using System;
using System.Windows.Forms;
// Appel de la dll de la gestion
using Gestion_Circuit;
using Gestion_Voiture;

namespace YAGUI_GESTION_CIRCUIT
{
    public partial class EcranControle : Form
    {
        Circuit Circuit_Gestion = new Circuit();
        Voiture Voiture_Gestion_1 = new Voiture();
        

        FenetreDebug Fenetre_debug = new FenetreDebug();
        Boolean Debug = false;
        
        public EcranControle()
        {
            InitializeComponent();
            Text = "YAGUI - FormulaWeb";
            //Fenetre_debug.FenetreDebug();
            Fenetre_debug.Activate();
            Fenetre_debug.FenetreDebug_Affichage("Lancement Application");
        }

        private void EcranControle_Load(object sender, EventArgs e)
        {
            label_version_circuit.Text = Circuit_Gestion.Get_Version_Gestion();
            label_version_voiture.Text = Voiture_Gestion_1.Get_Version_Gestion();
            Voiture_Gestion_1.Set_Numero_Case(1);
            Position_Voiture1.Text = Convert.ToString(Voiture_Gestion_1.Get_Numero_Case());
        }

        private void xMLCircuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Fenetre_debug.FenetreDebug_Affichage("
            string FichierCircuit;
            string CheminAccess;
            string NomFichierXML;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Ouvrir un fichier de configuration circuit pour FormulaWeb";
            ofd.Multiselect = false;     //valeur par défaut 
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Filter = "Config Circuit(*.xml) | *.xml";
            ofd.FilterIndex = 1;         //valeur par défaut. L'index commence à partir de 1 
            ofd.ShowHelp = false;        //valeur par défaut 
            ofd.ReadOnlyChecked = false; //valeur par défaut 
            ofd.ShowReadOnly = false;    //valeur par défaut 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FichierCircuit = ofd.FileName;
                NomFichierXML = ofd.SafeFileName;
                int POSCheminAccess = FichierCircuit.IndexOf(NomFichierXML);
                CheminAccess = FichierCircuit.Remove(POSCheminAccess);
                Circuit_Gestion.Set_Chemin_Acces(CheminAccess);
                Circuit_Gestion.Set_Nom_Fichier_XML(ofd.SafeFileName);
            }

            Circuit_Gestion.Lecture_Fichier_XML();
            label5.Text = Circuit_Gestion.Get_Nom_Circuit();
            ImageCircuit.ImageLocation = Circuit_Gestion.Get_Image_Circuit();
            int Compteur_while = 0;
            Fenetre_debug.FenetreDebug_Affichage("Passage dans la bouche while " + Compteur_while + " sur " + Circuit_Gestion.Get_NombreCase());
            while (Compteur_while < Circuit_Gestion.Get_NombreCase())
            {
                Compteur_while++;
                Fenetre_debug.FenetreDebug_Affichage("Passage dans la bouche while " + Compteur_while + " sur " + Circuit_Gestion.Get_NombreCase());
                Affichage_donnees_Case.Rows.Add(Compteur_while, Circuit_Gestion.Get_Classement(Compteur_while), Circuit_Gestion.Get_Coordonnees_X(Compteur_while), Circuit_Gestion.Get_Coordonnees_Y(Compteur_while), Circuit_Gestion.Get_Case_Adjacente(Compteur_while), Circuit_Gestion.Get_Case_Gauche(Compteur_while), Circuit_Gestion.Get_Case_Droite(Compteur_while), Circuit_Gestion.Get_Case_EnFace(Compteur_while), Circuit_Gestion.Get_Case_Muret(Compteur_while));
            }
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Debug)
            {
                Fenetre_debug.Hide();
                /*BoutonDebug.Text = "DEBUG ON";*/
                Debug = false;
                Fenetre_debug.FenetreDebug_Affichage("Fermeture Fenetre Debug");
            }
            else
            {
                Fenetre_debug.Show();
                /*BoutonDebug.Text = "DEBUG OFF";*/
                Debug = true;
                Fenetre_debug.FenetreDebug_Affichage("Affichage Fenetre Debug");
            }
        }

        private void GAU_V1_Click(object sender, EventArgs e)
        {
            Int32 Temp_Position = Circuit_Gestion.Get_Case_Gauche(Voiture_Gestion_1.Get_Numero_Case()) ;
            if (Temp_Position != 0)
            {
                Voiture_Gestion_1.Set_Numero_Case(Temp_Position);
                Position_Voiture1.Text = Convert.ToString(Voiture_Gestion_1.Get_Numero_Case());
            }
        }

        private void DRO_V1_Click(object sender, EventArgs e)
        {
            Int32 Temp_Position = Circuit_Gestion.Get_Case_Droite(Voiture_Gestion_1.Get_Numero_Case());
            if (Temp_Position != 0)
            {
                Voiture_Gestion_1.Set_Numero_Case(Temp_Position);
                Position_Voiture1.Text = Convert.ToString(Voiture_Gestion_1.Get_Numero_Case());
            }
        }

        private void ENF_V1_Click(object sender, EventArgs e)
        {
            Int32 Temp_Position = Circuit_Gestion.Get_Case_EnFace(Voiture_Gestion_1.Get_Numero_Case());
            if (Temp_Position != 0)
            {
                Voiture_Gestion_1.Set_Numero_Case(Temp_Position);
                Position_Voiture1.Text = Convert.ToString(Voiture_Gestion_1.Get_Numero_Case());
            }
        }



    }
}
