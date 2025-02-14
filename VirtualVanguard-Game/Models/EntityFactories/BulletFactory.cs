using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace VirtualVanguard_Game.Models
{
    public class BulletFactory : EntityFactory
    {
        private ContentManager Content;
        public BulletFactory(ContentManager content) : base(content)
        {
            Content = content;
        }
        public override Entity CreateEntity(string type, Vector2 position, int width, int height, int orientation, Texture2D image)
        {
            if (type == "EnemyBullet")
            {
                
            }
            else if (type == "PlayerBullet")
            {
                
            }
            else if (type == "BossBullet")
            {
                
            }
            else
            {
                throw new ArgumentException("Invalid bullet type");
            }
            return new Bullet(position, width, height, orientation, image);
        }
    }
}