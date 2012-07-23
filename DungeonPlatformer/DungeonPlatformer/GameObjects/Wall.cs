using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonPlatformer.Managers;

namespace DungeonPlatformer.GameObjects
{
    abstract class Wall:GameObject
    {
        public Wall(GameManager gameManager):base(gameManager)
        {

        }
    }
}
