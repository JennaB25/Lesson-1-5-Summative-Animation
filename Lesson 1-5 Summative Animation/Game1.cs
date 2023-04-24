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
        Texture2D bubbleTexture;
        Rectangle bubbleRect;
        Rectangle deloreanRect;
        Rectangle deloreanRect2;
        Rectangle deloreanRect3;
        Rectangle deloreanRect4;
        Rectangle deloreanRect5;
        Rectangle deloreanRect6;
        float seconds;
        float startTime;
        bool quote;
        private SpriteFont titleFont;
        private SpriteFont quoteFont;
        enum Screen
        {
            Intro,
            MainScreen,
            MainScreen2,
            MainScreen3,
            MainScreen4,
            MainScreen5,
            MainScreen6,
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
            this.Window.Title = "BTTF Animation";

            quote = false;
            introRect = new Rectangle(-200, 0, 1200, 600);
            mainBackgroundRect = new Rectangle(0, 0, 800, 600);
            deloreanRect = new Rectangle(325, 165, 130, 100);
            deloreanRect2 = new Rectangle(300, 150, 200, 190);
            deloreanRect3 = new Rectangle(250, 100, 300, 290);
            deloreanRect4 = new Rectangle(200, 50, 400, 390);
            deloreanRect5 = new Rectangle(170, 50, 500, 490);
            deloreanRect6 = new Rectangle(120, 30, 600, 590);
            bubbleRect = new Rectangle(450, 50, 350, 70);
            screen = Screen.Intro;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            titleFont = Content.Load<SpriteFont>("title");
            quoteFont = Content.Load<SpriteFont>("quote");
            introTexture = Content.Load<Texture2D>("bttfBackground");
            bubbleTexture = Content.Load<Texture2D>("bubble");
            mainBackgroundTexture = Content.Load<Texture2D>("mainBackground");
            deloreanTexture = Content.Load<Texture2D>("delorean");

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.MainScreen;
                    startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }
            else if (screen == Screen.MainScreen)
            {           
                if (seconds >= 0.5)
                    screen = Screen.MainScreen2;                  
            }
            else if (screen == Screen.MainScreen2)
            {                
                if (seconds >= 1)
                    screen = Screen.MainScreen3;               
            }
            else if (screen == Screen.MainScreen3)
            {                
                if (seconds >= 1.5)
                    screen = Screen.MainScreen4;                 
            }
            else if (screen == Screen.MainScreen4)
            {                
                if (seconds >= 2)
                    screen = Screen.MainScreen5;                   
            }
            else if (screen == Screen.MainScreen5)
            {                
                if (seconds >= 2.5)
                    screen = Screen.MainScreen6;                  
            }
            else if (screen == Screen.MainScreen6)
            {
                quote = true;               
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.End;                   
            }
            else if (screen == Screen.End)
            {
                //
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MidnightBlue);

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);            
            }
            else if (screen == Screen.MainScreen)
            {
                _spriteBatch.Draw(mainBackgroundTexture, mainBackgroundRect, Color.White);
                _spriteBatch.Draw(deloreanTexture, deloreanRect, Color.White);          
            }
            else if (screen == Screen.MainScreen2)
            {
                _spriteBatch.Draw(mainBackgroundTexture, mainBackgroundRect, Color.White);
                _spriteBatch.Draw(deloreanTexture, deloreanRect2, Color.White);
            }
            else if (screen == Screen.MainScreen3)
            {
                _spriteBatch.Draw(mainBackgroundTexture, mainBackgroundRect, Color.White);
                _spriteBatch.Draw(deloreanTexture, deloreanRect3, Color.White);
            }
            else if (screen == Screen.MainScreen4)
            {
                _spriteBatch.Draw(mainBackgroundTexture, mainBackgroundRect, Color.White);
                _spriteBatch.Draw(deloreanTexture, deloreanRect4, Color.White);
            }
            else if (screen == Screen.MainScreen5)
            {
                _spriteBatch.Draw(mainBackgroundTexture, mainBackgroundRect, Color.White);
                _spriteBatch.Draw(deloreanTexture, deloreanRect5, Color.White);
            }            
            else if (screen == Screen.MainScreen6)
            {
                _spriteBatch.Draw(mainBackgroundTexture, mainBackgroundRect, Color.White);
                _spriteBatch.Draw(deloreanTexture, deloreanRect6, Color.White);
                if (quote)
                {
                    _spriteBatch.Draw(bubbleTexture, bubbleRect, Color.White);
                    _spriteBatch.DrawString(quoteFont, "Where were going we don't need roads...", new Vector2(480, 68), Color.Black);                 
                }
            }
            else if (screen == Screen.End)
            {
                _spriteBatch.DrawString(titleFont, "Goodbye!", new Vector2(190, 515), Color.White);
            }
            
                

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}