using System.Collections.Generic;

namespace Models
{
    public class PlayerBulletEntity : Entity
    {
        public PlayerBulletEntity(int x, int y, int width, int height, string imagePath) : base(x, y, width, height, imagePath)
        {
        }
    }
}