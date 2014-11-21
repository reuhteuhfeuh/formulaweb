#region File Description
//-----------------------------------------------------------------------------
// MenuScreen.cs
//
// XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
// 20130719 - Ajout menuLeft et menuRight pour défilement des langues et des jeux
// 20130805 - Ajout de la gestion défilement avec pageup et pagedown, les gachettes du pad et le scroll de la souris
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input;
using FormulaWeb;
#endregion

namespace FormulaWeb
{
    /// <summary>
    /// Base class for screens that contain a menu of options. The user can
    /// move up and down to select an entry, or cancel to back out of the screen.
    /// </summary>
    abstract class MenuScreen : GameScreen
    {
        #region Fields

        List<MenuEntry> menuEntries = new List<MenuEntry>();
        int selectedEntry = 0;
        string menuTitle;

        public Boolean traduction_partielle;

        InputAction menuUp;
        InputAction menuDown;
        InputAction menuSelect;
        InputAction menuCancel;
        InputAction menuLeft;
        InputAction menuRight;
        InputAction menuDefilUp;
        InputAction menuDefilDown;

        InputAction MenuA;
        InputAction MenuB;
        InputAction MenuC;
        InputAction MenuD;
        InputAction MenuE;
        InputAction MenuF;
        InputAction MenuG;
        InputAction MenuH;
        InputAction MenuI;
        InputAction MenuJ;
        InputAction MenuK;
        InputAction MenuL;
        InputAction MenuM;
        InputAction MenuN;
        InputAction MenuO;
        InputAction MenuP;
        InputAction MenuQ;
        InputAction MenuR;
        InputAction MenuS;
        InputAction MenuT;
        InputAction MenuU;
        InputAction MenuV;
        InputAction MenuW;
        InputAction MenuX;
        InputAction MenuY;
        InputAction MenuZ;
        InputAction Menu0;
        InputAction Menu1;
        InputAction Menu2;
        InputAction Menu3;
        InputAction Menu4;
        InputAction Menu5;
        InputAction Menu6;
        InputAction Menu7;
        InputAction Menu8;
        InputAction Menu9;
        InputAction MenuBack;
        InputAction MenuCapsLock;
        InputAction MenuShift;



        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of menu entries, so derived classes can add
        /// or change the menu contents.
        /// </summary>
        protected IList<MenuEntry> MenuEntries
        {
            get { return menuEntries; }
        }


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public MenuScreen(string menuTitle)
        {
            this.menuTitle = menuTitle;

            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            menuUp = new InputAction(
                new Buttons[] { Buttons.DPadUp, Buttons.LeftThumbstickUp }, 
                new Keys[] { Keys.Up },
                true);
            menuDown = new InputAction(
                new Buttons[] { Buttons.DPadDown, Buttons.LeftThumbstickDown },
                new Keys[] { Keys.Down },
                true);
            menuSelect = new InputAction(
                new Buttons[] { Buttons.A, Buttons.Start },
                new Keys[] { Keys.Enter, Keys.Space },
                true);
            menuCancel = new InputAction(
                new Buttons[] { Buttons.B, Buttons.Back },
                new Keys[] { Keys.Escape },
                true);
            menuLeft = new InputAction(
                new Buttons[] { Buttons.DPadLeft, Buttons.LeftThumbstickLeft },
                new Keys[] { Keys.Left },
                true);
            menuRight = new InputAction(
                new Buttons[] { Buttons.DPadRight, Buttons.LeftThumbstickRight },
                new Keys[] { Keys.Right },
                true);
            menuDefilUp = new InputAction(
                new Buttons[] { Buttons.LeftTrigger },
                new Keys[] { Keys.PageUp },
                true);
            menuDefilDown = new InputAction(
                new Buttons[] { Buttons.RightTrigger },
                new Keys[] { Keys.PageDown },
                true);

                MenuA = new InputAction( new Buttons[] {},new Keys[] { Keys.A }, true);
                MenuB = new InputAction( new Buttons[] {},new Keys[] { Keys.B }, true);
                MenuC = new InputAction( new Buttons[] {},new Keys[] { Keys.C }, true);
                MenuD = new InputAction( new Buttons[] {},new Keys[] { Keys.D }, true);
                MenuE = new InputAction( new Buttons[] {},new Keys[] { Keys.E }, true);
                MenuF = new InputAction( new Buttons[] {},new Keys[] { Keys.F }, true);
                MenuG = new InputAction( new Buttons[] {},new Keys[] { Keys.G }, true);
                MenuH = new InputAction( new Buttons[] {},new Keys[] { Keys.H }, true);
                MenuI = new InputAction( new Buttons[] {},new Keys[] { Keys.I }, true);
                MenuJ = new InputAction( new Buttons[] {},new Keys[] { Keys.J }, true);
                MenuK = new InputAction( new Buttons[] {},new Keys[] { Keys.K }, true);
                MenuL = new InputAction( new Buttons[] {},new Keys[] { Keys.L }, true);
                MenuM = new InputAction( new Buttons[] {},new Keys[] { Keys.M }, true);
                MenuN = new InputAction( new Buttons[] {},new Keys[] { Keys.N }, true);
                MenuO = new InputAction( new Buttons[] {},new Keys[] { Keys.O }, true);
                MenuP = new InputAction( new Buttons[] {},new Keys[] { Keys.P }, true);
                MenuQ = new InputAction( new Buttons[] {},new Keys[] { Keys.Q }, true);
                MenuR = new InputAction( new Buttons[] {},new Keys[] { Keys.R }, true);
                MenuS = new InputAction( new Buttons[] {},new Keys[] { Keys.S }, true);
                MenuT = new InputAction( new Buttons[] {},new Keys[] { Keys.T }, true);
                MenuU = new InputAction( new Buttons[] {},new Keys[] { Keys.U }, true);
                MenuV = new InputAction( new Buttons[] {},new Keys[] { Keys.V }, true);
                MenuW = new InputAction( new Buttons[] {},new Keys[] { Keys.W }, true);
                MenuX = new InputAction( new Buttons[] {},new Keys[] { Keys.X }, true);
                MenuY = new InputAction( new Buttons[] {},new Keys[] { Keys.Y }, true);
                MenuZ = new InputAction( new Buttons[] {},new Keys[] { Keys.Z }, true);
                Menu0 = new InputAction( new Buttons[] {},new Keys[] { Keys.D0, Keys.NumPad0 }, true);
                Menu1 = new InputAction( new Buttons[] {},new Keys[] { Keys.D1, Keys.NumPad1 }, true);
                Menu2 = new InputAction( new Buttons[] {},new Keys[] { Keys.D2, Keys.NumPad2 }, true);
                Menu3 = new InputAction( new Buttons[] {},new Keys[] { Keys.D3, Keys.NumPad3 }, true);
                Menu4 = new InputAction( new Buttons[] {},new Keys[] { Keys.D4, Keys.NumPad4 }, true);
                Menu5 = new InputAction( new Buttons[] {},new Keys[] { Keys.D5, Keys.NumPad5 }, true);
                Menu6 = new InputAction( new Buttons[] {},new Keys[] { Keys.D6, Keys.NumPad6 }, true);
                Menu7 = new InputAction( new Buttons[] {},new Keys[] { Keys.D7, Keys.NumPad7 }, true);
                Menu8 = new InputAction( new Buttons[] {},new Keys[] { Keys.D8, Keys.NumPad8 }, true);
                Menu9 = new InputAction( new Buttons[] {},new Keys[] { Keys.D9, Keys.NumPad9 }, true);
                MenuBack = new InputAction(new Buttons[] { }, new Keys[] { Keys.Back }, true);
                MenuCapsLock = new InputAction(new Buttons[] { }, new Keys[] { Keys.CapsLock }, false);
                MenuShift = new InputAction(new Buttons[] { }, new Keys[] { Keys.LeftShift, Keys.RightShift}, false);




        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Responds to user input, changing the selected entry and accepting
        /// or cancelling the menu.
        /// </summary>
        public override void HandleInput(GameTime gameTime, InputState input)
        {
            // For input tests we pass in our ControllingPlayer, which may
            // either be null (to accept input from any player) or a specific index.
            // If we pass a null controlling player, the InputState helper returns to
            // us which player actually provided the input. We pass that through to
            // OnSelectEntry and OnCancel, so they can tell which player triggered them.
            PlayerIndex playerIndex;

            if (traduction_partielle)
            {
                if (MenuCapsLock.Evaluate(input, ControllingPlayer, out playerIndex) || MenuShift.Evaluate(input, ControllingPlayer, out playerIndex) )
                {
                    if (MenuA.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "A"; }
                    if (MenuB.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "B"; }
                    if (MenuC.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "C"; }
                    if (MenuD.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "D"; }
                    if (MenuE.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "E"; }
                    if (MenuF.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "F"; }
                    if (MenuG.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "G"; }
                    if (MenuH.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "H"; }
                    if (MenuI.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "I"; }
                    if (MenuJ.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "J"; }
                    if (MenuK.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "K"; }
                    if (MenuL.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "L"; }
                    if (MenuM.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "M"; }
                    if (MenuN.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "N"; }
                    if (MenuO.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "O"; }
                    if (MenuP.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "P"; }
                    if (MenuQ.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "Q"; }
                    if (MenuR.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "R"; }
                    if (MenuS.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "S"; }
                    if (MenuT.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "T"; }
                    if (MenuU.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "U"; }
                    if (MenuV.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "V"; }
                    if (MenuW.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "W"; }
                    if (MenuX.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "X"; }
                    if (MenuY.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "Y"; }
                    if (MenuZ.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "Z"; }
                }
                else
                {
                    if (MenuA.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "a"; }
                    if (MenuB.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "b"; }
                    if (MenuC.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "c"; }
                    if (MenuD.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "d"; }
                    if (MenuE.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "e"; }
                    if (MenuF.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "f"; }
                    if (MenuG.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "g"; }
                    if (MenuH.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "h"; }
                    if (MenuI.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "i"; }
                    if (MenuJ.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "j"; }
                    if (MenuK.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "k"; }
                    if (MenuL.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "l"; }
                    if (MenuM.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "m"; }
                    if (MenuN.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "n"; }
                    if (MenuO.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "o"; }
                    if (MenuP.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "p"; }
                    if (MenuQ.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "q"; }
                    if (MenuR.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "r"; }
                    if (MenuS.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "s"; }
                    if (MenuT.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "t"; }
                    if (MenuU.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "u"; }
                    if (MenuV.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "v"; }
                    if (MenuW.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "w"; }
                    if (MenuX.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "x"; }
                    if (MenuY.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "y"; }
                    if (MenuZ.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "z"; }
                }

                if (Menu0.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "0"; }
                if (Menu1.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "1"; }
                if (Menu2.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "2"; }
                if (Menu3.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "3"; }
                if (Menu4.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "4"; }
                if (Menu5.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "5"; }
                if (Menu6.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "6"; }
                if (Menu7.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "7"; }
                if (Menu8.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "8"; }
                if (Menu9.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "9"; }
                /*if (Menua.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "a"; }
                if (Menub.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "b"; }
                if (Menuc.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "c"; }
                if (Menud.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "d"; }
                if (Menue.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "e"; }
                if (Menuf.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "f"; }
                if (Menug.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "g"; }
                if (Menuh.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "h"; }
                if (Menui.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "i"; }
                if (Menuj.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "j"; }
                if (Menuk.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "k"; }
                if (Menul.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "l"; }
                if (Menum.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "m"; }
                if (Menun.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "n"; }
                if (Menuo.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "o"; }
                if (Menup.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "p"; }
                if (Menuq.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "q"; }
                if (Menur.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "r"; }
                if (Menus.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "s"; }
                if (Menut.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "t"; }
                if (Menuu.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "u"; }
                if (Menuv.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "v"; }
                if (Menuw.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "w"; }
                if (Menux.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "x"; }
                if (Menuy.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "y"; }
                if (Menuz.Evaluate(input, ControllingPlayer, out playerIndex)) { menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage + "z"; }
                */
                // cas du retour chariot
                if (MenuBack.Evaluate(input, ControllingPlayer, out playerIndex)) 
                {
                    if (menuEntries[selectedEntry].complement_affichage.Length > 0)
                    {
                        menuEntries[selectedEntry].complement_affichage = menuEntries[selectedEntry].complement_affichage.Substring(0,menuEntries[selectedEntry].complement_affichage.Length-1) ;
                    }
                }
            }

            // Move to the previous menu entry?
            if (menuUp.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                selectedEntry--;

                if (selectedEntry < 0)
                    selectedEntry = menuEntries.Count - 1;
            }

            // Move to the next menu entry?
            if (menuDown.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                selectedEntry++;

                if (selectedEntry >= menuEntries.Count)
                    selectedEntry = 0;
            }

            // Test position souris et recherche si positionnement sur un menu entry pour la passe en IsSelected
            // On regarde d'abords s'il y a eu mouvement de souris ou non, si pas de mouvement alors on ignore la mouvement
            if ((input.CurrentMouseStates.X == input.LastMouseStates.X) & (input.CurrentMouseStates.Y == input.LastMouseStates.Y))
            {
                // on ignore pour le moment, on ne mets pas à jour le menu
            }
            else
            {
                // On recupère les coordonnées de la souris
                Vector2 pos_souris = new Vector2(input.CurrentMouseStates.X, input.CurrentMouseStates.Y);
                // on teste la position par rapport à une tolérance autour de la position Y des menu

                foreach (MenuEntry menutest in menuEntries)
                {
                    float limit_sup = menutest.Position.Y * 1.05f;
                    float limit_inf = menutest.Position.Y * 0.95f;
                    if ((pos_souris.Y > limit_inf) & (pos_souris.Y < limit_sup))
                    {
                        // langage_en_cours = code_langage_dispo.FindIndex(lang => lang == Code_Langage);
                        selectedEntry = menuEntries.FindIndex(menu => menu == menutest);
                    }
                }
            }

            // test click droit souris pour validation à refaire plus propre en passant pour inputaction peut etre
            if ((input.CurrentMouseStates.LeftButton == ButtonState.Pressed) & (input.LastMouseStates.LeftButton == ButtonState.Released))
            {
                OnSelectEntry(selectedEntry, playerIndex);
            }

            if (menuSelect.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                OnSelectEntry(selectedEntry, playerIndex);
            }
            else if (menuCancel.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                OnCancel(playerIndex);
            }

            if (menuLeft.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                OnMenuLeftEntry(selectedEntry, playerIndex);
            }

            if (menuRight.Evaluate(input, ControllingPlayer, out playerIndex))
            {
                OnMenuRightEntry(selectedEntry, playerIndex);
            }

            if ((menuDefilUp.Evaluate(input, ControllingPlayer, out playerIndex)) | (input.CurrentMouseStates.ScrollWheelValue > input.LastMouseStates.ScrollWheelValue ))
            {
                OnMenuDefilUpEntry(selectedEntry, playerIndex);                
            }

            if ((menuDefilDown.Evaluate(input, ControllingPlayer, out playerIndex)) | (input.CurrentMouseStates.ScrollWheelValue < input.LastMouseStates.ScrollWheelValue))
            {
                OnMenuDefilDownEntry(selectedEntry, playerIndex);
            }
        }


        /// <summary>
        /// Handler for when the user has chosen a menu entry.
        /// </summary>
        protected virtual void OnSelectEntry(int entryIndex, PlayerIndex playerIndex)
        {
            menuEntries[entryIndex].OnSelectEntry(playerIndex);
        }

        protected virtual void OnMenuLeftEntry(int entryIndex, PlayerIndex playerIndex)
        {
            menuEntries[entryIndex].OnMenuLeftEntry(playerIndex);
        }

        protected virtual void OnMenuRightEntry(int entryIndex, PlayerIndex playerIndex)
        {
            menuEntries[entryIndex].OnMenuRightEntry(playerIndex);
        }

        protected virtual void OnMenuDefilUpEntry(int entryIndex, PlayerIndex playerIndex)
        {
            menuEntries[entryIndex].OnMenuDefilUpEntry(playerIndex);
        }

        protected virtual void OnMenuDefilDownEntry(int entryIndex, PlayerIndex playerIndex)
        {
            menuEntries[entryIndex].OnMenuDefilDownEntry(playerIndex);
        }


        /// <summary>
        /// Handler for when the user has cancelled the menu.
        /// </summary>
        protected virtual void OnCancel(PlayerIndex playerIndex)
        {
            ExitScreen();
        }


        /// <summary>
        /// Helper overload makes it easy to use OnCancel as a MenuEntry event handler.
        /// </summary>
        protected void OnCancel(object sender, PlayerIndexEventArgs e)
        {
            OnCancel(e.PlayerIndex);
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Allows the screen the chance to position the menu entries. By default
        /// all menu entries are lined up in a vertical list, centered on the screen.
        /// </summary>
        protected virtual void UpdateMenuEntryLocations()
        {
            // Make the menu slide into place during transitions, using a
            // power curve to make things look more interesting (this makes
            // the movement slow down as it nears the end).
            float transitionOffset = (float)Math.Pow(TransitionPosition, 2);

            // start at Y = 175; each X value is generated per entry
            Vector2 position = new Vector2(0f, 175f);

            // update each menu entry's location in turn
            for (int i = 0; i < menuEntries.Count; i++)
            {
                MenuEntry menuEntry = menuEntries[i];
                
                // each entry is to be centered horizontally
                if (menuEntry.centrage != "Left") 
                    position.X = ScreenManager.GraphicsDevice.Viewport.Width / 2 - menuEntry.GetWidth(this) / 2;            
                    

                if (ScreenState == ScreenState.TransitionOn)
                    position.X -= transitionOffset * 256;
                else
                    position.X += transitionOffset * 512;

                // set the entry's position
                menuEntry.Position = position;

                // move down for the next entry the size of this entry
                position.Y += menuEntry.GetHeight(this);
            }
        }


        /// <summary>
        /// Updates the menu.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            // Update each nested MenuEntry object.
            for (int i = 0; i < menuEntries.Count; i++)
            {
                bool isSelected = IsActive && (i == selectedEntry);

                menuEntries[i].Update(this, isSelected, gameTime);
            }
        }


        /// <summary>
        /// Draws the menu.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // make sure our entries are in the right place before we draw them
            UpdateMenuEntryLocations();

            GraphicsDevice graphics = ScreenManager.GraphicsDevice;
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;

            spriteBatch.Begin();

            // Draw each menu entry in turn.
            for (int i = 0; i < menuEntries.Count; i++)
            {
                MenuEntry menuEntry = menuEntries[i];

                bool isSelected = IsActive && (i == selectedEntry);
                menuEntry.Draw(this, isSelected, gameTime);
            }

            // Make the menu slide into place during transitions, using a
            // power curve to make things look more interesting (this makes
            // the movement slow down as it nears the end).
            float transitionOffset = (float)Math.Pow(TransitionPosition, 2);

            // Draw the menu title centered on the screen
            string titre_traduit;
            titre_traduit = ScreenManager.langScreenManager.Get_Traduction(menuTitle);
            Vector2 titlePosition = new Vector2(graphics.Viewport.Width / 2, 80);
            Vector2 titleOrigin = font.MeasureString(titre_traduit) / 2;
            Color titleColor = new Color(192, 192, 192) * TransitionAlpha;
            float titleScale = 1.25f;

            titlePosition.Y -= transitionOffset * 100;

            spriteBatch.DrawString(font, titre_traduit, titlePosition, titleColor, 0,
                                   titleOrigin, titleScale, SpriteEffects.None, 0);

            spriteBatch.End();
        }


        #endregion

        public void Set_String_Left()
        {
            MenuEntry menu = menuEntries[selectedEntry];
            menu.selectedChoix--;
            if (menu.selectedChoix < 0) menu.selectedChoix = menu.nbchoix;
            menu.Text = menu.choix_menu[menu.selectedChoix];
        }

        public void Set_String_Right()
        {
            MenuEntry menu = menuEntries[selectedEntry];
            menu.selectedChoix++;
            if (menu.selectedChoix > menu.nbchoix) menu.selectedChoix = 0;
            menu.Text = menu.choix_menu[menu.selectedChoix];
        }

        public string Get_String()
        {
            MenuEntry menu = menuEntries[selectedEntry];
            return menu.choix_menu[menu.selectedChoix];
        }
    }
}
