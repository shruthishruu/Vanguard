using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace VirtualVanguard_Game.Models
{
    public class CollisionControl
    {
        // Main update method to check collisions
        public void Update(IReadOnlyList<Entity> entities)
        {
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

        // Handle different collision cases
        private void HandleCollision(Entity entity1, Entity entity2)
        {
            // Check if EnemyBullet collides with Player
            if (entity1 is EnemyBullet && entity2 is Player)
            {
                ReducePlayerLife(entity2);
            }
            else if (entity2 is EnemyBullet && entity1 is Player)
            {
                ReducePlayerLife(entity1);
            }

            // Check if PlayerBullet collides with Enemy
            else if (entity1 is PlayerBullet && entity2 is Enemy)
            {
                ReduceEnemyLife(entity2);
            }
            else if (entity2 is PlayerBullet && entity1 is Enemy)
            {
                ReduceEnemyLife(entity1);
            }

            // Check if Player collides with Enemy
            else if (entity1 is Player && entity2 is Enemy)
            {
                ReducePlayerLife(entity1);
            }
            else if (entity2 is Player && entity1 is Enemy)
            {
                ReducePlayerLife(entity2);
            }
        }

        // Check collision using Axis-Aligned Bounding Box (AABB)
        private bool IsCollidingWith(Entity entity1, Entity entity2)
        {
            var rect1 = new Rectangle((int)entity1.Position.X, (int)entity1.Position.Y, entity1.Width, entity1.Height);
            var rect2 = new Rectangle((int)entity2.Position.X, (int)entity2.Position.Y, entity2.Width, entity2.Height);
            return rect1.Intersects(rect2);
        }

        // Reduce life from Player if collision occurs
        private void ReducePlayerLife(Entity playerEntity)
        {
            if (playerEntity is Character player)
            {
                player.ReduceLife(1);
                Console.WriteLine($"Player hit! Remaining life: {player.GetLife()}");
                if (player.GetLife() <= 0)
                {
                    Console.WriteLine("Player has died!");
                }
            }
        }

        // Reduce life from Enemy if collision occurs
        private void ReduceEnemyLife(Entity enemyEntity)
        {
            if (enemyEntity is Character enemy)
            {
                enemy.ReduceLife(1);
                Console.WriteLine($"Enemy hit! Remaining life: {enemy.GetLife()}");
                if (enemy.GetLife() <= 0)
                {
                    Console.WriteLine("Enemy has died!");
                }
            }
        }
    }
}
