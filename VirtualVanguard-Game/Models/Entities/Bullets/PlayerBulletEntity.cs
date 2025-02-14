using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class PlayerBulletEntity : Entity
    {
        public PlayerBulletEntity(Vector2 position, int width, int height, Texture2D image) : base(position, width, height, image)
        {
        }
    }
}