using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Threading.Tasks.Dataflow;
using Microsoft.Xna.Framework.Input;

namespace VirtualVanguard_Game.Models
{
    public class AttackControl
    {
        private EntityManager entityManager;
        public AttackControl(BulletFactory bulletFactory, EntityManager entityManager)
        {
            this.entityManager = entityManager;
        }
        public void Update(GameTime gameTime)
        {
            List<Entity> entities = new List<Entity>(entityManager.GetAllEntities());
            foreach (var character in entities)
            {
                if (character is Player player)
                {
                    // Check if button is pressed
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        HandleAttack(player);
                    }
                }
                else if (character is Enemy enemy)
                {
                    if (enemy.AttackTimer == TimeSpan.Zero)
                    {
                        enemy.AttackTimer = gameTime.TotalGameTime;
                    }

                    if (gameTime.TotalGameTime - enemy.AttackTimer >= TimeSpan.FromSeconds(1))
                    {
                        Console.WriteLine("Enemy attacks!");
                        HandleAttack(enemy);
                        enemy.AttackTimer = gameTime.TotalGameTime;
                    }
                }
            }
        }
        private void HandleAttack(Character attacker)
        {
            List<Bullet> bullets = attacker.AttackPattern.Execute(attacker.Position);
            foreach (Bullet bullet in bullets)
            {
                // spawn bullet
                entityManager.AddEntity(bullet);
            }
        }
    }
}
