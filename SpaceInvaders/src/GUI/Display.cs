using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.src.Pieces;


namespace SpaceInvaders.src.GUI
{
    public class Display
    {
        public Rectangle MainBorder;

        public static List<Button> ButtonList;

        public Display()
        {
            var loc = new Point((int)Field.Walls.X, 0);
            var size = new Point((int)(MainGame.ScreenWidth - Field.Walls.X), MainGame.ScreenHeight);
            MainBorder = new Rectangle(loc,size);
            ButtonList = new List<Button>();

            AddButtons();
        }

        void AddButtons()
        {
            ButtonList.Add(new Button(1, "Reset", new Point((int)Field.Walls.X,30)));
        }



    }
}
