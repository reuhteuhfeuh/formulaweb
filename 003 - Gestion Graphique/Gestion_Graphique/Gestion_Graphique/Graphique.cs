using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using NLog;

namespace Gestion_Graphique
{
    public class Graphique
    {
        // Cr�ation de l'instance Nlog
        Logger logger = LogManager.GetLogger("Gestion_Graphique");

        // Cr�ation du graphique manager, lien avec la carte graphique
        GraphicsDeviceManager graphics;

        // Cr�ation du sprite Batch objet pour dessiner sur l'�cran de jeu
        SpriteBatch spriteBatch;

        // Cr�ation du content manager 
        ContentManager content;

        // Cr�ation du Game
        Game game;

        // Typologie Affichage
        Int16 Typologie;
        // 1 - Ecran de chargement du jeu
        // 2 - Menu g�n�ral
        // 3 - 

        // Taille Ecran de jeu
        int Hauteur = 0;
        int Largeur = 0;

        // Ratio sur le calcul taille voiture
        double Ratio_Dimension_Voiture = 1;

        // Cr�ation des Sprite
        Sprite Sprite_Circuit ;
        bool Affichage_Sprite_Circuit ;
        string Acces_Image;
        int Circuit_Hauteur;
        int Circuit_Largeur;

        Sprite Sprite_Voiture_1;
        bool Affichage_Sprite_Voiture_1;
        int V1;
        int Y1;
        double A1;



        // Sprite Souris
        private MouseState SourisEtat ;
        Sprite Sprite_Souris ;
        bool Affichage_Sprite_Souris ;
   

        // Cr�ation des panneaux d'affichage
        Panneau_Affichage Affichage_Generale;
        bool Panneau_Affichage_Generale = true;

        public bool Set_Affichage_Generale()
        {
            if (Panneau_Affichage_Generale)
            {
                Panneau_Affichage_Generale = false;
                logger.Trace("Desactivation Panneau affichage generale");
            }
            else
            {
                Panneau_Affichage_Generale = true;
                logger.Trace("Activitation Panneau affichage generale");
            }
            return true;
        }

        public virtual void Initialize(GraphicsDeviceManager gra, SpriteBatch spr, ContentManager con, Game gam)
        {
            logger.Trace("Lancement de l'initialisation de la Gestion Graphique");
            graphics = gra;
            spriteBatch = spr;
            content = con;
            game = gam;

            Affichage_Sprite_Circuit = true ;
            Affichage_Sprite_Souris = true;
            Affichage_Sprite_Voiture_1 = true;

            Affichage_Generale = new Panneau_Affichage();
            Sprite_Souris = new Sprite();
            Sprite_Circuit = new Sprite();
            Sprite_Voiture_1 = new Sprite();

            Affichage_Generale.Initialize(graphics, spriteBatch, content);
            Sprite_Souris.Initialize(graphics, spriteBatch, content,game);
            Sprite_Circuit.Initialize(graphics, spriteBatch, content,game);
            Sprite_Voiture_1.Initialize(graphics, spriteBatch, content, game);

            Affichage_Generale.Set_Font("Panneau_Affichage");
            Sprite_Souris.Set_Image("Pointeur_Souris");
            Sprite_Voiture_1.Set_Image("FWEB_Voiture_001");
            Sprite_Voiture_1.Set_Image("RondRouge");
        }

        public bool Charger_Image_Circuit()
        {
            Sprite_Circuit.Charger_Image(Acces_Image);
            Circuit_Hauteur = Sprite_Circuit.Get_Hauteur_Sprite();
            Circuit_Largeur = Sprite_Circuit.Get_Largeur_Sprite();
            logger.Trace("Circuit charg� dimension X:"+Circuit_Largeur+" Y:"+Circuit_Hauteur);
            return true;
        }

