using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public class PlayerBulletEntity : Entity
    {
        public PlayerBulletEntity(int x, int y, int width, int height, string imagePath) : base(x, y, width, height, imagePath)
        {
        }
    }
}