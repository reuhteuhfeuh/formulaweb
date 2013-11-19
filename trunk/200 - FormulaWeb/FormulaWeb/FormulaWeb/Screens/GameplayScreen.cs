#region File Description
//-----------------------------------------------------------------------------
// GameplayScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Gestion_Son;
using FormulaWeb;
#endregion

namespace FormulaWeb
{
    /// <summary>
    /// This screen implements the actual game logic. It is just a
    /// placeholder to get the idea across: you'll probably want to
    /// put some more interesting gameplay in here!
    /// </summary>
    class GameplayScreen : GameScreen
    {
        #region Fields

        ContentManager content;
        SpriteFont gameFont;

        // Création du sprite Batch objet pour dessiner sur l'écran de jeu
        SpriteBatch spriteBatch; 

        // booleen premier passage
        bool Initialisation_Moteur = true;

        // Création du moteur Plateau
        Gestion_Plateau.Plateau Moteur_Plateau;

        // Création du moteur pion de jeu
        Gestion_Vehicule.Vehicule Moteur_Vehicule;

        // Création du moteur graphique
        Gestion_Graphique.Graphique Moteur_Graphique;

        // Création du moteur son
        Gestion_Son.SoundMachine Moteur_Son;

        // Création du moteur regle
        Gestion_Regles.Regles Moteur_Regle;

        // Création du traceur
        Traceur.Traceur Moteur_Trace;

        // Declaration des chemins acces
        String Acces_Plateau = ".\\Ressources\\Plateaux\\";

        Random random = new Random();

        float pauseAlpha;

        InputAction pauseAction;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            pauseAction = new InputAction(
                new Buttons[] { Buttons.Start, Buttons.Back },
                new Keys[] { Keys.Escape },
                true);

            // Initialisation des moteurs de jeu
            Moteur_Plateau = new Gestion_Plateau.Plateau();
            Moteur_Vehicule = new Gestion_Vehicule.Vehicule();
            Moteur_Graphique = new Gestion_Graphique.Graphique();


        }


        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void Activate(bool instancePreserved)
        {
            if (!instancePreserved)
            {
                if (content == null)
                    content = new ContentManager(ScreenManager.Game.Services, "Content");

                gameFont = content.Load<SpriteFont>("gamefont");

                GraphicsDevice gra = ScreenManager.Game.GraphicsDevice;
                Moteur_Son = ScreenManager.sonScreenManager;
                Moteur_Regle = ScreenManager.regleScreenManager;
                Moteur_Trace = ScreenManager.loggerScreenManager;
                //graphics = ScreenManager.Game.GraphicsDevice;

                Moteur_Trace.Trace("INFO", "Initialisation moteur règle");

                // A real game would probably have more content than this sample, so
                // it would take longer to load. We simulate that by delaying for a
                // while, giving you a chance to admire the beautiful loading screen.
                Thread.Sleep(1000);

                // once the load has finished, we use ResetElapsedTime to tell the game's
                // timing mechanism that we have just finished a very long frame, and that
                // it should not try to catch up.
                ScreenManager.Game.ResetElapsedTime();
            }

            // Our player and enemy are both actually just text strings.
            spriteBatch = ScreenManager.SpriteBatch;
            //graphics = spriteBatch.GraphicsDevice;
            //graphics = ScreenManager.Graphics;
            if (Initialisation_Moteur)
            {
                string Fichier_Image_Circuit;
                string Access_XML;
                Moteur_Son.Ecouter_musique("Song_01");

                Acces_Plateau = Acces_Plateau + "\\" + Moteur_Regle.Get_code_jeu() + "\\" ;
                Access_XML = Acces_Plateau + Moteur_Regle.Get_plateau();
                Moteur_Plateau.Set_Chemin_Acces(Access_XML);
                Moteur_Plateau.Set_Nom_Fichier_XML("Definition_Circuit.xml");

                if (Moteur_Plateau.Lecture_Fichier_XML() == "Chargementxmlok")
                {
                    Fichier_Image_Circuit = Moteur_Plateau.Get_Image_Plateau();
                }
                else
                {
                    // Echec du chargement du fichier XML
                }

                Moteur_Graphique.Initialize(/*graphics, */spriteBatch, content, ScreenManager.Game);
                Moteur_Graphique.Set_Acces_Image(Acces_Plateau + Moteur_Regle.Get_plateau() + "\\Plateau.png");
                Moteur_Graphique.Charger_Image_Circuit();
                Moteur_Graphique.Set_Ratio_Voiture(Moteur_Plateau.Get_Ratio_Voiture());

                Moteur_Graphique.Set_Message_Principal("Viendez tous au masters 2014, NORTH MEN TEAM EN FORCE !!!!");

                Moteur_Vehicule.Set_Numero_Case(1);
                Moteur_Graphique.Set_Position_Voiture(Moteur_Plateau.Get_Coordonnees_X(Moteur_Vehicule.Get_Numero_Case()), Moteur_Plateau.Get_Coordonnees_Y(Moteur_Vehicule.Get_Numero_Case()));

                Initialisation_Moteur = false;
            }

        }


