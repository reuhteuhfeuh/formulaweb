#region File Description
//-----------------------------------------------------------------------------
// OptionsMenuScreen.cs
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
    class OptionsMenuScreen : MenuScreen
    {
        #region Fields

       // MenuEntry ungulateMenuEntry;
        MenuEntry languageMenuEntry;
        //MenuEntry frobnicateMenuEntry;
        //MenuEntry elfMenuEntry;

        enum Ungulate
        {
            BactrianCamel,
            Dromedary,
            Llama,
        }

        //static Ungulate currentUngulate = Ungulate.Dromedary;

        //static string[] languages = { "C#", "French", "Deoxyribonucleic acid" };

        //static bool frobnicate = true;

        //static int elf = 23;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsMenuScreen()
            : base("Titre_Menu_Option")
        {
            // Create our menu entries.
            //ungulateMenuEntry = new MenuEntry(string.Empty);
            languageMenuEntry = new MenuEntry("Menu_Options_Langage");
            //ungulateMenuEntry.centrage = "Left";
            //frobnicateMenuEntry = new MenuEntry(string.Empty);
            //elfMenuEntry = new MenuEntry(string.Empty);

            //SetMenuEntryText();

            MenuEntry back = new MenuEntry("Menu_Retour");

            // Hook up menu event handlers.
            //ungulateMenuEntry.Selected += UngulateMenuEntrySelected;
            languageMenuEntry.Selected += LanguageMenuEntrySelected;
            //frobnicateMenuEntry.Selected += FrobnicateMenuEntrySelected;
            //elfMenuEntry.Selected += ElfMenuEntrySelected;
            back.Selected += OnCancel;
            
            // Add entries to the menu.
           // MenuEntries.Add(ungulateMenuEntry);
            MenuEntries.Add(languageMenuEntry);
           // MenuEntries.Add(frobnicateMenuEntry);
            //MenuEntries.Add(elfMenuEntry);
            MenuEntries.Add(back);
        }


        /// <summary>
        /// Fills in the latest values for the options screen menu text.
        /// </summary>
       /* void SetMenuEntryText()
        {
            ungulateMenuEntry.Text = "Preferred ungulate: " + currentUngulate;
            frobnicateMenuEntry.Text = "Frobnicate: " + (frobnicate ? "on" : "off");
            elfMenuEntry.Text = "elf: " + elf;
        }*/

        public override void Activate(bool instancePreserved)
        {

        }

        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Ungulate menu entry is selected.
        /// </summary>
       /* void UngulateMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentUngulate++;

            if (currentUngulate > Ungulate.Llama)
                currentUngulate = 0;

            SetMenuEntryText();
        }*/


        /// <summary>
        /// Event handler for when the Language menu entry is selected.
        /// </summary>
        void LanguageMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            OptionsLangageMenuScreen optionslangagemenuscreen;
            optionslangagemenuscreen = new OptionsLangageMenuScreen();
            ScreenManager.AddScreen(optionslangagemenuscreen, e.PlayerIndex);
        }

        /*
        /// <summary>
        /// Event handler for when the Frobnicate menu entry is selected.
        /// </summary>
        void FrobnicateMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            frobnicate = !frobnicate;

            SetMenuEntryText();
        }


        /// <summary>
        /// Event handler for when the Elf menu entry is selected.
        /// </summary>
        void ElfMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            elf++;

            SetMenuEntryText();
        }
        */

        #endregion
    }
}
