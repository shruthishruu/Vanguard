using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class Player : Character
    {
        public bool SlowMode { get; set; }
        public Player(Vector2 position, int width, int height, Vector2 orientation, Texture2D image, AttackPattern attackPattern) : base(position, width, height, orientation, image, attackPattern)
        {
            SlowMode = false;
        }
    }
}