        public override void Deactivate()
        {
            base.Deactivate();
        }


        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void Unload()
        {
            content.Unload();
            Moteur_Regle.Purge_Regle();
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            // Gradually fade in or out depending on whether we are covered by the pause screen.
            if (coveredByOtherScreen)
                pauseAlpha = Math.Min(pauseAlpha + 1f / 32, 1);
            else
                pauseAlpha = Math.Max(pauseAlpha - 1f / 32, 0);

            if (IsActive)
            {
                // Récupération de la taille de la fenêtre
                int screenWidth = ScreenManager.GraphicsDevice.Viewport.Width;
                int screenHeight = ScreenManager.GraphicsDevice.Viewport.Height;

                Moteur_Graphique.Set_Taille_Ecran(ScreenManager.GraphicsDevice.Viewport.Height, ScreenManager.GraphicsDevice.Viewport.Width);
                Moteur_Graphique.Set_Langage_Affichage(ScreenManager.langScreenManager);
            }
        }


        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(GameTime gameTime, InputState input)
        {

            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState EtatClavierencours = input.CurrentKeyboardStates[playerIndex];
            KeyboardState EtatClavierprecedent = input.LastKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];
            MouseState EtatSouris = input.CurrentMouseStates;

            // The game pauses either if the user presses the pause button, or if
            // they unplug the active gamepad. This requires us to keep track of
            // whether a gamepad was ever plugged in, because we don't want to pause
            // on PC if they are playing with a keyboard and have no gamepad at all!
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            PlayerIndex player;
            if (pauseAction.Evaluate(input, ControllingPlayer, out player) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else
            {
                // Otherwise move the player position.
                Vector2 movement = Vector2.Zero;

                if (EtatClavierencours.IsKeyDown(Keys.Left) & EtatClavierprecedent.IsKeyUp(Keys.Left))
                {
                    Moteur_Vehicule.Set_Numero_Case(Moteur_Plateau.Get_Case_Gauche(Moteur_Vehicule.Get_Numero_Case()));
                    Moteur_Graphique.Set_Position_Voiture(Moteur_Plateau.Get_Coordonnees_X(Moteur_Vehicule.Get_Numero_Case()), Moteur_Plateau.Get_Coordonnees_Y(Moteur_Vehicule.Get_Numero_Case()));
                }

                if (EtatClavierencours.IsKeyDown(Keys.Right) & EtatClavierprecedent.IsKeyUp(Keys.Right))
                {
                    Moteur_Vehicule.Set_Numero_Case(Moteur_Plateau.Get_Case_Droite(Moteur_Vehicule.Get_Numero_Case()));
                    Moteur_Graphique.Set_Position_Voiture(Moteur_Plateau.Get_Coordonnees_X(Moteur_Vehicule.Get_Numero_Case()), Moteur_Plateau.Get_Coordonnees_Y(Moteur_Vehicule.Get_Numero_Case()));
                }

                if (EtatClavierencours.IsKeyDown(Keys.Up) & EtatClavierprecedent.IsKeyUp(Keys.Up))
                {
                    Moteur_Vehicule.Set_Numero_Case(Moteur_Plateau.Get_Case_EnFace(Moteur_Vehicule.Get_Numero_Case()));
                    Moteur_Graphique.Set_Position_Voiture(Moteur_Plateau.Get_Coordonnees_X(Moteur_Vehicule.Get_Numero_Case()), Moteur_Plateau.Get_Coordonnees_Y(Moteur_Vehicule.Get_Numero_Case()));
                }

                if (EtatClavierencours.IsKeyDown(Keys.Down) & EtatClavierprecedent.IsKeyUp(Keys.Down))
                {

                }

                // Gestion de l'affichage générale
                if (EtatClavierencours.IsKeyDown(Keys.F12) && EtatClavierprecedent.IsKeyUp(Keys.F12))
                {
                    Moteur_Graphique.Set_Affichage_Generale();
                }

                Moteur_Graphique.Set_Angle_Voiture(Math.Atan2(Moteur_Plateau.Get_Coordonnees_Y(Moteur_Vehicule.Get_Numero_Case()) - Moteur_Plateau.Get_Coordonnees_Y(Moteur_Plateau.Get_Case_EnFace(Moteur_Vehicule.Get_Numero_Case())), Moteur_Plateau.Get_Coordonnees_X(Moteur_Vehicule.Get_Numero_Case()) - Moteur_Plateau.Get_Coordonnees_X(Moteur_Plateau.Get_Case_EnFace(Moteur_Vehicule.Get_Numero_Case()))));
                Moteur_Graphique.SourisEtat = EtatSouris;

            }
        }


        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // This game has a blue background. Why? Because!
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.CornflowerBlue, 0, 0);

            // Affichage de la partie NonFixe
            // Reste à gérer une caméra différente pour pouvoir faire des rotations, zooms, etc ...
            spriteBatch.Begin();
            Moteur_Graphique.AffichageNonFixe();
            spriteBatch.End();
            base.Draw(gameTime);

            // Affichage de la partie Fixe
            spriteBatch.Begin();
            Moteur_Graphique.AffichageFixe();
            spriteBatch.End();

            // If the game is transitioning on or off, fade it out to black.
            if (TransitionPosition > 0 || pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, pauseAlpha / 2);

                ScreenManager.FadeBackBufferToBlack(alpha);
            }
        }


        #endregion
    }
}
