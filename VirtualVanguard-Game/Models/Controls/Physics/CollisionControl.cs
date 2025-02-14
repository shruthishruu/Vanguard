using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace VirtualVanguard_Game.Models
{
    public class CollisionControl : Control
    {
        public override void Update() {}
        public void Update(List<Entity> entities)
        {
            // Implement collision detection logic here
            for (int i = 0; i < entities.Count; i++)
            {
                for (int j = i + 1; j < entities.Count; j++)
                {
                    if (IsCollidingWith(entities[i], entities[j]))
                    {
                        HandleCollision(entities[i], entities[j]);
                    }
                }
            }
        }
        private void HandleCollision(Entity entity1, Entity entity2)
        {
            // Implement collision handling logic here
            Console.WriteLine($"Collision detected between {entity1} and {entity2}");
        }
        private bool IsCollidingWith(Entity Player, Entity p_gameObject)
        {
            var playerRect = new Rectangle((int)Player.Position.X, (int)Player.Position.Y, Player.Width, Player.Height);
            var gameObjectRect = new Rectangle((int)p_gameObject.Position.X, (int)p_gameObject.Position.Y, p_gameObject.Width, p_gameObject.Height);
            return playerRect.Intersects(gameObjectRect);
        }
    }
}
