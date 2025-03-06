using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class StraightAttack : Attack
    {
        private int orientation;
        private Texture2D image;
        private Vector2 velocity;
        public StraightAttack(Vector2 originPosition, int orientation, Texture2D image, Vector2 velocity)
        {
            this.orientation = orientation;
            this.image = image;
            this.velocity = velocity;
        }
        public override List<Bullet> Execute(Vector2 position)
        {
            Bullet newBullet = new Bullet(position, 10, 10, orientation, image, velocity);
            return new List<Bullet> { newBullet };
        }
    }
}