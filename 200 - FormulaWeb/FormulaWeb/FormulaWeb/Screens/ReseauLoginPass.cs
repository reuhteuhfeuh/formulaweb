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
            MenuEntries.Add(connectedGameMenuEntry);

            loginGameMenuEntry.traduction_partielle = true;
            passGameMenuEntry.traduction_partielle = true;

            //menuA = new InputAction( new Buttons[] {},new Keys[] { Keys.A }, true);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Quit Game menu entry is selected.
        /// </summary>
        void InitialisationReseauSelected(object sender, PlayerIndexEventArgs e)
        {
            // ScreenManager.ReseauScreenManager.Initialisation(MenuEntries.IndexOf
            // Initialisation Reseau
            // MenuEntries[MenuEntries.IndexOf(loginGameMenuEntry)];
            string login = "";
            string pass = "";
            bool validation_cnx = false;
            foreach (MenuEntry menu in MenuEntries)
            {
                if (menu.Text == "Reseau_Identifiant")
                {
                    login = menu.complement_affichage;
                }
                if (menu.Text == "Reseau_Motdepasse")
                {
                    pass = menu.complement_affichage;
                }
            }

            bool TryConnexion = true ;

            while (TryConnexion)
            {
                ScreenManager.ReseauScreenManager.tracereseau = ScreenManager.loggerScreenManager;
                ScreenManager.loggerScreenManager.Trace("INFO", "CNX " + login + " " + pass);
                string retour_cnx = ScreenManager.ReseauScreenManager.Initialisation(login, pass);
                switch (retour_cnx)
                {
                    case "AUTHENTIFICATION_OK" :
                        validation_cnx = true;
                        TryConnexion = false;
                        break;
                    
                    case "AUTHENTIFICATION_NOK":
                        validation_cnx = false;
                        TryConnexion = false;
                        break;


                    default :
                        break;
                }

            }





            // quand tout est ok et validé 
            if (validation_cnx) LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new GameplayScreen());
            else
            {
                // pop up dtc la cnx bye bye
                MessageBoxScreen cnxrefused = new MessageBoxScreen("Reseau_Cnx_Refusee", false);
                ScreenManager.AddScreen(cnxrefused, e.PlayerIndex);
                //LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(), new MainMenuScreen());
            }
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
