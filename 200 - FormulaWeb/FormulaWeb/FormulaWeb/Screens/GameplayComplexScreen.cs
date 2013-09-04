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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Traceur;
using System.IO;
#endregion

namespace FormulaWeb
{
    /// <summary>
    /// Ecran de selection du jeu
    /// </summary>
    class GameplayComplexScreen : MenuScreen
    {
        #region Initialization

        MenuEntry jeudisponible;
        //public string[] jeu_accessible ;
        public int jeu_courant = 0;
        Gestion_Regles.Regles Regle_jeu;
        int jeu_en_cours { get; set; }
        int nombre_jeu { get; set; }
        string chemin_acces_ressources = ".\\Ressources\\Jeux\\";
        //List<string> jeux_dispo;
        ScreenManager screenmanagergameplay;

        //Gestion_Langage.Langage LangageMainMenuScreen ;
        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public GameplayComplexScreen()
            : base("Titre_Menu_Selection_Jeu")
        {

            // Create our menu entries.  
            jeudisponible = new MenuEntry(string.Empty);
            MenuEntry playGameMenuEntry = new MenuEntry("Menu_Jouer");
            // MenuEntry optionsMenuEntry = new MenuEntry("Menu_Options");
            MenuEntry back = new MenuEntry("Menu_Retour");

            // On interdit la traduction sur le nom du jeu
            jeudisponible.traduction = false;

            // Hook up menu event handlers.
            //jeudisponible.Selected += jeudisponibleSelected;
            jeudisponible.MenuLeft_Selected += jeudisponiblesuivantSelected;
            jeudisponible.MenuRight_Selected += jeudisponibleprecedentSelected;
            jeudisponible.MenuDefilDownEntry_Selected += jeudisponiblesuivantSelected;
            jeudisponible.MenuDefilUpEntry_Selected += jeudisponibleprecedentSelected;
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            // optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            back.Selected += BackMenuEntrySelected;
            back.Selected += OnCancel;

         


            // Add entries to the menu.
            MenuEntries.Add(jeudisponible);
            MenuEntries.Add(playGameMenuEntry);
            // MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(back);

        }

        public override void Activate(bool instancePreserved)
        {
            screenmanagergameplay = ScreenManager;
            Regle_jeu = ScreenManager.regleScreenManager;
            Regle_jeu.Listing_Jeux();
            jeudisponible.Text = Regle_jeu.Get_libelle_jeu(jeu_en_cours);
            Chgt_Fond_Background = true;
            Fichier_fond_background = chemin_acces_ressources + Regle_jeu.Get_code_jeu() + "\\logo.png";
        }

        #endregion

        #region Handle Input

        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            // A insérer le test si menu custom ou non et lancer le bon screen !
            if (Regle_jeu.Get_Options_Menu())
            {
                ScreenManager.AddScreen(new GameplayComplexScreenOptions(), e.PlayerIndex);
            }
            else
            {
                LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());
            }
        }

        void jeudisponiblesuivantSelected(object sender, PlayerIndexEventArgs e)
        {
            jeudisponible.Text = Regle_jeu.Get_libelle_jeu_suivant();
            Chgt_Fond_Background = true;
            Fichier_fond_background = chemin_acces_ressources + Regle_jeu.Get_code_jeu() + "\\logo.png";
        }

        void jeudisponibleprecedentSelected(object sender, PlayerIndexEventArgs e)
        {
            jeudisponible.Text = Regle_jeu.Get_libelle_jeu_precedent();
            Chgt_Fond_Background = true;
            Fichier_fond_background = chemin_acces_ressources + Regle_jeu.Get_code_jeu() + "\\logo.png";
        }

        /// <summary>
        /// Event handler for when the Options menu entry is selected.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
        }

        void BackMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            Chgt_Fond_Background = true;
            Fichier_fond_background = "ORIGINAL";
        }

        #endregion

    }
}
