using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public class BossBulletEntity : Entity
    {
        public BossBulletEntity(Vector2 position, int width, int height, Texture2D image) : base(position, width, height, image)
        {
        }
    }
}