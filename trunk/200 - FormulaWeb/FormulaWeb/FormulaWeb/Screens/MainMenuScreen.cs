#region File Description
//-----------------------------------------------------------------------------
// MainMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
#endregion

namespace FormulaWeb
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        #region Initialization

        //Gestion_Langage.Langage LangageMainMenuScreen ;
        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("Titre_Menu_Principal")
        {
            //LangageMainMenuScreen = lang;
            // Create our menu entries.            
            //MenuEntry playGameMenuEntry = new MenuEntry("Menu_Jouer");
            MenuEntry playGameMenuEntryComplex = new MenuEntry("Menu_Jouer");
            MenuEntry optionsMenuEntry = new MenuEntry("Menu_Options");
            MenuEntry exitMenuEntry = new MenuEntry("Menu_Quitter");

            // Hook up menu event handlers.
            //playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            playGameMenuEntryComplex.Selected += playGameMenuEntryComplexSelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            //MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(playGameMenuEntryComplex);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(exitMenuEntry);
 
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        /*void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());
        }*/

        void playGameMenuEntryComplexSelected(object sender, PlayerIndexEventArgs e)
        {
            GameplayComplexScreen gameplaycomplexscreen;
            gameplaycomplexscreen = new GameplayComplexScreen();
            ScreenManager.AddScreen(gameplaycomplexscreen, e.PlayerIndex);
            //gameplaycomplexscreen.ScreenManagerGameComplexScreen = ScreenManager;
        }

        /// <summary>
        /// Event handler for when the Options menu entry is selected.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "Menu_Quitter_Validation";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }


        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to exit" message box.
        /// </summary>
        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        #endregion
    }
}
