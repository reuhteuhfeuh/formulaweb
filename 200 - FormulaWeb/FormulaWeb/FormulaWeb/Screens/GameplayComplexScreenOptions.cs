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
    class GameplayComplexScreenOptions : MenuScreen
    {
        #region Initialization
        Gestion_Regles.Regles Regle_jeu;
        Traceur.Traceur Traceur_menu_option;
        string chemin_acces_ressources = ".\\Ressources\\Jeux\\";
        string chemin_acces_ressources_base = ".\\Ressources\\";
        ScreenManager screenmanagergameplay;


        MenuEntry back = new MenuEntry("Menu_Retour");
        MenuEntry jouer = new MenuEntry("Menu_Jouer");



        
        // Enumération des actions possibles pour le menu
        enum action_menu
        {
            Listing_string = 0 ,
            Listing_repertoire = 1,
            Listing_nombre = 2 ,
            Listing_fichiers = 3
        }
        
        // Enumération des actions possibles sur la sélection du menu
        enum action_selection
        {
            Stockage
        }

        public struct Menu_Option
        {
            public string balise;
            public string valeur;
        }
        
        // Liste des descriptions de ligne de menu
        public List<Menu_Option> liste_menu;

        List<MenuEntry> liste_menu_option;

        //Gestion_Langage.Langage LangageMainMenuScreen ;
        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public GameplayComplexScreenOptions()
            : base("Titre_Menu_Options_Jeu")
        {
            liste_menu = new List<Menu_Option>();
            liste_menu_option = new List<MenuEntry>();
            jouer.Selected += PlayGameMenuEntrySelected;
            back.Selected += BackMenuEntrySelected;
            back.Selected += OnCancel;
        }

        public override void Activate(bool instancePreserved)
        {
            screenmanagergameplay = ScreenManager;
            Regle_jeu = screenmanagergameplay.regleScreenManager ;
            Traceur_menu_option = screenmanagergameplay.loggerScreenManager;

            XmlDocument FichierXmlDesciption = new XmlDocument();
            try
            {
                FichierXmlDesciption.Load(chemin_acces_ressources+Regle_jeu.Get_code_jeu() + "\\Description.xml");
                foreach (XmlNode lectureXML_Racine in FichierXmlDesciption.ChildNodes)
                {
                    if (lectureXML_Racine.Name == "Description")
                    {
                        foreach (XmlNode lectureXML_Description in FichierXmlDesciption.DocumentElement.ChildNodes)
                        {
                            if (lectureXML_Description.Name == "menu_option_jeu")
                            {
                                foreach (XmlNode lectureXML_Menuoption in lectureXML_Description.ChildNodes)
                                {
                                    // on parcout le fichier XML
                                    Menu_Option traitement_menu = new Menu_Option();
                                    traitement_menu.balise = lectureXML_Menuoption.Name;
                                    traitement_menu.valeur = lectureXML_Menuoption.InnerText;
                                    liste_menu.Add(traitement_menu);
                                    if (lectureXML_Menuoption.Name == "tag_end")
                                    {
                                        Traitement_Menu();
                                        liste_menu = null;
                                        liste_menu = new List<Menu_Option>();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Traceur_menu_option.Trace("ERREUR", "Impossible d'ouvrir le xml " + Regle_jeu.Get_code_jeu() + "\\Description.xml");
            }

            MenuEntries.Add(jouer);
            MenuEntries.Add(back);
            liste_menu_option.Add(jouer);
            liste_menu_option.Add(back);
  
        }

        #endregion

        #region Handle Input

        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>

        void jeudisponiblesuivantSelected(object sender, PlayerIndexEventArgs e)
        {
            //jeudisponible.Text = Regle_jeu.Get_libelle_jeu_suivant();
            Chgt_Fond_Background = true;
            Fichier_fond_background = chemin_acces_ressources + Regle_jeu.Get_code_jeu() + "\\logo.png";
        }

        void jeudisponibleprecedentSelected(object sender, PlayerIndexEventArgs e)
        {
            //jeudisponible.Text = Regle_jeu.Get_libelle_jeu_precedent();
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

        string Recherche_liste_menu(string balise_a_rechercher)
        {
            Menu_Option mn_opt = liste_menu.Find(delegate(Menu_Option Recherche_Menu)
            {
                return (Recherche_Menu.balise == balise_a_rechercher);
            });
            return mn_opt.valeur;
        }

        void Traitement_Menu()
        {
            MenuEntry ligne = new MenuEntry(String.Empty);
            //bool affichage = true;
            Traceur_menu_option.Trace("INFO", "Traitement menu Optionnel : " + Recherche_liste_menu("tag_menu") );
            string action = Recherche_liste_menu("action_menu") ;
            switch (action)
            {
                case "Listing_string" :
                    if (traitement_String(ligne)) MenuEntries.Add(ligne);
                    else ligne.affichage = false;                 
                    break;
                  
                case "Listing_repertoire" :
                    if (traitement_Repertoire(ligne)) MenuEntries.Add(ligne);
                    else ligne.affichage = false; 
                    break;

                case "Listing_nombre":
                    if (traitement_Nombre(ligne)) MenuEntries.Add(ligne);
                    else ligne.affichage = false; 
                    break;

                case "Listing_fichiers":
                    if (traitement_Fichier(ligne)) MenuEntries.Add(ligne);
                    else ligne.affichage = false; 
                    break;

                default :
                    Traceur_menu_option.Trace("ERREUR", "Action inconnue : " + action);
                    break;
            }
        }



        // methode générique pour faire defile une string[] à gauche
        void stringleftentrySelected(object sender, PlayerIndexEventArgs e)
        {
            Set_String_Left();
        }

        // methode générique pour faire defile une string[] à droite
        void stringrightentrySelected(object sender, PlayerIndexEventArgs e)
        {
            Set_String_Right();
        }

        bool traitement_String(MenuEntry ligne_menu)
        {
            Traceur_menu_option.Trace("INFO", "Action Listing_string");

            // on récupère les info sur l'affichage de la ligne de menu
            string tag_menu_affichage = Recherche_liste_menu("tag_menu_affichage");
            string tag_menu_affichage_dependance = Recherche_liste_menu("tag_menu_affichage_dependance");
            string tag_menu_affichage_dependance_valeur = Recherche_liste_menu("tag_menu_affichage_dependance_valeur");


            // on récupère les infos nécessaire pour l'action
            string liste_string = Recherche_liste_menu("action_listing_string");
            string action_selection = Recherche_liste_menu("action_selection");
            string action_variable = Recherche_liste_menu("action_variable");
            string separateur = Recherche_liste_menu("action_listing_string_separateur");

            // on vérifie la bonne présence des infos
            if (tag_menu_affichage == "false")
            {
                ligne_menu.affichage = false;
            }
            else ligne_menu.affichage = true;

            if (liste_string == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_listing_string n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }

            if (separateur == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_listing_string_separateur n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_selection == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_selection n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_variable == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_variable n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }

            // on travaille les info au besoin
            string[] liste_separateur = new string[] { separateur };
            string[] liste_choix = liste_string.Split(liste_separateur, StringSplitOptions.RemoveEmptyEntries);

            // on fournis les info à la ligne de menu
            ligne_menu.traduction = false;
            ligne_menu.choix_menu = liste_choix;
            ligne_menu.nbchoix = liste_string.Split(liste_separateur, StringSplitOptions.RemoveEmptyEntries).Length - 1;
            ligne_menu.Text = liste_choix[0];
            ligne_menu.action = action_selection;
            ligne_menu.variable = action_variable;
            if (tag_menu_affichage == "false")
            {
                ligne_menu.affichage_dependance = tag_menu_affichage_dependance;
                ligne_menu.affichage_dependance_valeur = tag_menu_affichage_dependance_valeur;
            }

            // on ajoute la gestion du défilement dans le menu sur la ligne de menu :
            ligne_menu.MenuLeft_Selected += stringleftentrySelected;
            ligne_menu.MenuRight_Selected += stringrightentrySelected;
            ligne_menu.MenuDefilUpEntry_Selected += stringleftentrySelected;
            ligne_menu.MenuDefilDownEntry_Selected += stringrightentrySelected;

            liste_menu_option.Add(ligne_menu);

            return true;
        }

        bool traitement_Repertoire(MenuEntry ligne_menu)
        {
            Traceur_menu_option.Trace("INFO", "Action Listing_Repertoire");

            // on récupère les info sur l'affichage de la ligne de menu
            string tag_menu_affichage = Recherche_liste_menu("tag_menu_affichage");
            string tag_menu_affichage_dependance = Recherche_liste_menu("tag_menu_affichage_dependance");
            string tag_menu_affichage_dependance_valeur = Recherche_liste_menu("tag_menu_affichage_dependance_valeur");


            // on récupère les infos nécessaire pour l'action
            string action_repertoire = Recherche_liste_menu("action_repertoire");
            string action_selection = Recherche_liste_menu("action_selection");
            string action_variable = Recherche_liste_menu("action_variable");
            string separateur = Recherche_liste_menu("action_listing_string_separateur");

            // on vérifie la bonne présence des infos
            if (tag_menu_affichage == "false")
            {
                ligne_menu.affichage = false;
            }
            else ligne_menu.affichage = true;

            if (action_repertoire == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_repertoire n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_selection == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_selection n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_variable == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_variable n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }

            // on fournis les info à la ligne de menu
            ligne_menu.traduction = false;
            //string[] liste_repertoire;
            try
            {
                ligne_menu.choix_menu = Directory.GetDirectories(chemin_acces_ressources_base + action_repertoire + "\\" + Regle_jeu.Get_code_jeu());
                //ligne_menu.choix_menu = 
            }
            catch
            {
                Traceur_menu_option.Trace("ERREUR", "Impossible de lister les repertoire dans " + chemin_acces_ressources_base + action_repertoire + "\\" + Regle_jeu.Get_code_jeu());
                return false;
            }

            ligne_menu.action = action_selection;
            ligne_menu.variable = action_variable;
            ligne_menu.nbchoix = ligne_menu.choix_menu.Count()-1;
            for (int i = 0; i < ligne_menu.nbchoix+1; i++)
            {
                ligne_menu.choix_menu[i] = ligne_menu.choix_menu[i].Replace(chemin_acces_ressources_base + action_repertoire + "\\" + Regle_jeu.Get_code_jeu()+"\\", "");
            }
            ligne_menu.Text = ligne_menu.choix_menu[0];
            if (tag_menu_affichage == "false")
            {
                ligne_menu.affichage_dependance = tag_menu_affichage_dependance;
                ligne_menu.affichage_dependance_valeur = tag_menu_affichage_dependance_valeur;
            }

            // on ajoute la gestion du défilement dans le menu sur la ligne de menu :
            ligne_menu.MenuLeft_Selected += stringleftentrySelected;
            ligne_menu.MenuRight_Selected += stringrightentrySelected;
            ligne_menu.MenuDefilUpEntry_Selected += stringleftentrySelected;
            ligne_menu.MenuDefilDownEntry_Selected += stringrightentrySelected;

            liste_menu_option.Add(ligne_menu);
            return true;
        }

        bool traitement_Nombre(MenuEntry ligne_menu)
        {
            Traceur_menu_option.Trace("INFO", "Action Listing_Nombre");

            // on récupère les info sur l'affichage de la ligne de menu
            string tag_menu_affichage = Recherche_liste_menu("tag_menu_affichage");
            string tag_menu_affichage_dependance = Recherche_liste_menu("tag_menu_affichage_dependance");
            string tag_menu_affichage_dependance_valeur = Recherche_liste_menu("tag_menu_affichage_dependance_valeur");

            // on récupère les infos nécessaire pour l'action
            string action_listing_nombre = Recherche_liste_menu("action_listing_nombre");
            string action_selection = Recherche_liste_menu("action_selection");
            string action_variable = Recherche_liste_menu("action_variable");

            // on vérifie la bonne présence des infos
            if (tag_menu_affichage == "false")
            {
                ligne_menu.affichage = false;
            }
            else ligne_menu.affichage = true;
            if (action_listing_nombre == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_listing_nombre n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_selection == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_selection n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_variable == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_variable n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }

            // on travaille les info au besoin
            string[] liste_choix ;
            string[] liste_separateur = new string[] { "-" };
            string[] liste_choix_exterieur = action_listing_nombre.Split(liste_separateur, StringSplitOptions.RemoveEmptyEntries);
            Int32 debut = Convert.ToInt32(liste_choix_exterieur[0]);
            Int32 fin = Convert.ToInt32(liste_choix_exterieur[1]);
            liste_choix = new string[(fin - debut) + 1];

            Int32 index = 0;
            for (Int32 i = debut; i < fin+1; i++)
            {
                liste_choix[index] = i.ToString();
                index++;
            }

            // on fournis les info à la ligne de menu
            ligne_menu.traduction = false;
            ligne_menu.choix_menu = liste_choix;
            ligne_menu.nbchoix = (fin - debut);
            ligne_menu.Text = liste_choix[0];
            ligne_menu.action = action_selection;
            ligne_menu.variable = action_variable;
            if (tag_menu_affichage == "false")
            {
                ligne_menu.affichage_dependance = tag_menu_affichage_dependance;
                ligne_menu.affichage_dependance_valeur = tag_menu_affichage_dependance_valeur;
            }

            // on ajoute la gestion du défilement dans le menu sur la ligne de menu :
            ligne_menu.MenuLeft_Selected += stringleftentrySelected;
            ligne_menu.MenuRight_Selected += stringrightentrySelected;
            ligne_menu.MenuDefilUpEntry_Selected += stringleftentrySelected;
            ligne_menu.MenuDefilDownEntry_Selected += stringrightentrySelected;

            liste_menu_option.Add(ligne_menu);

            return true;
        }

        bool traitement_Fichier(MenuEntry ligne_menu)
        {
            Traceur_menu_option.Trace("INFO", "Action Listing_Fichier");

            // on récupère les info sur l'affichage de la ligne de menu
            string tag_menu_affichage = Recherche_liste_menu("tag_menu_affichage");
            string tag_menu_affichage_dependance = Recherche_liste_menu("tag_menu_affichage_dependance");
            string tag_menu_affichage_dependance_valeur = Recherche_liste_menu("tag_menu_affichage_dependance_valeur");


            // on récupère les infos nécessaire pour l'action
            string action_menu_sous_repertoire = Recherche_liste_menu("action_menu_sous_repertoire");
            string action_menu_fichier_filtre = Recherche_liste_menu("action_menu_fichier_filtre");
            string action_menu_fichier_extension = Recherche_liste_menu("action_menu_fichier_extension");
            string action_selection = Recherche_liste_menu("action_selection");
            string action_variable = Recherche_liste_menu("action_variable");

            if (action_menu_sous_repertoire == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_menu_sous_repertoire n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_menu_fichier_filtre == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_menu_fichier_filtre n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_menu_fichier_extension == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_menu_fichier_extension n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_selection == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_selection n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }
            if (action_variable == "")
            {
                Traceur_menu_option.Trace("ERREUR", "action_variable n'a pas été fournis, menu d'option non pris en compte");
                return false;
            }

            if (tag_menu_affichage == "false")
            {
                ligne_menu.affichage = false;
            }

            // on fournis les info à la ligne de menu
            ligne_menu.choix_menu = Directory.GetFiles(chemin_acces_ressources + "\\" + Regle_jeu.Get_code_jeu() + "\\" + action_menu_sous_repertoire, action_menu_fichier_filtre + "*." + action_menu_fichier_extension);
            ligne_menu.nbchoix = ligne_menu.choix_menu.Count() - 1;
            for (int i = 0; i < ligne_menu.nbchoix + 1; i++)
            {
                ligne_menu.choix_menu[i] = ligne_menu.choix_menu[i].Replace(chemin_acces_ressources + "\\" + Regle_jeu.Get_code_jeu() + "\\" + action_menu_sous_repertoire + "\\", "");
            }
            ligne_menu.Text = ligne_menu.choix_menu[0];
            ligne_menu.traduction = false;
            ligne_menu.action = action_selection;
            ligne_menu.variable = action_variable;
            if (tag_menu_affichage == "false")
            {
                ligne_menu.affichage_dependance = tag_menu_affichage_dependance;
                ligne_menu.affichage_dependance_valeur = tag_menu_affichage_dependance_valeur;
            }

            // on ajoute la gestion du défilement dans le menu sur la ligne de menu :
            ligne_menu.MenuLeft_Selected += stringleftentrySelected;
            ligne_menu.MenuRight_Selected += stringrightentrySelected;
            ligne_menu.MenuDefilUpEntry_Selected += stringleftentrySelected;
            ligne_menu.MenuDefilDownEntry_Selected += stringrightentrySelected;

            liste_menu_option.Add(ligne_menu);
            return true;
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                               bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            // Ici on doit gérer les add et remove des différentes ligne de menu dans le cas d'affichage optionnel

            // on vide MenuEntries
            MenuEntries.Clear();         
            for (int i = 0; i < liste_menu_option.Count; i++)
            {
                // On test si l'affichage est obligatoire
                if (liste_menu_option[i].affichage)
                {
                    MenuEntries.Add(liste_menu_option[i]);
                }
                else
                {
                    // si affichage non obligatoire on test la condition d'affichage
                    Int32 dependance = Convert.ToInt32(liste_menu_option[i].affichage_dependance); 
                    if (liste_menu_option[i].affichage_dependance_valeur == liste_menu_option[dependance].Text)
                    {
                        MenuEntries.Add(liste_menu_option[i]);
                    }

                }

            }
            
        }

        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            foreach (MenuEntry menu in MenuEntries)
            {
                // pour chaque ligne on va récupérer les infos pour les fournir à la gestion de règle.
                // on regarde si l'action est à prendre en compte ou non
                Int32 dependance = Convert.ToInt32(menu.affichage_dependance);
                if (((menu.affichage) || (menu.affichage_dependance_valeur == MenuEntries[dependance].Text)) && menu.action != null)
                {
                    string action_selection = menu.action;
                    string action_variable = menu.variable;
                    string action_valeur = menu.choix_menu[menu.selectedChoix];

                    // A créer dans Gestion_Regles une fonction avec en paramètre action_selection, action_variable, action_valeur
                    Regle_jeu.Injection_donnees(action_selection, action_variable, action_valeur);

                }

            }
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());
        }
    }
}
