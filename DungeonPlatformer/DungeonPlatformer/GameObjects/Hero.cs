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


        public Hero(GameManager gameManager):base(gameManager)
        {
            animSprite = TextureManager.GetAnimSprite(AnimSprites.HeroRun);
            animSprite.TimePerFrame = 50;
            Width = 32;
            Height = 32;
            Friction = 1.5f;

        }

        public override void Update(float dt)
        {
            if(GamepadHelper.Press(Buttons.DPadRight))
            {
                MoveRight();
            }
            if (GamepadHelper.Press(Buttons.DPadLeft))
            {
                MoveLeft();
            }

            if (GamepadHelper.WasPressed(Buttons.A))
            {
                Jump();
            }
            animSprite.Update(dt);
            base.Update(dt);
        }



        public override void Draw(float dt)
        {
            TextureManager.SpriteBatch.Draw(animSprite, Bounds, Color.Wheat);
        }
    }
}
