using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using VirtualVanguard_Game.Models;

namespace VirtualVanguard_Game.Models
{
    public class BulletFactory : EntityFactory
    {
        private Dictionary<string, Texture2D> bulletTextures;

        public BulletFactory(ContentManager content, EntityManager entityManager) : base(content, entityManager)
        {
            // Load bullet textures once and store them
            bulletTextures = new Dictionary<string, Texture2D>
            {
                { "EnemyBullet", content.Load<Texture2D>("EnemyBullet") },
                { "PlayerBullet", content.Load<Texture2D>("PlayerBullet") },
                { "BossBullet", content.Load<Texture2D>("BossBullet") }
            };
        }

        public override void CreateEntity(string type, Vector2 position, int width, int height, int orientation)
        {
            if (!bulletTextures.ContainsKey(type))
                throw new ArgumentException("Invalid bullet type");

            Texture2D image = bulletTextures[type];

            Vector2 defaultVelocity = new Vector2(0, 5); // Bullets move down by default
            AddEntity(new Bullet(position, width, height, orientation, image, defaultVelocity));
        }
    }
}