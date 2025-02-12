using System.Collections.Generic;

namespace Models
{
    public class EnemyBulletEntity : Entity
    {
        public EnemyBulletEntity(int x, int y, int width, int height, string imagePath) : base(x, y, width, height, imagePath)
        {
        }
    }
}