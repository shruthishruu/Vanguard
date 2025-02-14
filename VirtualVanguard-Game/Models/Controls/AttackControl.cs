using System;

namespace VirtualVanguard_Game.Models
{
    public class AttackControl : Control
    {
        public override void Update(List<Enemy> enemies)
        {
            // Implement attack logic here
            foreach (var enemy in enemies)
            {
                // Use factory to spawn bullets
            }
        }
    }
}
