using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.src.Pieces;
using SpaceInvaders.src.GUI;


namespace SpaceInvaders.src
{
    public class Screen
    {
        GraphicsDeviceManager GDM;

        Display display;





        public SpriteBatch Batch { get; set; }

        public Screen(GraphicsDeviceManager gdm)
        {
            GDM = gdm;
            display = new Display();
            
        }


        public void ShowField()
        {
            foreach(var vader in Field.InvaderFleet)
            {
                if (vader.IsAlive) 
                Batch.Draw(Image.InvaderPic, vader.Border, Color.White);
            }
        }

        public void ShowPlayer(Player p)
        {
            Batch.Draw(Image.PlayerPic, p.Border, Color.White);
        }

        public void ShowDisplay()
        {
            Batch.Draw(Image.BulletPic, display.MainBorder, Color.White);
        }

        public void ShowButtons()
        {
            foreach(var btn in display.ButtonList)
            {
                Batch.Draw(Image.BulletPic, btn.Border, Color.Red);
                Batch.DrawString(Image.Font, btn.Text ,btn.TextLoc, Color.Black);
            }
        }

        public void ShowBullets(Player p)
        {
            if (p.Ammo.Count > 0)
            {
                foreach (var bullet in p.Ammo)
                {
                    if (bullet.BeingFired)
                    {
                        Batch.Draw(Image.BulletPic, bullet.Border, Color.White);
                    }
                }
            }
        }

        public void ShowScore(Player p)
        {
            Batch.DrawString(Image.Font, "Score: " + p.Score.ToString(), new Vector2(Field.Walls.X, 10), Color.Black);
        }     


    }
}
