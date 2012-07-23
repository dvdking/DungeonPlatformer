using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonPlatformer.GameObjects;
using Microsoft.Xna.Framework;

namespace DungeonPlatformer.Managers
{
    public class GameManager
    {
        private readonly List<GameObject> gameObjects;

        public GameManager()
        {
            gameObjects = new List<GameObject>();
        }
        public void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public List<GameObject> GetCollisions(Rectangle rectangle)
        {
            return gameObjects.Where(go => go.Bounds.Intersects(rectangle)).ToList();
        }

        public void Update(float dt)
        {
           // CollisionManager.CheckCollisions(gameObjects);
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
