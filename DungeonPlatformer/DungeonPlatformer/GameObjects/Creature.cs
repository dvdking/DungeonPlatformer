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

        public float JumpPower = 7.0f;

        public float Speed = 0.1f;
        public float MaxSpeed = 2.0f;

        public Creature(GameManager gameManager):base(gameManager)
        {
            Collision += OnCollisionWithWall;
        }

        public void MoveLeft(float dt)
        {
            if(Velocity.X > -MaxSpeed)
            Velocity.X -= Speed * dt;
        }
        public void MoveRight(float dt)
        {
            if(Velocity.X < MaxSpeed)
            Velocity.X += Speed * dt;
        }

        public void Jump( float dt)
        {
           // if(Collisions.Exists(p => p.Y == -1))
            if(IsOnTheGround)
            Velocity += new Vector2(0,-JumpPower * dt);
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
