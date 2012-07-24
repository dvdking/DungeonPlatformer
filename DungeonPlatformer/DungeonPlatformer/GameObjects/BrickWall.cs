using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonPlatformer.Helpers;
using DungeonPlatformer.Managers;
using Microsoft.Xna.Framework;

namespace DungeonPlatformer.GameObjects
{
    class BrickWall:Wall
    {
        public BrickWall(GameManager gameManager):base(gameManager)
        {
            Width = Settings.CellSize;
            Height = Settings.CellSize;
        }

        public override void Update(float dt)
        {
        }

        public override void Draw(float dt)
        {
            TextureManager.DrawTexture(StaticTextures.Brick, Position, Color.White);
        }
    }
}
