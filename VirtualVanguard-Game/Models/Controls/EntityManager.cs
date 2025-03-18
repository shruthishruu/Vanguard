using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;

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

        public void RemoveEnemies()
        {
            // Use LINQ to find all entities of type Enemy
            var enemies = Entities.OfType<Enemy>().ToList();

            // Remove each enemy from the Entities list
            foreach (var enemy in enemies)
            {
                Entities.Remove(enemy);
            }
        }

    }
}