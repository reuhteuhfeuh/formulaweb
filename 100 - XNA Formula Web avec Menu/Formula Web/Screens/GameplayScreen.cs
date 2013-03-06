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
using Gestiondesmenus;
#endregion

namespace Gestiondesmenus
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

        // Cr�ation du graphique manager, lien avec la carte graphique
        // GraphicsDeviceManager graphics ;//= ScreenManager.gra

        // Cr�ation du sprite Batch objet pour dessiner sur l'�cran de jeu
        SpriteBatch spriteBatch; 

        // booleen premier passage
        bool Initialisation_Moteur = true;

        // Cr�ation du moteur circuit
        Gestion_Circuit.Circuit Moteur_Circuit;

        // Cr�ation du moteur voiture
        Gestion_Voiture.Voiture Moteur_Voiture;

        // Cr�ation du moteur graphique
        Gestion_Graphique.Graphique Moteur_Graphique;

        // Declaration des chemins acces
        String Acces_Circuit = ".\\Ressources\\CIRCUITS\\";

        // Cr�ation pour le clavier
        private KeyboardState ClavierEtat;
        private KeyboardState ClavierEtatPrecedent;

        // Cr�ation Texture2D pour la voiture de test
        // private Texture2D Voiture_Test = null;
        // protected Rectangle rectangle_destination_voitureTest;



        Vector2 playerPosition = new Vector2(100, 100);
        Vector2 enemyPosition = new Vector2(100, 100);

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
            Moteur_Circuit = new Gestion_Circuit.Circuit();
            Moteur_Voiture = new Gestion_Voiture.Voiture();
            Moteur_Graphique = new Gestion_Graphique.Graphique();

            //graphics = ScreenManager.GraphicsDevice();
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
                //graphics = ScreenManager.Game.GraphicsDevice;

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

                Moteur_Graphique.Initialize(/*graphics, */spriteBatch, content, ScreenManager.Game);//, this);
                Moteur_Graphique.Set_Acces_Image(Acces_Circuit + "Zandvoort_01" + "\\zandvoort1_neu_avec_notation.jpg");
                Moteur_Graphique.Charger_Image_Circuit();
                Moteur_Graphique.Set_Ratio_Voiture(Moteur_Circuit.Get_Ratio_Voiture());

                Moteur_Graphique.Set_Message_Principal("Viendez tous au masters 2012, NORTH MEN TEAM EN FORCE !!!!");
                Moteur_Voiture.Set_Numero_Case(1);
                Moteur_Graphique.Set_Position_Voiture(Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case()), Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case()));

                Initialisation_Moteur = false;
            }

#if WINDOWS_PHONE
            if (Microsoft.Phone.Shell.PhoneApplicationService.Current.State.ContainsKey("PlayerPosition"))
            {
                playerPosition = (Vector2)Microsoft.Phone.Shell.PhoneApplicationService.Current.State["PlayerPosition"];
                enemyPosition = (Vector2)Microsoft.Phone.Shell.PhoneApplicationService.Current.State["EnemyPosition"];
            }
#endif
        }


        public override void Deactivate()
        {
#if WINDOWS_PHONE
            Microsoft.Phone.Shell.PhoneApplicationService.Current.State["PlayerPosition"] = playerPosition;
            Microsoft.Phone.Shell.PhoneApplicationService.Current.State["EnemyPosition"] = enemyPosition;
#endif

            base.Deactivate();
        }


        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void Unload()
        {
            content.Unload();

#if WINDOWS_PHONE
            Microsoft.Phone.Shell.PhoneApplicationService.Current.State.Remove("PlayerPosition");
            Microsoft.Phone.Shell.PhoneApplicationService.Current.State.Remove("EnemyPosition");
#endif
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



                // Gestion du clavier
                ClavierEtat = Keyboard.GetState();

                // R�cup�ration de la taille de la fen�tre
                int screenWidth = ScreenManager.GraphicsDevice.Viewport.Width;
                int screenHeight = ScreenManager.GraphicsDevice.Viewport.Height;

                Moteur_Graphique.Set_Taille_Ecran(ScreenManager.GraphicsDevice.Viewport.Height, ScreenManager.GraphicsDevice.Viewport.Width);

                // On test que la touche vient d'�tre appuy�
                // Attention ne sont pas g�rer les mauvais d�placement
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

                Moteur_Graphique.Set_Angle_Voiture(Math.Atan2(Moteur_Circuit.Get_Coordonnees_Y(Moteur_Voiture.Get_Numero_Case()) - Moteur_Circuit.Get_Coordonnees_Y(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case())), Moteur_Circuit.Get_Coordonnees_X(Moteur_Voiture.Get_Numero_Case()) - Moteur_Circuit.Get_Coordonnees_X(Moteur_Circuit.Get_Case_EnFace(Moteur_Voiture.Get_Numero_Case()))));

                // Gestion de l'affichage g�n�rale
                if (ClavierEtat.IsKeyDown(Keys.F12) && ClavierEtatPrecedent.IsKeyUp(Keys.F12))
                {
                    Moteur_Graphique.Set_Affichage_Generale();
                }


                ClavierEtatPrecedent = ClavierEtat;



                // Apply some random jitter to make the enemy move around.
                const float randomization = 10;

                enemyPosition.X += (float)(random.NextDouble() - 0.5) * randomization;
                enemyPosition.Y += (float)(random.NextDouble() - 0.5) * randomization;

                // Apply a stabilizing force to stop the enemy moving off the screen.
                Vector2 targetPosition = new Vector2(
                    ScreenManager.GraphicsDevice.Viewport.Width / 2 - gameFont.MeasureString("Insert Gameplay Here").X / 2, 
                    200);

                enemyPosition = Vector2.Lerp(enemyPosition, targetPosition, 0.05f);

                // TODO: this game isn't very fun! You could probably improve
                // it by inserting something more interesting in this space :-)
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

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            // The game pauses either if the user presses the pause button, or if
            // they unplug the active gamepad. This requires us to keep track of
            // whether a gamepad was ever plugged in, because we don't want to pause
            // on PC if they are playing with a keyboard and have no gamepad at all!
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            PlayerIndex player;
            if (pauseAction.Evaluate(input, ControllingPlayer, out player) || gamePadDisconnected)
            {
#if WINDOWS_PHONE
                ScreenManager.AddScreen(new PhonePauseScreen(), ControllingPlayer);
#else
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
#endif
            }
            else
            {
                // Otherwise move the player position.
                Vector2 movement = Vector2.Zero;

                if (keyboardState.IsKeyDown(Keys.Left))
                    movement.X--;

                if (keyboardState.IsKeyDown(Keys.Right))
                    movement.X++;

                if (keyboardState.IsKeyDown(Keys.Up))
                    movement.Y--;

                if (keyboardState.IsKeyDown(Keys.Down))
                    movement.Y++;

                Vector2 thumbstick = gamePadState.ThumbSticks.Left;

                movement.X += thumbstick.X;
                movement.Y -= thumbstick.Y;

                if (input.TouchState.Count > 0)
                {
                    Vector2 touchPosition = input.TouchState[0].Position;
                    Vector2 direction = touchPosition - playerPosition;
                    direction.Normalize();
                    movement += direction;
                }

                if (movement.Length() > 1)
                    movement.Normalize();

                playerPosition += movement * 8f;
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

            // Our player and enemy are both actually just text strings.
            // SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.DrawString(gameFont, "// TODO", playerPosition, Color.Green);

            spriteBatch.DrawString(gameFont, "Insert Gameplay Here",
                                   enemyPosition, Color.DarkRed);

            spriteBatch.End();

            // Affichage de la partie NonFixe
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
