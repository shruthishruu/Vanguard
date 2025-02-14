using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class CharacterFactory : EntityFactory
    {
        public CharacterFactory(ContentManager content, EntityManager entityManager) : base(content, entityManager)
        {
        }
        public override void CreateEntity(string type, Vector2 position, int width, int height, int orientation)
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
                AddEntity(new Enemy(position, width, height, orientation, image, TimeSpan.FromSeconds(1)));
            }
            else if (type == "Boss")
            {
                image = Content.Load<Texture2D>("Boss");
                AddEntity(new Boss(position, width, height, orientation, image, TimeSpan.FromSeconds(1)));
            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
        }
    }
}