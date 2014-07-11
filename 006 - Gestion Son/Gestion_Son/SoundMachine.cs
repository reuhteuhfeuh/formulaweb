#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Traceur;

#endregion

namespace Gestion_Son
{
    public class SoundMachine
    {
        ContentManager Content_Music;
        GraphicsDeviceManager graphics_Music;
        
        SoundEffect Theme;
        SoundEffect Menu_Deplacement;



        Traceur.Traceur Son_Traceur;

        public void Allumage_ampli(ContentManager con, GraphicsDeviceManager gdm, Traceur.Traceur tra)
        {
            Content_Music = con;
            graphics_Music = gdm;
            Son_Traceur = tra;
        }

        public bool Ecouter_musique(string Morceau)
        {
            MediaPlayer.Stop();
            try
            {
                //Theme = Content_Music.Load<Song>(Morceau+".wma");
                Theme = Content_Music.Load<SoundEffect>("Musique\\"+Morceau+".wav");
            }
            catch
            {
                Son_Traceur.Trace("Alerte", "Impossible de charger theme : " + Morceau);
                return false;
            }

            var bidule = Theme.CreateInstance();
            bidule.IsLooped = true;
            bidule.Play();
            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Play(Theme);
            
            
            return true;
        }

        public bool Jouer_effet(string Effet)
        {
            try
            {
                Menu_Deplacement = Content_Music.Load<SoundEffect>(Effet);
            }
            catch
            {
                Son_Traceur.Trace("Alerte", "Impossible de charger effet : " + Effet);
                return false;
            }

            Menu_Deplacement.Play();
            return true;
        }
    }
}
