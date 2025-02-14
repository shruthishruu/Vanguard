using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace VirtualVanguard_Game.Models
{
    public class Boss : Enemy
    {
        public Boss(Vector2 position, int width, int height, int orientation, Texture2D image, TimeSpan attackTimer) : base(position, width, height, orientation, image, attackTimer)
        {
        }
    }
}