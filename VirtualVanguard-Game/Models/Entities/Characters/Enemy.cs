using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;




namespace VirtualVanguard_Game.Models
{
    public class Enemy : Character
    {
        public TimeSpan AttackTimer { get; set; } = TimeSpan.Zero;
        public string AttackPattern;
        public Enemy(Vector2 position, int width, int height, int orientation, Texture2D image, string attackPattern)
            : base(position, width, height, orientation, image)
        {
            AttackPattern = attackPattern;
        }
    }
}