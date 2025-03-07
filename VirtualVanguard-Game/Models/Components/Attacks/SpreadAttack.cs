using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class SpreadAttack : Attack
    {
        private Texture2D image;
        private Vector2 velocity;
        private int angle;
        private int numBullets;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orientation"></param>
        /// <param name="image"></param>
        /// <param name="velocity"></param>
        /// <param name="angle">Angle in degrees</param>
        /// <param name="numBullets"></param>
        public SpreadAttack(int speed, Vector2 orientation, Texture2D image, int angle, int numBullets) : base(speed)
        {
            this.image = image;
            this.angle = angle;
            this.numBullets = numBullets;
            velocity = new Vector2(speed * orientation.X, speed * orientation.Y);
        }
        public override List<Bullet> Execute(Vector2 position)
        {
            List<Bullet> bullets = new List<Bullet>();
            for (int i = 0; i < numBullets; i++)
            {
                Vector2 newOrientation = new Vector2((float)Math.Cos(MathHelper.ToRadians(angle * i)), (float)Math.Sin(MathHelper.ToRadians(angle * i)));
                Bullet newBullet = new Bullet(position, 10, 10, newOrientation, image, velocity);
                bullets.Add(newBullet);
            }
            return bullets;
        }

    }
}