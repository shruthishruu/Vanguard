using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace VirtualVanguard_Game.Models
{
    public class BulletFactory : EntityFactory
    {
        public BulletFactory(ContentManager content, EntityManager entityManager) : base(content, entityManager)
        {
        }
        public override void CreateEntity(string type, Vector2 position, int width, int height, int orientation)
        {
            Texture2D image;
            if (type == "EnemyBullet")
            {
                image = Content.Load<Texture2D>("EnemyBullet");
            }
            else if (type == "PlayerBullet")
            {
                image = Content.Load<Texture2D>("PlayerBullet");
            }
            else if (type == "BossBullet")
            {
                image = Content.Load<Texture2D>("BossBullet");
            }
            else
            {
                throw new ArgumentException("Invalid bullet type");
            }
            AddEntity(new Bullet(position, width, height, orientation, image));
        }
    }
}