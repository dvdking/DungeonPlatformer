using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonPlatformer.Managers;
using Microsoft.Xna.Framework;

namespace DungeonPlatformer.GameObjects
{
    public abstract class Creature:GameObject
    {
        private bool canJump = false;

        public float JumpPower = 15.0f;

        public float Speed = 1.0f;

        public Creature(GameManager gameManager):base(gameManager)
        {
            Collision += OnCollisionWithWall;
        }

        public void MoveLeft()
        {
            Velocity.X -= Speed;
        }
        public void MoveRight()
        {
            Velocity.X += Speed;
        }

        public void Jump()
        {
            if(Collisions.Exists(p => p.Y == -1))
            Velocity += new Vector2(0,-JumpPower);
        }

        private void OnCollisionWithWall(GameObject gameObject)
        {
            //if(gameObject is Wall)
            //{
            //    X = XPrevious;
            //    Y = YPrevious;
            //    if(gameObject.Y > this.Y)
            //    {
            //        canJump = true;
            //    }
            //}
        }

    }
}
