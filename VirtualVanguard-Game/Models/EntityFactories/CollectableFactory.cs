using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Reflection;
using System.Diagnostics.Tracing;


namespace VirtualVanguard_Game.Models
{
    public class CollectableFactory : EntityFactory
    {
        public CollectableFactory(ContentManager content, EntityManager entityManager) : base(content, entityManager)
        {
            Content = content;
        }
        public override void CreateEntity(string type, Vector2 position, int width, int height, int orientation)
        {
            Texture2D image;
            if (type == "Powerup")
            {
                image = Content.Load<Texture2D>("Powerup");
            }
            else if (type == "Bomb")
            {
                image = Content.Load<Texture2D>("Bomb");
            }
            else
            {
                throw new ArgumentException("Invalid collectable entity type");
            }
            AddEntity(new Collectable(position, width, height, orientation, image));
        }
    }
}
