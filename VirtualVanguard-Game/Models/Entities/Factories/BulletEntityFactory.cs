using System;

namespace VirtualVanguard_Game.Models
{
    public class BulletEntityFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "EnemyBullet")
            {
                return new EnemyBulletEntity(x, y, width, height, imagePath);
            }
            else if (type == "PlayerBullet")
            {
                return new PlayerBulletEntity(x, y, width, height, imagePath);
            }
            else if (type == "BossBullet")
            {
                return new BossBulletEntity(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid bullet type");
            }
        }
    }
}