using System;
using System.Collections.Generic;
using System.Linq;
using DungeonPlatformer.GameObjects;
using DungeonPlatformer.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using DungeonPlatformer.Helpers;
namespace DungeonPlatformer
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        private GameManager gameManager;
        private Camera2D camera;
        Hero hero;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
                           {
                               //PreferredBackBufferWidth = 320, PreferredBackBufferHeight = 240, IsFullScreen = false,
                           };


            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Settings.Resolution.Width;
            graphics.PreferredBackBufferHeight = Settings.Resolution.Height;

            graphics.GraphicsDevice.Viewport = new Viewport(0, 0, Settings.Resolution.Width, Settings.Resolution.Height);
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            TextureManager.Init(new SpriteBatch(GraphicsDevice), GraphicsDevice);
            
            TextureManager.LoadTextures(Content);


            gameManager = new GameManager();

            hero = new Hero(gameManager);
            camera = new Camera2D(hero.Position, Settings.Resolution.Width, Settings.Resolution.Height);
         //   camera.Zoom(1.0f);
            BrickWall wall = new BrickWall(gameManager);
            BrickWall wall2 = new BrickWall(gameManager);
            wall.Position = new Vector2(2, 90);
            wall2.Position = new Vector2(40, 70);
            BrickWall wall3 = new BrickWall(gameManager);
            wall3.Position = new Vector2(60, 10);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            float dt = gameTime.ElapsedGameTime.Milliseconds * Settings.GameSpeed;

            GamepadHelper.Update(dt);


                gameManager.Update(dt);
                camera.MoveTo(hero.Position);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            float dt = gameTime.ElapsedGameTime.Milliseconds * Settings.GameSpeed;


            TextureManager.Begin();
            this.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            TextureManager.SpriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp,null, null,null,camera.GetProjection());
            gameManager.Draw(dt);
            TextureManager.SpriteBatch.End();
            TextureManager.End();

            TextureManager.SpriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null, null);
            TextureManager.SpriteBatch.Draw(TextureManager.CurrentScreenBuffer, new Rectangle(0,0,(int)(Settings.Resolution.Width), Settings.Resolution.Height), Color.White);
            TextureManager.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
