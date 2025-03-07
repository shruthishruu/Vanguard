using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace VirtualVanguard_Game.Models
{
    public abstract class EntityFactory
    {
        protected List<Entity> Entities; // Active entities
        protected ContentManager Content;
        protected EntityManager entityManager;
        public EntityFactory(ContentManager content, EntityManager entityManager)
        {
            Content = content;
            this.entityManager = entityManager;
        }
        public abstract void CreateEntity(string type, Vector2 position, int width, int height, Vector2 orientation);
        public void AddEntity(Entity entity)
        {
            entityManager.AddEntity(entity);
        }
    }
}
