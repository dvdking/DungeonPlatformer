using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonPlatformer.Helpers;
using DungeonPlatformer.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonPlatformer.GameObjects
{
    public class Hero:Creature
    {
        private AnimSprite animSprite;

        //public Rectangle Bounds { get {return new Rectangle((int)(X + 16), (int)Y, Width - 16, Height - 16);}}

        public Hero(GameManager gameManager):base(gameManager)
        {
            animSprite = TextureManager.GetAnimSprite(AnimSprites.HeroRun);
            animSprite.TimePerFrame = 50;
            Width = 32;
            Height = 32;
            Friction = 0.4f;
            Speed = 2.0f;
            JumpPower = 20;

        }

        public override void Update(float dt)
        {
            if(GamepadHelper.Press(Buttons.DPadRight))
            {
                MoveRight(dt);
            }
            if (GamepadHelper.Press(Buttons.DPadLeft))
            {
                MoveLeft(dt);
            }
            if (GamepadHelper.WasPressed(Buttons.A))
            {
                Jump(dt);
            }
            animSprite.Update(dt);
            base.Update(dt);

        }



        public override void Draw(float dt)
        {
            TextureManager.SpriteBatch.Draw(animSprite, Position, Color.Wheat);
        }
    }
}
