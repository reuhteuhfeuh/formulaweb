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

        //public string[] languages_fichiers ;
        public int currentLanguage = 0;
        ScreenManager screenmanagermenuoption;
        Gestion_Langage.Langage langagemenulangage;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsLangageMenuScreen()
            : base("Titre_Menu_Option_Langage")
        {
            // On récupère la liste des fichiers présent dans le répertoire langages des ressources
            // languages_fichiers = System.IO.Directory.GetFiles(".\\Ressources\\Langages\\");
            // Create our menu entries.
            languageMenuEntry = new MenuEntry(string.Empty);

            MenuEntry back = new MenuEntry("Menu_Retour");

            // Hook up menu event handlers.
            languageMenuEntry.Selected += LanguageMenuEntrySelected;
            languageMenuEntry.MenuLeft_Selected += LanguageMenuEntryLeftSelected;
            languageMenuEntry.MenuRight_Selected += LanguageMenuEntryRightSelected;
            languageMenuEntry.MenuDefilUpEntry_Selected += LanguageMenuEntryLeftSelected;
            languageMenuEntry.MenuDefilDownEntry_Selected += LanguageMenuEntryRightSelected;
            back.Selected += OnCancel;
            
            // Add entries to the menu.
            MenuEntries.Add(languageMenuEntry);
            MenuEntries.Add(back);
        }

        public override void Activate(bool instancePreserved)
        {
            screenmanagermenuoption = ScreenManager;
            langagemenulangage = screenmanagermenuoption.langScreenManager;
            //langagemenulangage.listing_langage();
            SetMenuEntryText();
        }

        #endregion

        /// <summary>
        /// Fills in the latest values for the options screen menu text.
        /// </summary>
        void SetMenuEntryText()
        {
            string affichage_langage = langagemenulangage.Get_libelle_langage(langagemenulangage.langage_en_cours);
            languageMenuEntry.Text = affichage_langage;
            languageMenuEntry.traduction = false;
            languageMenuEntry.chgt_lang = true;
            languageMenuEntry.chgt_lang_choix = affichage_langage;      
        }

        #region Handle Input


        /// <summary>
        /// Event handler for when the Language menu entry is selected.
        /// </summary>
        void LanguageMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            langagemenulangage.set_Langage();
        }

        void LanguageMenuEntryLeftSelected(object sender, PlayerIndexEventArgs e)
        {
            langagemenulangage.Get_libelle_langage_precedent();
            SetMenuEntryText();
        }

        void LanguageMenuEntryRightSelected(object sender, PlayerIndexEventArgs e)
        {
            langagemenulangage.Get_libelle_langage_suivant();
            SetMenuEntryText();
        }


        #endregion
    }
}