#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Gestion_Graphique
{
    public class Graphique
    {
        // Création de l'instance Nlog
        // Logger logger = LogManager.GetLogger("Gestion_Graphique");

        // Création du graphique manager, lien avec la carte graphique
        // GraphicsDeviceManager graphics;

        // Création du sprite Batch objet pour dessiner sur l'écran de jeu
        SpriteBatch spriteBatch;
        

        // Création du content manager 
        ContentManager content;

        // Création du Game
        Game game;

        // Gestion des langues
        Gestion_Langage.Langage Langage_Graphique;

        // Taille Ecran de jeu
        int Hauteur = 0;
        int Largeur = 0;

        // Ratio sur le calcul taille voiture
        double Ratio_Dimension_Voiture = 1;

        // Création des Sprite
        Sprite Sprite_Circuit;
        bool Affichage_Sprite_Circuit;
        string Acces_Image;
        int Circuit_Hauteur;
        int Circuit_Largeur;

        Sprite Sprite_Voiture_1;
        bool Affichage_Sprite_Voiture_1;
        int V1;
        int Y1;
        double A1;

        // Sprite Souris
        public MouseState SourisEtat { get; set; }
        public MouseState OldSourisEtat { get; set; }
        Sprite Sprite_Souris;
        bool Affichage_Sprite_Souris;

        // Création des panneaux d'affichage
        Panneau_Affichage Affichage_Generale;
        bool Panneau_Affichage_Generale = true;
        bool acquisition_ecart = true ;

        public bool Set_Affichage_Generale()
        {
            if (Panneau_Affichage_Generale)
            {
                Panneau_Affichage_Generale = false;
                //logger.Trace("Desactivation Panneau affichage generale");
            }
            else
            {
                Panneau_Affichage_Generale = true;
                //logger.Trace("Activitation Panneau affichage generale");
            }
            return true;
        }

        public virtual void Initialize(/*GraphicsDeviceManager gra,*/ SpriteBatch spr, ContentManager con, Game gam)
        {
            //logger.Trace("Lancement de l'initialisation de la Gestion Graphique");
            spriteBatch = spr;
            content = con;
            game = gam;

            Affichage_Sprite_Circuit = true;
            Affichage_Sprite_Souris = true;
            Affichage_Sprite_Voiture_1 = true;

            Affichage_Generale = new Panneau_Affichage();
            Sprite_Souris = new Sprite();
            Sprite_Circuit = new Sprite();
            Sprite_Voiture_1 = new Sprite();

            Affichage_Generale.Init(game);
            Sprite_Souris.Init(spriteBatch, content, game);
            Sprite_Circuit.Init(spriteBatch, content, game);
            Sprite_Voiture_1.Init(spriteBatch, content, game);

            Affichage_Generale.Set_Font("Panneau_Affichage");
            Sprite_Souris.Set_Image("Pointeur_Souris");
            Sprite_Voiture_1.Set_Image("FWEB_Voiture_001");
        }

        public bool Set_Langage_Affichage(Gestion_Langage.Langage lang)
        {
            Langage_Graphique = lang;
            return true;
        }

        public bool Charger_Image_Circuit()
        {
            Sprite_Circuit.Charger_Image(Acces_Image);
            Circuit_Hauteur = Sprite_Circuit.Get_Hauteur_Sprite();
            Circuit_Largeur = Sprite_Circuit.Get_Largeur_Sprite();
            //logger.Trace("Circuit chargé dimension X:" + Circuit_Largeur + " Y:" + Circuit_Hauteur);
            return true;
        }

        public bool Set_Taille_Ecran(int Ecran_Hauteur, int Ecran_Largeur)
        {
            Hauteur = Ecran_Hauteur;
            Largeur = Ecran_Largeur;
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
            return true;
        }

        public bool Set_Angle_Voiture(double A1X)
        {
            A1 = A1X;
            return true;
        }

        public virtual void AffichageFixe()
        {
            // Récupération de la taille du circuit
            int circuitlargeur = Sprite_Circuit.Get_Largeur_Sprite();
            int circuithauteur = Sprite_Circuit.Get_Hauteur_Sprite();

            // Calcul du ratio pour le bon positionnement de la voiture sur le circuit
            float ratioWidth = (float)Largeur / (float)Circuit_Largeur;
            float ratioHeight = (float)Hauteur / (float)Circuit_Hauteur;

            if (Panneau_Affichage_Generale)
            {             
                if ((Affichage_Generale.Rect_Panneau.Contains(SourisEtat.X, SourisEtat.Y)) & (SourisEtat.RightButton == ButtonState.Pressed) & (OldSourisEtat.RightButton == ButtonState.Pressed))
                {
                    if (acquisition_ecart)
                    {
                        Affichage_Generale.Ecart_X = SourisEtat.X - (int)Affichage_Generale.Pos_Panneau.X;
                        Affichage_Generale.Ecart_Y = SourisEtat.Y - (int)Affichage_Generale.Pos_Panneau.Y;
                        acquisition_ecart = false;
                        Affichage_Generale.deplacement_en_cours = true;
                    }
                    // Calcul du delta c'est tout pourri ! faut le refaire gnark !
                    
                }

                if ((Affichage_Generale.deplacement_en_cours) & (SourisEtat.RightButton == ButtonState.Pressed) & (OldSourisEtat.RightButton == ButtonState.Pressed))
                {
                    Affichage_Generale.Pos_Panneau = new Vector2(SourisEtat.X - Affichage_Generale.Ecart_X, SourisEtat.Y - Affichage_Generale.Ecart_Y);
                }
                else
                {
                    acquisition_ecart = true;
                    Affichage_Generale.deplacement_en_cours = false;
                    Affichage_Generale.Ecart_X = 0;
                    Affichage_Generale.Ecart_Y = 0;
                }
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
            // Récupération de la taille du circuit
            int circuitlargeur = Sprite_Circuit.Get_Largeur_Sprite();
            int circuithauteur = Sprite_Circuit.Get_Hauteur_Sprite();

            // Calcul du ratio pour le bon positionnement de la voiture sur le circuit
            float ratioWidth = (float)Largeur / (float)Circuit_Largeur;
            float ratioHeight = (float)Hauteur / (float)Circuit_Hauteur;

            OldSourisEtat = SourisEtat;
            SourisEtat = Mouse.GetState();
            // On affiche dans l'ordre les sprites
            if (Affichage_Sprite_Circuit)
            {
                Sprite_Circuit.Set_Destination(new Rectangle(Largeur / 2, Hauteur / 2, Largeur, Hauteur));
                Sprite_Circuit.Afficher_Sprite();
            }

            if (Affichage_Sprite_Voiture_1)
            {
                float Position_X_recalculee = (float)V1 * ratioWidth;
                float Position_Y_recalculee = (float)Y1 * ratioHeight;

                Sprite_Voiture_1.Set_Angle(A1);
                Sprite_Voiture_1.Set_Position_X((int)Position_X_recalculee);
                Sprite_Voiture_1.Set_Position_Y((int)Position_Y_recalculee);
                Sprite_Voiture_1.Set_Destination(new Rectangle((int)Position_X_recalculee, (int)Position_Y_recalculee, 20, 12));
                Sprite_Voiture_1.Afficher_Sprite();
            }
        }

        public bool Set_Message_Principal(string Message)
        {
            return Affichage_Generale.Set_Message(Message);
        }
    }
}