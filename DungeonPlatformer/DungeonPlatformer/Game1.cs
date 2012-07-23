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
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 320;
            graphics.PreferredBackBufferHeight = 240;
            graphics.IsFullScreen = false;

            
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }
        protected override void LoadContent()
        {
            TextureManager.SpriteBatch = new SpriteBatch(GraphicsDevice);
            
            TextureManager.LoadTextures(Content);

            gameManager = new GameManager();

            Hero hero = new Hero(gameManager);
            Wall wall = new BrickWall(gameManager);
            wall.Position = new Vector2(2, 90);

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


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            float dt = gameTime.ElapsedGameTime.Milliseconds * Settings.GameSpeed;
            this.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            TextureManager.SpriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp,null, null);
            gameManager.Draw(dt);
            TextureManager.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
