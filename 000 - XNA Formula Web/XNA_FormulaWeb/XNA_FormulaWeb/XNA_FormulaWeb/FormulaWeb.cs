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


namespace XNA_FormulaWeb
{
    public class FormulaWeb : Microsoft.Xna.Framework.Game
    {

        // Création du graphique manager, lien avec la carte graphique
        GraphicsDeviceManager graphics;

        // Création du sprite Batch objet pour dessiner sur l'écran de jeu
        SpriteBatch spriteBatch;

        // booleen premier passage
        bool Initialisation_Moteur = true;

        // Création du moteur circuit
        Gestion_Circuit.Circuit Moteur_Circuit;

        // Création du moteur voiture
        Gestion_Voiture.Voiture Moteur_Voiture;

        // Création du moteur graphique
        Gestion_Graphique.Graphique Moteur_Graphique;


        // Declaration des chemins acces
        String Acces_Circuit = ".\\Ressources\\CIRCUITS\\";

        // Création pour le clavier
        private KeyboardState ClavierEtat;
        private KeyboardState ClavierEtatPrecedent;

        // Création Texture2D pour la voiture de test
        private Texture2D Voiture_Test = null;
        protected Rectangle rectangle_destination_voitureTest;
        double Angle;

        // classe principale
        public FormulaWeb()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Initialisation des moteurs de jeu
            Moteur_Circuit = new Gestion_Circuit.Circuit();
            Moteur_Voiture = new Gestion_Voiture.Voiture();
            Moteur_Graphique = new Gestion_Graphique.Graphique();

        }

        // Initialize est la premiere methode appeller par le program.cs
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.AllowUserResizing = true;
            base.Initialize();
        }

        // LoadContent est la seconde méthode appelé, elle charge en RAM tous les objets du content
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            Voiture_Test = Content.Load<Texture2D>("Voiture_Test");
        }

        // Appeler à la fermeture du jeu pour vider la mémoire 
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        // Ici on traite tous les appels clavier, évolution du jeu, etc
        protected override void Update(GameTime gameTime)
        {
            // Premier passage on initialise les différents moteur
            if (Initialisation_Moteur)
            {
                string Fichier_Image_Circuit;
                string Access_XML;
                Access_XML = Acces_Circuit + "Zandvoort_01";
                Moteur_Circuit.Set_Chemin_Acces(Access_XML);
                Moteur_Circuit.Set_Nom_Fichier_XML("Definition_Circuit_Zandvoort_N1_Officiel_002.xml");
                if (Moteur_Circuit.Lecture_Fichier_XML() == "Chargementxmlok")
                {
                    Fichier_Image_Circuit = Moteur_Circuit.Get_Image_Circuit();
                }
                else
                {
                    // Echec du chargement du fichier XML
                }

                Moteur_Graphique.Initialize(graphics, spriteBatch, Content, this);
                Moteur_Graphique.Set_Acces_Image(Acces_Circuit + "Zandvoort_01" + "\\zandvoort1_neu_avec_notation.jpg");
                Moteur_Graphique.Charger_Image_Circuit();

                Moteur_Graphique.Set_Message_Principal("Viendez tous au masters 2012, NORTH MEN TEAM EN FORCE !!!!");
                Moteur_Voiture.Set_Numero_Case(1);
                Moteur_Graphique.Set_Position_Voiture(Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case()), Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case()));

                Initialisation_Moteur = false;
            }
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here



            // Gestion du clavier
            ClavierEtat = Keyboard.GetState();
           
            // Récupération de la taille de la fenêtre
            int screenWidth = Window.ClientBounds.Width;
            int screenHeight = Window.ClientBounds.Height;

            Moteur_Graphique.Set_Taille_Ecran(Window.ClientBounds.Height, Window.ClientBounds.Width);

            // On test que la touche vient d'être appuyé
            // Attention ne sont pas gérer les mauvais déplacement
            if (ClavierEtat.IsKeyDown(Keys.Up) && ClavierEtatPrecedent.IsKeyUp(Keys.Up))
            {
                Moteur_Voiture.Set_Numero_Case(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case()));
                Moteur_Graphique.Set_Position_Voiture(Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case()), Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case()));
            }

            if (ClavierEtat.IsKeyDown(Keys.Left) && ClavierEtatPrecedent.IsKeyUp(Keys.Left))
            {
                Moteur_Voiture.Set_Numero_Case(Moteur_Circuit.Get_Case_Gauche(Moteur_Voiture.Get_Numero_Case()));
                Moteur_Graphique.Set_Position_Voiture(Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case()), Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case()));
            }

            if (ClavierEtat.IsKeyDown(Keys.Right) && ClavierEtatPrecedent.IsKeyUp(Keys.Right))
            {
                Moteur_Voiture.Set_Numero_Case(Moteur_Circuit.Get_Case_Droite(Moteur_Voiture.Get_Numero_Case()));
                Moteur_Graphique.Set_Position_Voiture(Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case()), Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case()));
            }

            // Gestion de l'affichage générale
            if (ClavierEtat.IsKeyDown(Keys.F12) && ClavierEtatPrecedent.IsKeyUp(Keys.F12))
            {
                Moteur_Graphique.Set_Affichage_Generale();
            }


            // Calcul angle rotation voiture de test (à inclure après dans Case.cs, calculer à la génération du circuit ou à l'utilisation
            //X_distance = X_devant - X_derriere;
            //Y_distance = Y_devant - Y_derriere;
            //double Angle;
            //Angle = acos(X_distance / sqrt(X_distance * X_distance + Y_distance * Y_distance)) * 180 / 3.1415927;
            //float Distance_X = Moteur_Circuit.Get_Coordonnees_X(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case())) - Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case());
            //float Distance_Y = Moteur_Circuit.Get_Coordonnees_Y(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case())) - Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case());
            Angle = Math.Atan2(Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case()) - Moteur_Circuit.Get_Coordonnees_X(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case())), Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case())-Moteur_Circuit.Get_Coordonnees_Y(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case())));
            //Angle = 0;

            // calcul de l'angle en radian en fonction de deux point avec Arc Tan
            //Angle = Math.Atan2(Moteur_Circuit.Get_Coordonnees_X(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case())-Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case())), Moteur_Circuit.Get_Coordonnees_Y(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case()))-Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case()));
            //Angle = Math.Acos((double)Distance_X / Math.Sqrt((double)Distance_X * (double)Distance_X + (double)Distance_Y * (double)Distance_Y));// *180 / Math.PI;

            // Avant l'update on sauvegarde l'état du clavier
            ClavierEtatPrecedent = ClavierEtat;
            base.Update(gameTime);
        }

        // Draw redessine l'affichage après le passage de Update
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Affichage de la partie NonFixe
            spriteBatch.Begin();
            Moteur_Graphique.AffichageNonFixe();
            spriteBatch.End();
            base.Draw(gameTime);

            // Affichage de la partie Fixe
            spriteBatch.Begin();
            Moteur_Graphique.AffichageFixe();
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }



    }
}
