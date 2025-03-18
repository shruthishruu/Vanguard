using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class Player : Character
    {
        public bool SlowMode { get; set; }
        public Player(Vector2 position, int width, int height, int orientation, Texture2D image) : base(position, width, height, orientation, image)
        {
            SlowMode = false;
        }
    }
}