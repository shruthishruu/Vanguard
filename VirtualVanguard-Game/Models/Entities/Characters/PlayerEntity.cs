using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public class PlayerEntity : Entity
    {
        public PlayerEntity(int x, int y, int width, int height, string imagePath) : base(x, y, width, height, imagePath)
        {
        }
    }
}