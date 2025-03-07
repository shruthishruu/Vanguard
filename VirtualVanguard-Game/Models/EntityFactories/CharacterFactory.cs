using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using VirtualVanguard_Game.Models;

namespace VirtualVanguard_Game.Models
{
    public class CharacterFactory : EntityFactory
    {
        private AttackPatternFactory attackFactory;
        public CharacterFactory(ContentManager content, EntityManager entityManager) 
            : base(content, entityManager)
        {
            attackFactory = new AttackPatternFactory();
        }

        public override void CreateEntity(string type, Vector2 position, int width, int height, Vector2 orientation)
        {
            Texture2D image;
            if (type == "Player")
            {
                image = Content.Load<Texture2D>("Player");
                AddEntity(new Player(position, width, height, orientation, image));
            }
            else if (type == "Enemy")
            {
                image = Content.Load<Texture2D>("Enemy");
                var spreadAttackPattern = attackFactory.CreateSpreadAttack(3.0f, Content.Load<Texture2D>("EnemyBullet"));
                AddEntity(new Enemy(position, width, height, orientation, image, spreadAttackPattern));
            }
            else if (type == "Boss1")
            {
                image = Content.Load<Texture2D>("Boss");
                var spreadAttackPattern = attackFactory.CreateSpiralAttack(3.0f, Content.Load<Texture2D>("EnemyBullet"));
                AddEntity(new Enemy(position, width, height, orientation, image, spreadAttackPattern));
            }
            else if (type == "Boss2")
            {
                image = Content.Load<Texture2D>("Boss2");
                var spreadAttackPattern = attackFactory.CreateSpiralAttack(1.5f, Content.Load<Texture2D>("EnemyBullet"));
                AddEntity(new Enemy(position, width, height, orientation, image, spreadAttackPattern));
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }
    }
}
