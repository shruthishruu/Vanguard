using System;
using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public class RenderControl : Control
    {
        public override void Update() {}
        public void Update(List<Entity> Entities)
        {
            // Implement attack logic here
            foreach (var enemy in Entities)
            {
                
            }
        }
    }
}
