using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DungeonPlatformer.GameObjects
{
    public abstract class GameObject
    {
        private float _x, _y;

        public float X
        {
            get { return _x; }
            set { _x = value; }

        }


        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Vector2 Position
        {
            get {return new Vector2(_x, _y);}
            set 
            { 
                _x = value.X;
                _y = value.Y;
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
            get {return new Size(_width, _height);}
            set
            {
                _width = value.Width;
                _height = value.Height;
            }
        }

        public Microsoft.Xna.Framework.Rectangle Bounds
        {
            get { return new Microsoft.Xna.Framework.Rectangle((int)_x, (int)_y, _width, _height); }
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
    }
}
