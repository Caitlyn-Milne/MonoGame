using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Pixel_Bot_Mono {
    public class Game1 : Game {

        public static KeyboardState KeyboardState;

        public static float vw, vh;

        public static GameTime GlobalGameTime;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        SpriteFont defaultFont;




        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;



        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            vw = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 100f;
            vh = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 100f;

            vw *= 0.9f;
            vh *= 0.9f;

            _graphics.PreferredBackBufferWidth = (int)(vw * 100f);//GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = (int)(vh * 100f);// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;


          /*  IsFixedTimeStep = false;
            _graphics.SynchronizeWithVerticalRetrace = false;*/

            // _graphics.IsFullScreen = true;

            _graphics.ApplyChanges();

            new FollowCamera(new PlayerController(), new Vector2(-50,0),3);

            

            new Background();

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            AssetLoader.contentManager = this.Content;

            defaultFont = this.Content.Load<SpriteFont>("Fonts/default");

            foreach (ActorObject actorObject in ActorObject.ActorObjects) {
                actorObject.Load();
            }

        }

        protected override void Update(GameTime gameTime) {

            GlobalGameTime = gameTime;
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState = Keyboard.GetState();
            // TODO: Add your update logic here
            if (Camera.currentCamera != null) {
                Camera.currentCamera.Update();
            }
            foreach (ActorObject actorObject in ActorObject.ActorObjects) {
                actorObject.Update(gameTime);
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {

            GraphicsDevice.Clear(Color.MediumPurple);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();


            foreach (ActorObject actorObject in ActorObject.ActorObjects) {
                actorObject.Draw(_spriteBatch);
            }
            _spriteBatch.DrawString(defaultFont, "fps: " + Math.Floor(1/gameTime.ElapsedGameTime.TotalSeconds), Vector2.Zero, Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public static Rectangle ConvertToScreenSpace(Transform _transform) {
            Rectangle returnRect = (Rectangle)_transform;

            returnRect.Width = (int)Math.Ceiling(returnRect.Width * vw * (100 / Camera.currentCamera.Size.X));
            returnRect.Height = (int)Math.Ceiling(returnRect.Height * vh * (100/Camera.currentCamera.Size.Y));

            returnRect.X = (int)Math.Ceiling((returnRect.X - Camera.currentCamera.Location.X)* vw);
            returnRect.Y = (int)Math.Ceiling((returnRect.Y - Camera.currentCamera.Location.Y)* vh);

            returnRect.Y += (int)Math.Ceiling((vh * 100) - returnRect.Height);
            return returnRect;
        }
    }
}
