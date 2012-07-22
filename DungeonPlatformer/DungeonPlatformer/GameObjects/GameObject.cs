using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DungeonPlatformer.GameObjects
{
    public delegate void CollisionEventHandler(GameObject gameObject);

    public abstract class GameObject
    {
        public event CollisionEventHandler Collision;

        private float _x, _y;
        private float _xPrevious,_yPrevious;

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

        public abstract void Update(float dt);
        public abstract void Draw(float dt);
        public void OnCollision(GameObject gameObject)
        {
            if(Collision != null)
            {
                Collision(gameObject);
            }
        }
    }
}
