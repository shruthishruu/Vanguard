using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class StraightAttack : Attack
    {
        private Vector2 orientation;
        private Texture2D image;
        private Vector2 velocity;
        public StraightAttack(int speed, Vector2 orientation, Texture2D image) : base(speed)
        {
            this.orientation = orientation;
            this.image = image;
            velocity = new Vector2(speed * orientation.X, speed * orientation.Y);
        }
        public override List<Bullet> Execute(Vector2 position)
        {
            Bullet newBullet = new Bullet(position, 10, 10, orientation, image, velocity);
            return new List<Bullet> { newBullet };
        }
    }
}