using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Models
{
    public class Enemy : Characters
    {
        public string Name { get; set; }

        public Enemy(Texture2D texture, Vector2 position, float speed, string name)
            : base(texture, position, speed)
        {
            Name = name;
        }

        public override void Update(GameTime gameTime)
        {
            // Example: Move downward
            Position = new Vector2(Position.X, Position.Y + Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}


