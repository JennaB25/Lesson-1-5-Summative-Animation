using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson_1_5_Summative_Animation
{
    public class Game1 : Game
    {
        Texture2D introTexture;
        Rectangle introRect;
        Texture2D mainBackgroundTexture;
        Rectangle mainBackgroundRect;
        Texture2D endScreenTexture;
        Rectangle endScreenRect;
        Texture2D deloreanTexture;
        Texture2D bubbleTexture;
        Rectangle bubbleRect;
        Rectangle deloreanRect;
        Rectangle deloreanRect2;
        Rectangle deloreanRect3;
        Rectangle deloreanRect4;
        Rectangle deloreanRect5;
        Rectangle deloreanRect6;
        SoundEffect quoteSound;
        SoundEffectInstance quoteSEI;
        SoundEffect music;
        SoundEffectInstance musicSEI;
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
            bubbleRect = new Rectangle(445, 50, 365, 70);
            endScreenRect = new Rectangle(0, 0, 800, 600);
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
            endScreenTexture = Content.Load<Texture2D>("endScreenImage");
            deloreanTexture = Content.Load<Texture2D>("delorean");
            quoteSound = Content.Load<SoundEffect>("quoteSound");
            music = Content.Load<SoundEffect>("music");
            musicSEI = music.CreateInstance();       
            quoteSEI = quoteSound.CreateInstance();
            quoteSEI.Volume = 0.5f;
            quoteSEI.IsLooped = false;

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            musicSEI.Play();
            mouseState = Mouse.GetState();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;

            if (screen == Screen.Intro)
            {              
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    screen = Screen.MainScreen;
                    startTime = (float)gameTime.TotalGameTime.TotalSeconds;

                if (musicSEI.State == SoundState.Stopped)
                    screen = Screen.MainScreen;
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
                musicSEI.Pause();
                quoteSEI.Play();
                quote = true;
                if (seconds >= 6.5)
                {
                    musicSEI.Play();
                    screen = Screen.End;
                }
                                      
            }
            else if (screen == Screen.End)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    Exit();
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
                _spriteBatch.DrawString(titleFont, "Press E To Continue", new Vector2(500, 450), Color.LightSkyBlue);   
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
                    _spriteBatch.DrawString(quoteFont, "Roads, where were going we don't need roads...", new Vector2(470, 68), Color.Black);                 
                }
            }
            else if (screen == Screen.End)
            {
                _spriteBatch.Draw(endScreenTexture, endScreenRect, Color.White);
                _spriteBatch.DrawString(titleFont, "Created By: Jenna B", new Vector2(290, 500), Color.Black);
                _spriteBatch.DrawString(quoteFont,"Press E to Exit", new Vector2(690, 580), Color.Black);
            }         
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}