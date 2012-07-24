using System;
using System.Collections.Generic;
using System.Linq;
using DungeonPlatformer.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using DungeonPlatformer.Helpers;

namespace DungeonPlatformer.Helpers
{
    public enum AnimSprites
    {
        HeroStand = 0,
        HeroRun = 1
    }

    public enum StaticTextures
    {
        Brick = 0
    }

    public static class TextureManager
    {
        static private Dictionary<AnimSprites, AnimSprite> _animationSprites = new Dictionary<AnimSprites, AnimSprite>();

        static private Dictionary<StaticTextures, Texture2D> _textures = new Dictionary<StaticTextures, Texture2D>();

        public static SpriteBatch SpriteBatch;
        public static GraphicsDevice GraphicsDevice;
        private static RenderTarget2D Target2D;
        public static Texture2D CurrentScreenBuffer;

        public static void Init(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
            Target2D = new RenderTarget2D(GraphicsDevice, Settings.Resolution.Width, Settings.Resolution.Height);
        }

        static public AnimSprite GetAnimSprite(AnimSprites at)
        {
            return _animationSprites[at].Clone();
        }

        static public void Begin()
        {
            GraphicsDevice.SetRenderTarget(Target2D);
        }
        static public void End()
        {
            GraphicsDevice.SetRenderTarget(null);
         //   CurrentScreenBuffer = new Texture2D(GraphicsDevice, Settings.Resolution.Width, Settings.Resolution.Height);
          //  Color[] p = new Color[76800];
           // Target2D.GetData(p);
            CurrentScreenBuffer = (Texture2D)Target2D;

            //CurrentScreenBuffer.SetData(p);
           

        }

        static public void DrawAnimationSprite(AnimSprite animSprite, Rectangle rectangle, Color color)
        {
            SpriteBatch.Draw(animSprite, rectangle, color);
        }
        static public void DrawAnimationSprite(AnimSprite animSprite, Vector2 v, Color color)
        {
            SpriteBatch.Draw(animSprite, v, color);
        }

        static public void DrawTexture(StaticTextures texture, Rectangle rectangle, Color color)
        {
            SpriteBatch.Draw(_textures[texture], rectangle, color);
        }
        static public void DrawTexture(StaticTextures texture, Vector2 vector, Color color)
        {
            SpriteBatch.Draw(_textures[texture], vector, color);
        }

        static public void LoadTextures(ContentManager content)
        {
            _animationSprites.Add(AnimSprites.HeroRun, new AnimSprite(content.Load<Texture2D>("Hero//someGuyRun"), 3, 32,32));

            _textures.Add(StaticTextures.Brick, content.Load<Texture2D>("Environment//brick"));

        }
    }
}
