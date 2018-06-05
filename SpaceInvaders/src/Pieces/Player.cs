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
    public class Player
    {
        public string Name { get; set; }
        public Rectangle Border;
        public int Score { get; set; }

        public List<Bullet> Ammo;


        public Player(string name)
        {
            Name = name;
            Score = 0;
            Border = new Rectangle(Point.Zero, new Point(32));
            Ammo = new List<Bullet>();
            SpawnPlayer();
        }


        public void SpawnPlayer()
        {
            Border.Location = new Point(10, (int)Field.Walls.Y);
        }


    }
}
