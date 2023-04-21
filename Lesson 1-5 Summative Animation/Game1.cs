using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lesson_1_5_Summative_Animation
{
    public class Game1 : Game
    {
        Texture2D introTexture;
        Rectangle introRect;
        Texture2D mainBackgroundTexture;
        Rectangle mainBackgroundRect;
        Texture2D deloreanTexture;
        Rectangle deloreanRect;
        private SpriteFont titleFont;
        enum Screen
        {
            Intro,
            MainScreen,
            MainScreen2,
            End
        }
        Screen screen;
        MouseState mouseState;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            this.Window.Title = "'' Animation";

            introRect = new Rectangle(0, 0, 800, 600);
            mainBackgroundRect = new Rectangle(0, 0, 800, 600);
            deloreanRect = new Rectangle(325, 165, 130, 100);
            screen = Screen.Intro;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            titleFont = Content.Load<SpriteFont>("title");
            introTexture = Content.Load<Texture2D>("intro");
            mainBackgroundTexture = Content.Load<Texture2D>("mainBackground");
            deloreanTexture = Content.Load<Texture2D>("delorean");

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.MainScreen;

            }
            else if (screen == Screen.MainScreen)
            {
                screen = Screen.MainScreen2;
            }

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
                _spriteBatch.DrawString(titleFont, "Back to The Future: Animation", new Vector2(190, 515), Color.White);
            }
            else if (screen == Screen.MainScreen)
            {
                _spriteBatch.Draw(mainBackgroundTexture, mainBackgroundRect, Color.White);
                _spriteBatch.Draw(deloreanTexture, deloreanRect, Color.White);
            }
            else if (screen == Screen.MainScreen2)
            {

            }
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}