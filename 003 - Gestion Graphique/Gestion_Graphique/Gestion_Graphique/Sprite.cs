using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Gestion_Graphique
{
    class Sprite
    {
        // Variables utilisées pour versionning
        private string Version = "0.0.0.5";

        // Création du graphique manager, lien avec la carte graphique
        GraphicsDeviceManager graphics;

        // Création du sprite Batch objet pour dessiner sur l'écran de jeu
        SpriteBatch spriteBatch;

        // Création du content manager 
        ContentManager Content;

        // Création du Game
        Game game;

        private Texture2D FormulaWeb_Sprite = null;
        private Vector2 FormulaWeb_Sprite_Position;
        private Rectangle rectangle_destination;
        private Double Angle;
        private Double Ratio = 1;

        public bool Initialize(GraphicsDeviceManager gra, SpriteBatch spr, ContentManager con, Game gam)
        {
            graphics = gra;
            spriteBatch = spr;
            Content = con;
            game = gam;
            rectangle_destination = new Rectangle();
            Angle = 0;
            return true;
        }

        public int Get_Hauteur_Sprite()
        {
            return FormulaWeb_Sprite.Height;
        }

        public bool Set_Ratio_Sprite(double Ratio_Sprite)
        {
            Ratio = Ratio_Sprite ;
            return true;
        }

        public int Get_Largeur_Sprite()
        {
            return FormulaWeb_Sprite.Width;
        }

        public bool Set_Image(string Image_A_Charger)
        {
            FormulaWeb_Sprite = Content.Load<Texture2D>(Image_A_Charger);
            return true;
        }

        public bool Set_Angle(double Angle_A_Afficher)
        {
            Angle = Angle_A_Afficher;
            return true;
        }

        public bool Charger_Image(string Image_Externe)
        {
            FormulaWeb_Sprite = LoadTexture(Image_Externe);
            return true;
        }

        public bool Afficher_Sprite()
        {

            if (rectangle_destination.IsEmpty)
            {
                spriteBatch.Draw(FormulaWeb_Sprite, FormulaWeb_Sprite_Position, Color.White);
            }
            else 
            {
                    spriteBatch.Draw(FormulaWeb_Sprite, rectangle_destination, null, Color.White,(float)Angle,new Vector2(FormulaWeb_Sprite.Width/2,FormulaWeb_Sprite.Height/2),SpriteEffects.None,0);
            }
            return true;
        }

        public bool Set_Position(Vector2 FormulaWeb_Sprite_Vector2)
        {
            FormulaWeb_Sprite_Position = FormulaWeb_Sprite_Vector2;
            return true;
        }

        public bool Set_Destination(Rectangle Formulaweb_Sprite_Rectancle)
        {
            rectangle_destination = Formulaweb_Sprite_Rectancle;
            return true;
        }

        
        public Texture2D LoadTexture(string path)
        {
            //using (Stream stream = new File.Open(path, FileMode.Open)) //On ouvre un stream vers notre image
            //{
            Texture2D texture;
            Stream stream;
            stream = null;
            //filestream = File.Open(path, FileMode.Open);
            stream = new FileStream(path, FileMode.Open);
            texture = Texture2D.FromStream(game.GraphicsDevice, stream); //On charge la texture via le stream
            PremultiplyYourAlpha(texture); //On pré-multiplie l'alpha pour la transparence
            return texture;
            //}
        }

        public static void PremultiplyYourAlpha(Texture2D texture)
        {
            Color[] pixels = new Color[texture.Width * texture.Height];
            texture.GetData(pixels);
            for (int i = 0; i < pixels.Length; i++)
            {
                Color p = pixels[i];
                pixels[i] = new Color(p.R, p.G, p.B) * (p.A / 255f);
            }
            texture.SetData(pixels);
        }
         
    }
}
