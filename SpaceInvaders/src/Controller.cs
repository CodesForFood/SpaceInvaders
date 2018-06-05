using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.src.Pieces;


namespace SpaceInvaders.src
{
    public class Controller
    {

        public KeyboardState kState, oldKState;
        public MouseState mState, oldMState;

        Vector2 MousePos;

        public Controller()
        {
            UpdateState();
            UpdateOldState();
            MousePos = new Vector2(0, 0);
        }

        bool HeldK(Keys key) { return kState.IsKeyDown(key); }
        bool OnceK(Keys key) { return kState.IsKeyDown(key) && !oldKState.IsKeyDown(key); }

        bool OnceLeftM() { return mState.LeftButton == ButtonState.Pressed && oldMState.LeftButton != ButtonState.Pressed; }

        public void UpdateState()
        {
            kState = Keyboard.GetState();
            mState = Mouse.GetState();

            MousePos.X = mState.X;
            MousePos.Y = mState.Y;
        }

        public void UpdateOldState()
        {
            oldKState = Keyboard.GetState();
            oldMState = Mouse.GetState();

            MousePos.X = oldMState.X;
            MousePos.Y = oldMState.Y;
        }

        public void AI()
        {
            MoveInvadars();
            Field.CheckForWall();
        }


        public void MoveInvadars()
        {
            foreach(var vader in Field.InvaderFleet)
            {
                if (Field.GoingRight)
                {
                    vader.Border.X += Invader.Speed;                                      
                }
                else
                {
                    vader.Border.X -= Invader.Speed;                   
                }
            }
        }

        public void MovePlayer(Player p)
        {
            if (HeldK(Keys.Left) && p.Border.X > 0) { p.Border.X -= 3; }
            else if (HeldK(Keys.Right) && (p.Border.X + p.Border.Width) < Field.Walls.X) { p.Border.X += 3; }

        }

        public void FireBullets(Player p)
        {
            if (OnceK(Keys.Space) && p.Ammo.Count  <= 3)
            {
                p.Ammo.Add(new Bullet(p));
            }
        }

        public void BulletPhysics(Player p)
        {
            foreach(var bullet in p.Ammo)
            {
                if (bullet.BeingFired)
                {
                    bullet.Border.Y -= 5;
                }
            }

            try
            {
                foreach (var vader in Field.InvaderFleet)
                    foreach (var bullet in p.Ammo)
                    {
                        if (vader.Border.Intersects(bullet.Border) && vader.IsAlive)
                        {
                            vader.IsAlive = false;
                            bullet.BeingFired = false;
                            p.Ammo.Remove(bullet);
                            p.Score += 10;
                        }
                        else if(bullet.Border.Y <= 0)
                        {
                            bullet.BeingFired = false;
                            p.Ammo.Remove(bullet);
                        }                                          
                    }
            }
            catch (Exception) { }
        }



    }
}
