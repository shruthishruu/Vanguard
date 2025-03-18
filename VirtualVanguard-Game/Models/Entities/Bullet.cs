using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class Bullet : Entity
    {
        public Vector2 Velocity { get; private set; }  // Bullet movement speed and direction
        public float Lifetime { get; private set; }   // Time in seconds before despawning
        public float timeElapsed = 0f;              // Time since the bullet was created

        public Bullet(Vector2 position, int width, int height, Vector2 orientation, Texture2D image, Vector2 velocity, float lifetime = 5f) 
            : base(position, width, height, orientation, image)
        {
            Velocity = velocity;
            Lifetime = lifetime;
        }

        // Flag bullets for removal
        public bool MarkForRemoval { get; private set; } = false;
    }
}
