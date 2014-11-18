#region File Description
//-----------------------------------------------------------------------------
// PauseMenuScreen.cs
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
    /// The pause menu comes up over the top of the game,
    /// giving the player options to resume or quit.
    /// </summary>
    class ReseauLoginPass : MenuScreen
    {
        #region Initialization

        //InputAction menuA;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ReseauLoginPass()
            : base("Menu_Jeu_Saisie_Login_Pass")
        {
            // Create our menu entries.

            traduction_partielle = true ;

            MenuEntry loginGameMenuEntry = new MenuEntry("Reseau_Identifiant");
            MenuEntry passGameMenuEntry = new MenuEntry("Reseau_Motdepasse");
            MenuEntry connectedGameMenuEntry = new MenuEntry("Reseau_Connexion");

            // Hook up menu event handlers.
            // resumeGameMenuEntry.Selected += OnCancel;
            //quitGameMenuEntry.Selected += QuitGameMenuEntrySelected;

            connectedGameMenuEntry.Selected += InitialisationReseauSelected;
  

            // Add entries to the menu.
            MenuEntries.Add(loginGameMenuEntry);
            MenuEntries.Add(passGameMenuEntry);

            loginGameMenuEntry.traduction_partielle = true;
            passGameMenuEntry.traduction_partielle = true;

            //menuA = new InputAction( new Buttons[] {},new Keys[] { Keys.A }, true);
        }


        #endregion

        #region Handle Input

        /*public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {

        }*/
        /*
        public override void HandleInput(GameTime gameTime, InputState input)
        {
            PlayerIndex playerIndex;

            // Move to the previous menu entry?
            if (menuA.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                
            }
        }*/


        /// <summary>
        /// Event handler for when the Quit Game menu entry is selected.
        /// </summary>
        void InitialisationReseauSelected(object sender, PlayerIndexEventArgs e)
        {
            // ScreenManager.ReseauScreenManager.Initialisation(MenuEntries.IndexOf
            // Initialisation Reseau
        }


        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to quit" message box. This uses the loading screen to
        /// transition from the game back to the main menu screen.
        /// </summary>
        void ConfirmQuitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(),
                                                           new MainMenuScreen());
        }


        #endregion
    }
}
