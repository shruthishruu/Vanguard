using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class EnemyBulletEntity : Entity
    {
        public EnemyBulletEntity(Vector2 position, int width, int height, Texture2D image) : base(position, width, height, image)
        {
        }
    }
}