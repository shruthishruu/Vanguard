using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Models
{
    public class Characters
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public float Speed { get; set; }

        public Characters(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
        }

        public virtual void Update(GameTime gameTime)
        {
            // Default logic for all characters
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }
    }
}

