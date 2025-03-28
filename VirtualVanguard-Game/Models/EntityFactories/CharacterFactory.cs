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
        public CharacterFactory(ContentManager content, EntityManager entityManager) 
            : base(content, entityManager)
        {
        }

        public override void CreateEntity(string type, Vector2 position, int width, int height, Vector2 orientation)
        {
            Texture2D image;
            var attackPattern = new AttackPattern();
            if (type == "Player")
            {
                image = Content.Load<Texture2D>("Player");
                Attack attack1 = new StraightAttack(10, orientation, Content.Load<Texture2D>("PlayerBullet"));
                attackPattern.AddAttack(attack1);
                AddEntity(new Player(position, width, height, orientation, image, attackPattern));
            }
            else if (type == "Enemy")
            {
                image = Content.Load<Texture2D>("Enemy");
                Attack attack1 = new SpreadAttack(10, orientation, Content.Load<Texture2D>("EnemyBullet"), 90, 5);
                attackPattern.AddAttack(attack1);
                AddEntity(new Enemy(position, width, height, orientation, image, attackPattern));
            }
            else if (type == "Boss1")
            {
                image = Content.Load<Texture2D>("Boss");
                Attack attack1 = new StraightAttack(10, orientation, Content.Load<Texture2D>("EnemyBullet"));
                attackPattern.AddAttack(attack1);
                AddEntity(new Enemy(position, width, height, orientation, image, attackPattern));
            }
            else if (type == "Boss2")
            {
                image = Content.Load<Texture2D>("Boss2");
                Attack attack1 = new StraightAttack(10, orientation, Content.Load<Texture2D>("EnemyBullet"));
                attackPattern.AddAttack(attack1);
                AddEntity(new Enemy(position, width, height, orientation, image, attackPattern));
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }
    }
}
