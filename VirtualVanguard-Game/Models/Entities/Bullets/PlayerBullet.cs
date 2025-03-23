using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class PlayerBullet : Bullet
    {
        public PlayerBullet(Vector2 position, int width, int height, Vector2 orientation, Texture2D image, Vector2 velocity, float lifetime = 5f) 
            : base(position, width, height, orientation, image, velocity, lifetime)
        {
        }
    }
}
