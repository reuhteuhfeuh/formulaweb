#region File Description
//-----------------------------------------------------------------------------
// OptionsLangageMenuScreen.cs
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
    /// The options screen is brought up over the top of the main menu
    /// screen, and gives the user a chance to configure the game
    /// in various hopefully useful ways.
    /// </summary>
    class OptionsLangageMenuScreen : MenuScreen
    {
        #region Fields

        MenuEntry languageMenuEntry;

        public string[] languages_fichiers ;
        public int currentLanguage = 0;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsLangageMenuScreen()
            : base("Titre_Menu_Option_Langage")
        {
            // On récupère la liste des fichiers présent dans le répertoire langages des ressources
            languages_fichiers = System.IO.Directory.GetFiles(".\\Ressources\\Langages\\");
            // Create our menu entries.
            languageMenuEntry = new MenuEntry(string.Empty);
            SetMenuEntryText();
            MenuEntry back = new MenuEntry("Menu_Retour");

            // Hook up menu event handlers.
            languageMenuEntry.Selected += LanguageMenuEntrySelected;
            back.Selected += OnCancel;
            
            // Add entries to the menu.
            MenuEntries.Add(languageMenuEntry);
            MenuEntries.Add(back);
        }


        /// <summary>
        /// Fills in the latest values for the options screen menu text.
        /// </summary>
        void SetMenuEntryText()
        {
            string affichage_langage = languages_fichiers[currentLanguage].Substring(22,2).ToString().Trim();
            // A Ajouter un ou des tests sur la validite du fichier selectionné dans le cas ou on le retiens pas, on rajoute par exemple EN - Fichier non valide et on 
            // assigne pas une nouvelle langue à la gestion langage ...
            languageMenuEntry.Text = affichage_langage;
            languageMenuEntry.Traduction = false;
            languageMenuEntry.Chgt_lang = true;
            languageMenuEntry.Chgt_lang_choix = affichage_langage;
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Language menu entry is selected.
        /// </summary>
        void LanguageMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentLanguage = (currentLanguage + 1) % languages_fichiers.Length;
            SetMenuEntryText();
        }


        #endregion
    }
}