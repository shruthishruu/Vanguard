using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public class Inventory : Boundary
    {
        public List<Entity> Collectables { get; set; }
    }
}