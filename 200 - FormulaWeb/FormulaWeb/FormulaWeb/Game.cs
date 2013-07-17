#region File Description
//-----------------------------------------------------------------------------
// Game.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Gestion_Langage;
using Traceur;


namespace FormulaWeb
{
    /// <summary>
    /// Sample showing how to manage different game states, with transitions
    /// between menu screens, a loading screen, the game itself, and a pause
    /// menu. This main game class is extremely simple: all the interesting
    /// stuff happens in the ScreenManager component.
    /// </summary>
    public class MenuFormulaWeb : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ScreenManager screenManager;
        ScreenFactory screenFactory;
        Gestion_Langage.Langage Lang;
        Gestion_Son.SoundMachine Musique;
        Traceur.Traceur logger;
        Gestion_Regles.Regles regles;
        

        /// <summary>
        /// The main game constructor.
        /// </summary>
        public MenuFormulaWeb()
        {
            Content.RootDirectory = "Content";
            logger = new Traceur.Traceur();
            logger.Init();
            logger.Trace("Info", "Initialisation Traceur !");
            Lang = new Gestion_Langage.Langage();
            Musique = new Gestion_Son.SoundMachine();
            regles = new Gestion_Regles.Regles();
            regles.Trace(logger);
            regles.Listing_Jeux();

            Lang.set_Langage("FR");
            
            graphics = new GraphicsDeviceManager(this);
            Window.AllowUserResizing = true;

            Musique.Allumage_ampli(Content,graphics,logger);
            


            TargetElapsedTime = TimeSpan.FromTicks(333333);


            // Create the screen factory and add it to the Services
            screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), screenFactory);
            //Services.AddService(typeof(Gestion_Langage.Langage), Lang);

            // Create the screen manager component.
            screenManager = new ScreenManager(this);
            screenManager.Set_Langage(Lang);
            screenManager.sonScreenManager = Musique;
            screenManager.loggerScreenManager = logger;
            screenManager.regleScreenManager = regles;
            Components.Add(screenManager);

            
            // On Windows and Xbox we just add the initial screens
            AddInitialScreens();
        }

        private void AddInitialScreens()
        {
            // Activate the first screens.
            BackgroundScreen backgroundscreen;
            backgroundscreen = new BackgroundScreen();
            screenManager.AddScreen(backgroundscreen, null);
            screenManager.Background = backgroundscreen;
            //screenManager.screen_background = screenManager.GetScreens();
            // We have different menus for Windows Phone to take advantage of the touch interface
            screenManager.AddScreen(new MainMenuScreen(), null);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            // The real drawing happens inside the screen manager component.
            base.Draw(gameTime);
        }

    }
}
