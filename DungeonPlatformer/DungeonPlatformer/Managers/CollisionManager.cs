using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonPlatformer.GameObjects;

namespace DungeonPlatformer.Managers
{
    static public class CollisionManager
    {
        static public void CheckCollisions(List<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                foreach (var gameObject2 in gameObjects.Where(gameObject2 => gameObject != gameObject2))
                    if (gameObject.Bounds.Intersects(gameObject2.Bounds))
                        gameObject.OnCollision(gameObject2);
            }
        }
    }
}
