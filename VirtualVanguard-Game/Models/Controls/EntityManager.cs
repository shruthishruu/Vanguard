using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace VirtualVanguard_Game.Models
{
    public class EntityManager
    {
        private List<Entity> Entities = new List<Entity>();

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        public IReadOnlyList<Entity> GetAllEntities()
        {
            return Entities.AsReadOnly();
        }

    }
}