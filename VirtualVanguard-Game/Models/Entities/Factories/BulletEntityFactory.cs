using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class BulletEntityFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, Vector2 position, int width, int height, Texture2D image)
        {
            if (type == "EnemyBullet")
            {
                return new EnemyBulletEntity(position, width, height, image);
            }
            else if (type == "PlayerBullet")
            {
                return new PlayerBulletEntity(position, width, height, image);
            }
            else if (type == "BossBullet")
            {
                return new BossBulletEntity(position, width, height, image);
            }
            else
            {
                throw new ArgumentException("Invalid bullet type");
            }
        }
    }
}