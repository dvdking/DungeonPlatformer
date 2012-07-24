using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DungeonPlatformer.Managers;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace DungeonPlatformer.GameObjects
{
    public delegate void CollisionEventHandler(GameObject gameObject);

    public abstract class GameObject
    {
        protected GameManager gameManager;
        public event CollisionEventHandler Collision;


        protected List<Vector2> Collisions; 


        private float _x, _y;
        private float _xPrevious,_yPrevious;

        public bool IsOnTheGround { get;protected set; }

        public Vector2 Velocity;

        public float XPrevious
        {
            get { return _xPrevious; }
            private set { _xPrevious = value; }
        }

        public float YPrevious
        {
            get { return _yPrevious; }
            private set { _yPrevious = value; }
        }

        public Vector2 PreviousPosition
        {
            get
            {
                return new Vector2(XPrevious);
            }
            set
            {
                XPrevious = value.X;
                YPrevious = value.Y;
            }
        }

        public float X
        {
            get { return _x; }
            set
            {
                XPrevious = X;
                _x = value;
            }

        }


        public float Y
        {
            get { return _y; }
            set
            {
                YPrevious = Y;
                _y = value;
            }
        }

        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        private int _width, _height;
        protected float Friction;

        public int Width
        {
            get { return _width; }
            set { _width = value; }

        }


        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public Size Size
        {
            get { return new Size(_width, _height); }
            set
            {
                _width = value.Width;
                _height = value.Height;
            }
        }

        public Microsoft.Xna.Framework.Rectangle Bounds
        {
            get { return new Microsoft.Xna.Framework.Rectangle((int) _x, (int) _y, _width, _height); }
            set
            {
                _x = value.X;
                _y = value.Y;
                _width = value.Width;
                _height = value.Height;
            }
        }

        public GameObject(GameManager gameManager)
        {
            Collisions = new List<Vector2>();
            this.gameManager = gameManager;
            gameManager.Add(this);
        }


        public virtual void Update(float dt)
        {
            Velocity += Settings.Gravity*dt;
            CheckCollisions(ref Velocity);
            Position += Velocity;
            if (Collisions.Any())
            {
                if (Velocity.X > 0)
                {
                    Velocity.X -= Friction;
                    if (Velocity.X < 0)
                        Velocity.X = 0;
                }
                else if (Velocity.X < 0)
                {
                    Velocity.X += Friction;
                    if (Velocity.X > 0)
                        Velocity.X = 0;
                }
                if (Velocity.Y > 0)
                {
                    Velocity.Y -= Friction;
                    if (Velocity.Y < 0)
                        Velocity.Y = 0;
                }
                else if (Velocity.Y < 0)
                {
                    Velocity.Y += Friction;
                    if (Velocity.Y > 0)
                        Velocity.Y = 0;
                }
            }
            IsOnTheGround = CheckGround();
        }

        public abstract void Draw(float dt);

        protected void CheckCollisions(ref Vector2 offset)
        {
            List<GameObject> collisionsX = gameManager.GetCollisions(new Rectangle((int)Math.Round(X + offset.X),
                                                                                  (int)Math.Round(Y),
                                                                                  Width,
                                                                                  Height));
            List<GameObject> collisionsY = gameManager.GetCollisions(new Rectangle((int)Math.Round(X),
                                                                                 (int)Math.Round(Y + offset.Y),
                                                                                 Width,
                                                                                 Height));

            List<GameObject> commonCollision = new List<GameObject>();
            Collisions.Clear();

                foreach (var item in collisionsX)
                {
                    if (item != this)
                    {
                            offset.X = 0;
                            if (Position.X < item.X)
                            {
                                Collisions.Add(new Vector2(-1, 0));
                                X = item.X -Width;
                            }
                            else if(Position.X > item.X)
                            {
                                Collisions.Add(new Vector2(1, 0));
                                X = item.X + item.Width;
                            }
                        commonCollision.Add(item);
                    }
                }
                foreach (var item in collisionsY)
                {
                    if (item != this)
                    {
                            offset.Y = 0;
                            if (Position.Y < item.Y)
                            {
                                Collisions.Add(new Vector2(0, -1));
                                Y = item.Y - Height;

                            }
                            else if(Position.Y > item.Y)
                            {
                                Collisions.Add(new Vector2(0, 1));
                                Y = item.Y + item.Height;
                            }
                        if (!commonCollision.Contains(item))
                            commonCollision.Add(item);
                    }
                }

                if (offset.X != 0 && offset.Y != 0)
                {
                    List<GameObject> collisionsAll = gameManager.GetCollisions(new Rectangle((int)Math.Round(X + offset.X),
                                                                                             (int)Math.Round(Y + offset.Y),
                                                                                             Width,
                                                                                             Height));

                    foreach (var item in collisionsAll)
                    {
                        if (item != this)
                        {

                            offset.X = 0;
                            offset.Y = 0;

                            if (!commonCollision.Contains(item))
                                commonCollision.Add(item);
                            break;
                        }
                    }
                }
            if (Collision != null)
                for (int index = 0; index < commonCollision.Count; index++)
                {
                    var item = commonCollision[index];
                    OnCollision(item);
                }
        }

        private bool CheckGround()
        {
            List<GameObject> collisions = gameManager.GetCollisions(new Rectangle((int)Math.Round(X),
                                                                     (int)Math.Round(Y + 1),
                                                                     Width,
                                                                     Height));
            return collisions.OfType<Wall>().Any();
        }

        public void OnCollision(GameObject gameObject)
        {
            if(Collision != null)
            {
                Collision(gameObject);
            }
        }
    }
}
