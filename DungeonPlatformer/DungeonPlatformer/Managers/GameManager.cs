using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonPlatformer.GameObjects;

namespace DungeonPlatformer.Managers
{
    public class GameManager
    {
        private readonly List<GameObject> gameObjects;

        public GameManager()
        {
            gameObjects = new List<GameObject>();
        }

        public void Update(float dt)
        {
            CollisionManager.CheckCollisions(gameObjects);
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(dt);
            }
        }
        public void Draw(float dt)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(dt);
            }
        }

    }
}
