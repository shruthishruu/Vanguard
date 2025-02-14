using System;
using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public class AttackControl : Control
    {
        public override void Update() {}
        public void Update(List<Entity> Characters)
        {
            // Implement attack logic here
            foreach (var character in Characters)
            {
                // Use factory to spawn bullets
            }
        }
    }
}
