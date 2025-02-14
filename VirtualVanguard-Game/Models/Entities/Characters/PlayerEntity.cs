using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public class PlayerEntity : Entity
    {
        public PlayerEntity(Vector2 position, int width, int height, Texture2D image) : base(position, width, height, image)
        {
        }
    }
}