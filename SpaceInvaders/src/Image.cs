using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceInvaders.src
{
    public static class Image
    {

        public static Texture2D PlayerPic;
        public static Texture2D InvaderPic;
        public static Texture2D BulletPic;

        public static SpriteFont Font;


        public static void LoadTextures(Game g)
        {
            Font = g.Content.Load<SpriteFont>("RegularFont");
            PlayerPic = g.Content.Load<Texture2D>("GamePics/Tank");
            InvaderPic = g.Content.Load<Texture2D>("GamePics/Invader");
            BulletPic = g.Content.Load<Texture2D>("GamePics/Bullet");
        }

    }
}
