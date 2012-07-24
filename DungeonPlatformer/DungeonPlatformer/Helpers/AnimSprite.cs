using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonPlatformer.Helpers
{
    public class AnimSprite
    {
        public int Frame;
        public float TimePerFrame;
        private readonly int _framesCount;

        public Texture2D Texture { get; private set; }

        public Rectangle SourceRect
        {
            get { return new Rectangle(Frame*FrameWidth, 
                                        0,
                                        FrameWidth,
                                        FrameHeight); }
        }

        public readonly int FrameWidth;
        public readonly int FrameHeight;
        private float _elapsed;

        public AnimSprite(Texture2D texture,int framesCount, int frameWidth, int frameHeight)
        {
            FrameHeight = frameHeight;
            FrameWidth = frameWidth;
            _framesCount = framesCount ;
            Texture = texture;
        }


        public void Update(float dt)
        {
            _elapsed += dt;
            if(_elapsed > TimePerFrame)
            {
                Frame++;
                if(Frame > _framesCount - 1)
                    Frame = 0;

                _elapsed -= TimePerFrame;
            }
        }

        public AnimSprite Clone()
        {
            AnimSprite animSprite = new AnimSprite(this.Texture, _framesCount, FrameWidth, FrameHeight);
            animSprite.TimePerFrame = this.TimePerFrame;
            return animSprite;
        }
    }

    public static class AnimExtenstion
    {
        
        public static void Draw(this SpriteBatch s, AnimSprite animSprite, Rectangle rect, Color color)
        {
            s.Draw(animSprite.Texture, rect, animSprite.SourceRect, color);
        }
        public static void Draw(this SpriteBatch s, AnimSprite animSprite, Vector2 vector, Color color)
        {
            s.Draw(animSprite.Texture, vector, animSprite.SourceRect, color);
        }
    }
}
