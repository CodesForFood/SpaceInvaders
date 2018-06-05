using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceInvaders.src.Pieces
{
    public class Bullet
    {
        public Rectangle Border;
        public bool BeingFired { get; set; } = true;


        public Bullet(Player p)
        {
            var loc = new Point(p.Border.X + (p.Border.Width / 2), p.Border.Y);
            var size = new Point(10, 20);

            Border = new Rectangle(loc, size);
        }


    }
}
