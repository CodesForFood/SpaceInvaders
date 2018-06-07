using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.src.Pieces;
using SpaceInvaders.src.GUI;

namespace SpaceInvaders.src
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen screen;
        Field field;
        Controller control;
        Player player;
        

        public static int ScreenHeight
        {
            get { return graphics.PreferredBackBufferHeight; }
            set { graphics.PreferredBackBufferHeight = value; }
        }

        public static int ScreenWidth
        {
            get { return graphics.PreferredBackBufferWidth; }
            set { graphics.PreferredBackBufferWidth = value; }
        }

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";                     

            ScreenHeight = 700;
            ScreenWidth = 1200;

            Field.Walls.X = ScreenWidth - (float)(ScreenWidth * .2);
            Field.Walls.Y = ScreenHeight - (float)(ScreenHeight * .2);
        }
     
        protected override void Initialize()
        {
            IsMouseVisible = true;
            Image.LoadTextures(this);
            screen = new Screen(graphics);
            field = new Field();
            control = new Controller();
            player = new Player("Human");


            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen.Batch = spriteBatch;

        }


        protected override void UnloadContent() { Content.Unload(); }
         
        protected override void Update(GameTime gameTime)
        {
            control.UpdateState();

            control.AI();
            control.MovePlayer(player);
            control.FireBullets(player);
            control.BulletPhysics(player);
            control.ListenForButtons(player);

            control.UpdateOldState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();           

            screen.ShowField();
            screen.ShowDisplay();
            screen.ShowButtons();
            screen.ShowScore(player);

            screen.ShowPlayer(player);           
            screen.ShowBullets(player);

            screen.ShowDebug();
            

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