        public bool Set_Taille_Ecran(int Ecran_Hauteur, int Ecran_Largeur)
        {
            Hauteur = Ecran_Hauteur;
            Largeur = Ecran_Largeur;
            //logger.Trace("Taille Ecran X:"+Hauteur+"Y:"+Largeur);
            return true;
        }

        public bool Set_Ratio_Voiture(double ratio)
        {
            Ratio_Dimension_Voiture = ratio;
            return true;
        }

        public bool Set_Acces_Image(string Adresse_Image)
        {
            Acces_Image = Adresse_Image;
            return true;
        }

        public bool Set_Position_Voiture(int V1X, int V1Y)
        {
            V1 = V1X;
            Y1 = V1Y;
            //logger.Trace("Coordonn�es voiture mise � X:"+V1+" Y:"+Y1);
            return true;
        }

        public bool Set_Angle_Voiture(double A1X)
        {
            A1 = A1X;
            return true;
        }

        public virtual void AffichageFixe()
        {
            // R�cup�ration de la taille du circuit
            int circuitlargeur = Sprite_Circuit.Get_Largeur_Sprite();
            int circuithauteur = Sprite_Circuit.Get_Hauteur_Sprite();

            // Calcul du ratio pour le bon positionnement de la voiture sur le circuit
            //int VoituretestWidth = 8//Voiture_Test.Width;
            //int VoituretestHeight = 8//Voiture_Test.Height;
            float ratioWidth = (float)Largeur / (float)Circuit_Largeur;
            float ratioHeight = (float)Hauteur / (float)Circuit_Hauteur;

            SourisEtat = Mouse.GetState();

            if (Panneau_Affichage_Generale)
            {
                Affichage_Generale.Afficher_Message(spriteBatch);
            }

            if (Affichage_Sprite_Souris)
            {
                Sprite_Souris.Set_Position(new Vector2(SourisEtat.X, SourisEtat.Y));
                Sprite_Souris.Afficher_Sprite();
            }
        }

        public virtual void AffichageNonFixe()
        {
            // R�cup�ration de la taille du circuit
            int circuitlargeur = Sprite_Circuit.Get_Largeur_Sprite();
            int circuithauteur = Sprite_Circuit.Get_Hauteur_Sprite();

            // Calcul du ratio pour le bon positionnement de la voiture sur le circuit
            //int VoituretestWidth = 8//Voiture_Test.Width;
            //int VoituretestHeight = 8//Voiture_Test.Height;
            float ratioWidth = (float)Largeur / (float)Circuit_Largeur;
            float ratioHeight = (float)Hauteur / (float)Circuit_Hauteur;

            SourisEtat = Mouse.GetState();
            // On affiche dans l'ordre les sprites
            if (Affichage_Sprite_Circuit)
            {
                //Sprite_Circuit.Set_Position(new Vector2());
                Sprite_Circuit.Set_Destination(new Rectangle(0, 0, Largeur, Hauteur));
                Sprite_Circuit.Afficher_Sprite();
            }

            // Voiture sans rotation
            //spriteBatch.Draw(Voiture_Test, rectangle_destination_voitureTest,null, Color.Red);
            // Voiture avec rotation -- en test --
            //spriteBatch.Draw(Voiture_Test, rectangle_destination_voitureTest, null, Color.White,(float)Angle,new Vector2(Voiture_Test.Width/2,Voiture_Test.Height/2),SpriteEffects.None,0);

            if (Affichage_Sprite_Voiture_1)
            {
                float Position_X_recalculee = (float)V1 * ratioWidth;
                float Position_Y_recalculee = (float)Y1 * ratioHeight;
                
                Sprite_Voiture_1.Set_Angle(A1);
                Sprite_Voiture_1.Set_Destination(new Rectangle((int)Position_X_recalculee, (int)Position_Y_recalculee, 20, 12));
                Sprite_Voiture_1.Afficher_Sprite();
            }
        }

        public bool Set_Message_Principal(string Message)
        {
            return Affichage_Generale.Set_Message(Message);
        }
        //public void

    }
}
