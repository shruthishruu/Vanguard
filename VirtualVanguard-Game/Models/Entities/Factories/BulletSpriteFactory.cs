using System;

namespace Models
{
    public class BulletSpriteFactory : SpriteFactory
    {
        public override void CreateSprite(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "EnemyBullet")
            {
                new EnemyBulletSprite(x, y, width, height, imagePath);
            }
            else if (type == "PlayerBullet")
            {
                new PlayerBulletSprite(x, y, width, height, imagePath);
            }
            else if (type == "BossBullet")
            {
                new BossBulletSprite(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid bullet type");
            }
        }
    }
}