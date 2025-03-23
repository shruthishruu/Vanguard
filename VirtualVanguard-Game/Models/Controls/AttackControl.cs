using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Threading.Tasks.Dataflow;

namespace VirtualVanguard_Game.Models
{
    public class AttackControl
    {
        private BulletFactory bulletFactory;
        private EntityManager entityManager;
        public AttackControl(BulletFactory bulletFactory, EntityManager entityManager)
        {
            this.bulletFactory = bulletFactory;
            this.entityManager = entityManager;
        }
        public void Update(GameTime gameTime)
        {
            List<Entity> entities = new List<Entity>(entityManager.GetAllEntities());
            foreach (var character in entities)
            {
                if (character is Player player)
                {
                    // Handle player-specific attack logic
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
        private void HandleAttack(Entity attacker)
        {
            if (attacker is Enemy enemy)
            {
                List<Bullet> bullets = enemy.AttackPattern.Execute(enemy.Position);
                foreach (Bullet bullet in bullets)
                {
                    // spawn bullet
                    entityManager.AddEntity(bullet);
                }
            }
        }
    }
}
