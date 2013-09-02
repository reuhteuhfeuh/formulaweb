#region File Description
//-----------------------------------------------------------------------------
// MenuEntry.cs
//
// XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FormulaWeb;
#endregion

namespace FormulaWeb
{
    /// <summary>
    /// Helper class represents a single entry in a MenuScreen. By default this
    /// just draws the entry text string, but it can be customized to display menu
    /// entries in different ways. This also provides an event that will be raised
    /// when the menu entry is selected.
    /// </summary>
    class MenuEntry
    {
        #region Fields

        /// <summary>
        /// The text rendered for this entry.
        /// </summary>
        string text;

        /// <summary>
        /// Tracks a fading selection effect on the entry.
        /// </summary>
        /// <remarks>
        /// The entries transition out of the selection effect when they are deselected.
        /// </remarks>
        float selectionFade;

        /// <summary>
        /// The position at which the entry is drawn. This is set by the MenuScreen
        /// each frame in Update.
        /// </summary>
        Vector2 position;

        /// <summary>
        /// Ces données sont essentielles à la traduction et à la génération
        /// optionnelles des lignes de menus
        /// <remarks>
        /// Données ajoutées dans le cadre du developpement de formulaWeb
        /// </remarks>
        /// </summary>
        
        // Gestion du défilement de string pour les menu optionnels
        public string[] choix_menu { get; set; }
        public int selectedChoix { get; set; }
        public int nbchoix { get; set; }
        public string action { get; set; }
        public string variable { get; set; }
  
        // Gestion de l'affichage optionnel
        public bool affichage { get; set; }
        public string affichage_dependance { get; set; }
        public string affichage_dependance_valeur { get; set; }

        // Gestion de la traduction
        public bool traduction { get; set; }
        public bool chgt_lang { get; set; }
        public string chgt_lang_choix { get; set; }

        #endregion

        #region Properties

        /*
        public bool Chgt_lang
        {
            get { return chgt_lang; }
            set { chgt_lang = value; }
        }*/

        /*
        public string Chgt_lang_choix
        {
            get { return chgt_lang_choix; }
            set { chgt_lang_choix = value; }
        }*/

        /*
        public bool Traduction
        {
            get { return traduction; }
            set { traduction = value; }
        }*/

        public string centrage { get; set; } //Center ou Left
        /// <summary>
        /// Gets or sets the text of this menu entry.
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }


        /// <summary>
        /// Gets or sets the position at which to draw this menu entry.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }


        #endregion

        #region Events


        /// <summary>
        /// Event raised when the menu entry is selected.
        /// Création d'un event personnalise
        /// </summary>
        public event EventHandler<PlayerIndexEventArgs> Selected;

        /// <summary>
        /// Method for raising the Selected event.
        /// Methode assigne à l'event personnalise
        /// </summary>
        protected internal virtual void OnSelectEntry(PlayerIndex playerIndex)
        {
            if (Selected != null)
                Selected(this, new PlayerIndexEventArgs(playerIndex));
        }

        public event EventHandler<PlayerIndexEventArgs> MenuLeft_Selected;
        protected internal virtual void OnMenuLeftEntry(PlayerIndex playerIndex)
        {
            if (MenuLeft_Selected != null)
                MenuLeft_Selected(this, new PlayerIndexEventArgs(playerIndex));
        }

        public event EventHandler<PlayerIndexEventArgs> MenuRight_Selected;
        protected internal virtual void OnMenuRightEntry(PlayerIndex playerIndex)
        {
            if (MenuRight_Selected != null)
                MenuRight_Selected(this, new PlayerIndexEventArgs(playerIndex));
        }

        public event EventHandler<PlayerIndexEventArgs> MenuDefilUpEntry_Selected;
        protected internal virtual void OnMenuDefilUpEntry(PlayerIndex playerIndex)
        {
            if (MenuDefilUpEntry_Selected != null)
                MenuDefilUpEntry_Selected(this, new PlayerIndexEventArgs(playerIndex));
        }

        public event EventHandler<PlayerIndexEventArgs> MenuDefilDownEntry_Selected;
        protected internal virtual void OnMenuDefilDownEntry(PlayerIndex playerIndex)
        {
            if (MenuDefilDownEntry_Selected != null)
                MenuDefilDownEntry_Selected(this, new PlayerIndexEventArgs(playerIndex));
        }

        #endregion

        #region Initialization


        /// <summary>
        /// Constructs a new menu entry with the specified text.
        /// </summary>
        public MenuEntry(string text)
        {
            this.text = text;
            traduction = true;
            affichage = true;
            chgt_lang_choix = "FR";
            chgt_lang = false;
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the menu entry.
        /// </summary>
        public virtual void Update(MenuScreen screen, bool isSelected, GameTime gameTime)
        {
            // there is no such thing as a selected item on Windows Phone, so we always
            // force isSelected to be false
#if WINDOWS_PHONE
            isSelected = false;
#endif

            // When the menu selection changes, entries gradually fade between
            // their selected and deselected appearance, rather than instantly
            // popping to the new state.
            float fadeSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds * 4;

            if (isSelected)
                selectionFade = Math.Min(selectionFade + fadeSpeed, 1);
            else
                selectionFade = Math.Max(selectionFade - fadeSpeed, 0);
        }


        /// <summary>
        /// Draws the menu entry. This can be overridden to customize the appearance.
        /// </summary>
        public virtual void Draw(MenuScreen screen, bool isSelected, GameTime gameTime)
        {
            // there is no such thing as a selected item on Windows Phone, so we always
            // force isSelected to be false
#if WINDOWS_PHONE
            isSelected = false;
#endif



            // Draw text, centered on the middle of each line.
            ScreenManager screenManager = screen.ScreenManager;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;


            // Traduction en live pour bien prendre en compte les changements de langue.
            string text_traduit;

            if (traduction)
            {
                text_traduit = screenManager.langScreenManager.Get_Traduction(text);
            }
            else
            {
                text_traduit = text.Trim();
            }

            // Draw the selected entry in yellow, otherwise white.
            Color color = isSelected ? Color.Yellow : Color.White;

            // Pulsate the size of the selected menu entry.
            double time = gameTime.TotalGameTime.TotalSeconds;

            float pulsate = (float)Math.Sin(time * 6) + 1;

            float scale = 1 + pulsate * 0.05f * selectionFade;

            // Modify the alpha to fade text out during transitions.
            color *= screen.TransitionAlpha;

            Vector2 origin = new Vector2(0, font.LineSpacing / 2);

            if (affichage)
            spriteBatch.DrawString(font, text_traduit, position, color, 0,
                                   origin, scale, SpriteEffects.None, 0);
        }


        /// <summary>
        /// Queries how much space this menu entry requires.
        /// </summary>
        public virtual int GetHeight(MenuScreen screen)
        {
            return screen.ScreenManager.Font.LineSpacing;
        }


        /// <summary>
        /// Queries how wide the entry is, used for centering on the screen.
        /// </summary>
        public virtual int GetWidth(MenuScreen screen)
        {
            // On donne la dimension de la traduction
            ScreenManager screenManager = screen.ScreenManager;
            string text_traduit;
            if (traduction)
            {
                return (int)screen.ScreenManager.Font.MeasureString(text_traduit = screenManager.langScreenManager.Get_Traduction(text)).X;
            }
            else
            {
                return (int)screen.ScreenManager.Font.MeasureString(text).X;
            }
        }


        #endregion

    }
}
