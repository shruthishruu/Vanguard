using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class Character : Entity
    {
        // New: Life attribute to manage character health
        private int life;

        public AttackPattern AttackPattern { get; set; }

        // Constructor to initialize character with life and other properties
        public Character(Vector2 position, int width, int height, Vector2 orientation, Texture2D image, AttackPattern attackPattern) 
            : base(position, width, height, orientation, image)
        {
            AttackPattern = attackPattern;
            life = 5;  // Default life (you can adjust this value)
        }

        // New: Method to reduce life
        public void ReduceLife(int damage)
        {
            life -= damage;
            if (life < 0)
            {
                life = 0;
            }
        }

        // New: Method to get current life
        public int GetLife()
        {
            return life;
        }
    }
}
