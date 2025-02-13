using System;

namespace Models
{
    public class BulletEntityFactory : EntityFactory
    {
        public override void CreateEntity(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "EnemyBullet")
            {
                new EnemyBulletEntity(x, y, width, height, imagePath);
            }
            else if (type == "PlayerBullet")
            {
                new PlayerBulletEntity(x, y, width, height, imagePath);
            }
            else if (type == "BossBullet")
            {
                new BossBulletEntity(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid bullet type");
            }
        }
    }
}