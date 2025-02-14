using System;
using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public class MovementControl : Control
    {
        public override void Update() {}
        public void Update(List<Entity> entities)
        {
            // Implement movement logic here
            foreach (var entity in entities)
            {
                if (entity is PlayerEntity player)
                {
                    // Handle player movement (use keyboard input)
                }
                else if (entity is EnemyEntity enemy)
                {
                    // Handle enemy movement (move randomly)
                }
                // else if (entity is BulletEntity bullet)
                // {
                //     // Handle bullet movement (move in straight line)
                // }
                else if (entity is PowerupEntity powerup)
                {
                    // Handle powerup movement
                }
            }
        }
    }
}
