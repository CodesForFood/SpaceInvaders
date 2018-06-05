using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceInvaders.src.GUI
{
    public class Button
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Rectangle Border;

        public Vector2 TextLoc
        {
            get
            { // 1/4  of the buttons width and 1/2 the buttons height;
                Vector2 loc = new Vector2();
                loc.X = (float)(Border.X + (.25 * Border.Width));
                loc.Y = (float)(Border.Y + (.25 * Border.Height));
                return loc;
            }
        }

        public Button(int id, string text, Point loc)
        {
            Id = id;
            Text = text;
            Border = new Rectangle(loc, new Point(100, 50));
        }

        public void SetButtonLoc(Point loc)
        {
            Border.Location = loc;
        }

    }
}
