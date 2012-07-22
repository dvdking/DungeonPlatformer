using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonPlatformer.Helpers
{
    public enum AnimSprites
    {
        HeroStand = 0,
        HeroRun = 1
    }

    public static class TextureManager
    {
        static private Dictionary<AnimSprites, AnimSprite> _animationSprites = new Dictionary<AnimSprites, AnimSprite>(); 


        static public AnimSprite GetAnimSprite(AnimSprites at)
        {
            return _animationSprites[at].Clone();
        }

        static public void LoadTextures(ContentManager content)
        {
            _animationSprites.Add(AnimSprites.HeroRun, new AnimSprite(content.Load<Texture2D>("Hero//someGuyRun"), 3, 32,32));

        }
    }
}
