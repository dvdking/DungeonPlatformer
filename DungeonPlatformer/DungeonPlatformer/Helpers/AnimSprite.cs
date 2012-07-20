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
        private int _framesCount;

        public Texture2D Texture { get; private set; }

        public Rectangle SourceRect
        {
            get { return new Rectangle(Frame*_frameWidth, 
                                        Frame*_frameHeight,
                                        _frameWidth,
                                        _frameHeight); }
        }

        private int _frameWidth, _frameHeight;
        private float _elapsed;

        public AnimSprite(Texture2D texture,int framesCount, int frameWidth, int frameHeight)
        {
            Texture = texture;
            _frameHeight = frameHeight;
            _frameWidth = frameWidth;
            _framesCount = framesCount;
        }


        public void Update(float dt)
        {
            _elapsed += dt;
            if(_elapsed > TimePerFrame)
            {
                Frame++;
                if(Frame > _framesCount)
                    Frame = 0;

                _elapsed -= TimePerFrame;
            }
        }
    }

    public static class AnimExtenstion
    {
        
        public static void Draw(this SpriteBatch s, AnimSprite animSprite, Rectangle rect, Color color)
        {
            s.Draw(animSprite.Texture, rect, animSprite.SourceRect, color);
        }
    }
}
