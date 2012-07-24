using Microsoft.Xna.Framework;

namespace DungeonPlatformer.Helpers
{
    public class Camera2D
    {
        public Vector2 Position { get;protected set; }
     //   protected Vector2 goalPosition;
     //   protected Vector2 direction;

        protected bool moving = false;

        protected float rotation = 0.0f;
        protected float zoom = 1.0f;

        protected int ViewportWidth, ViewportHeight;

        public Camera2D(Vector2 position, int ViewportWidth, int ViewportHeight)
        {
            this.Position = position;
            this.ViewportWidth = ViewportWidth;
            this.ViewportHeight = ViewportHeight;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void MoveTo(Vector2 position)
        {
            this.Position = position;
        }

        public void Zoom(float amount)
        {
            zoom += amount;
            if (zoom < 0)
            {
                zoom = 0;
            }
        }

        public Matrix GetProjection()
        {

            return Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                                         Matrix.CreateRotationZ(rotation) *
                                         Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(ViewportWidth * 0.5f, ViewportHeight * 0.5f, 0));
        }
    }

}