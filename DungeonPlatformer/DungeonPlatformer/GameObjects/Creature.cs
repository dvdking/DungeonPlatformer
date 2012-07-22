using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonPlatformer.GameObjects
{
    public abstract class Creature:GameObject
    {
        public Creature():base()
        {
            Collision += OnCollisionWithWall;
        }

        private void OnCollisionWithWall(GameObject gameObject)
        {
            if(gameObject is Wall)
            {

            }
        }

    }
}
