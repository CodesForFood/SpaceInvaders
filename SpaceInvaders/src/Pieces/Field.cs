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
    public class Field
    {
        public static Invader[,] InvaderFleet;

        /// <summary>
        /// X is the Right Wall, Y is the Floor;
        /// </summary>
        public static Vector2 Walls;

        public static bool GoingRight { get; set; } = true;


        public Field()
        {
            InvaderFleet = new Invader[10, 5];
            SetUpInvaders();
        }

        void SetUpInvaders()
        {
            for (int y = 0; y < InvaderFleet.GetLength(1); y++)
                for (int x = 0; x < InvaderFleet.GetLength(0); x++)
                {
                    InvaderFleet[x, y] = new Invader();
                    InvaderFleet[x, y].Border.Location = new Point((x * 60), (y * 50));
                }
        }

        public static void CheckForWall()
        {
            foreach (var vader in InvaderFleet)
            {
                if (vader.IsAlive)
                {
                    if ((vader.Border.X + vader.Border.Width) > Walls.X)
                    {
                        GoingRight = false;
                        GoDown();                        
                    }
                    else if ((vader.Border.X < 0))
                    {
                        GoingRight = true;
                        GoDown();                       
                    }
                }
            }
        }

        static void GoDown()
        {
            foreach (var vader in InvaderFleet)
            {
                vader.Border.Y += 4;                
            }         
        }
    }
}
