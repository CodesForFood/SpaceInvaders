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
    public class Invader
    {

        public Rectangle Border;
        public bool IsAlive { get; set; } = true;
        public static int Speed { get; set; } = 1;


        public Invader()
        {
            Border = new Rectangle(Point.Zero, new Point(32));
        }

        

        

    }
}
