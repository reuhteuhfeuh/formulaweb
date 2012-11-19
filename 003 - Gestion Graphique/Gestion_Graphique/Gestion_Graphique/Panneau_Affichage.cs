using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Gestion_Graphique
{
    class Panneau_Affichage
    {
        // Création du graphique manager, lien avec la carte graphique
        GraphicsDeviceManager graphics;

        // Création du sprite Batch objet pour dessiner sur l'écran de jeu
        SpriteBatch spriteBatch;

        // Création du content manager 
        ContentManager Content;

        // Variable du message a afficher
        private String Message;
        private String Message_corrige;
        private String Message_en_cours;
        private int Longueur_Texte;
        private int Compteur_Deplacement = 1;
        private int Compteur_Frame = 0;
        private int Vitesse_Affichage = 20; // A faire varier de 5 à 20 à peu près, 5 est le plus rapide
        private Color CouleurFont = Color.Yellow; // Couleur à définir dans les règles du jeu, par exemple Red pour les messages serveurs importants (reboot serveur)
        // Jaune pour les messages courants, Orange pour les masters et les open, etc...
        // Variable fixe à 30 pour le moment car il faudra gérer la construction du Message_corrige en fonction de cette variable
        private int Nombre_Caractere = 60;

        // Variable pour utilisation de la Font
        private SpriteFont Panneau_Affichage_Font;

        // Variable pour l'afichage du Panneau LCD
        private Texture2D Panneau_LCD;

        public void Initialize(GraphicsDeviceManager gra, SpriteBatch spr, ContentManager con)
        {
            graphics = gra;
            spriteBatch = spr;
            Content = con;
            Panneau_LCD = Content.Load<Texture2D>("Panneau_LCD");
        }

        public bool Set_Message(string Message, int Vitesse, int Caractere, Color couleur)
        {
            Set_Message(Message);
            Set_Vitesse(Vitesse);
            Set_Vitesse(Caractere);
            Set_Couleur(couleur);
            return true;
        }

        // Methode pour assigner le message a afficher
        public bool Set_Message(string Message_a_afficher)
        {
            Message = Message_a_afficher;
            //Message_corrige = "                              " + Message_a_afficher + "                              ";
            Message_corrige = " " + Message_a_afficher + " ";
            for (int compteur = 0; compteur < Nombre_Caractere; compteur++)
            {
                Message_corrige = " " + Message_corrige + " ";
            }
            Longueur_Texte = Message_corrige.Length;
            return true;
        }

        // Methode pour le chargement specifique de la font
        public void Set_Font(string lafont)
        {
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            Panneau_Affichage_Font = Content.Load<SpriteFont>(lafont);
        }

        public bool Set_Vitesse(int Vitesse)
        {
            if (Vitesse < 5)
            {
                Vitesse_Affichage = 5;
            }
            else
            {
                if (Vitesse > 20)
                {
                    Vitesse_Affichage = 20;
                }
                else
                {
                    Vitesse_Affichage = Vitesse;
                }
            }
            return true;
        }

        public bool Set_Couleur(Color Couleur)
        {
            CouleurFont = Couleur;
            return true;
        }

        public bool Set_Nombre_Caractere(int Caractere)
        {
            if (Caractere < 10)
            {
                Nombre_Caractere = 10;
            }
            else
            {
                if (Caractere > 50)
                {
                    Nombre_Caractere = 50;
                }
                else
                {
                    Nombre_Caractere = Caractere;
                }
            }
            return true;
        }

        public void Afficher_Message( SpriteBatch spriteBatch)
        {
            if (Compteur_Deplacement > Longueur_Texte - Nombre_Caractere)
            {
                Compteur_Deplacement = 1;
            }

            Message_en_cours = Message_corrige.Substring(Compteur_Deplacement, Nombre_Caractere);

            if (Compteur_Frame == Vitesse_Affichage)
            {
                Compteur_Deplacement++;
                Compteur_Frame = 0;
            }
            else
            {
                Compteur_Frame++;
            }
            spriteBatch.Draw(Panneau_LCD, new Rectangle(10, 20, Nombre_Caractere*10, 20), Color.White);
            spriteBatch.DrawString(Panneau_Affichage_Font, Message_en_cours, new Vector2(10, 20), CouleurFont);
        }
    }
}
