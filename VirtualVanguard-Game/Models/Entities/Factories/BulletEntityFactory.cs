using System;

namespace VirtualVanguard_Game.Models
{
    public class BulletEntityFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, Vector2 position, int width, int height, Texture2D image)
        {
            if (type == "EnemyBullet")
            {
                return new EnemyBulletEntity(x, y, width, height, image);
            }
            else if (type == "PlayerBullet")
            {
                return new PlayerBulletEntity(x, y, width, height, image);
            }
            else if (type == "BossBullet")
            {
                return new BossBulletEntity(x, y, width, height, image);
            }
            else
            {
                throw new ArgumentException("Invalid bullet type");
            }
        }
    }
}