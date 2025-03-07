using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class Character : Entity
    {
        public AttackPattern AttackPattern { get; set; }
        public Character(Vector2 position, int width, int height, Vector2 orientation, Texture2D image, AttackPattern attackPattern) : base(position, width, height, orientation, image)
        {
            AttackPattern = attackPattern;
        }
    }
}