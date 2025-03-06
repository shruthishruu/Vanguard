using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class SpreadAttack : Attack
    {
        private int orientation;
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
        public SpreadAttack(int orientation, Texture2D image, Vector2 velocity, int angle, int numBullets)
        {
            this.orientation = orientation;
            this.image = image;
            this.velocity = velocity;
            this.angle = angle;
            this.numBullets = numBullets;
        }
        public override List<Bullet> Execute(Vector2 position)
        {
            List<Bullet> bullets = new List<Bullet>();
            float totalSpread = angle; // total angle of spread in degrees
            float angleStep = numBullets > 1 ? totalSpread / (numBullets - 1) : 0; // calculate the angle step

            for (int i = 0; i < numBullets; i++)
            {
                // Calculate the angle for this bullet
                float currentAngle = orientation - totalSpread / 2 + angleStep * i;
                Vector2 newVelocity = new Vector2((float)Math.Cos(MathHelper.ToRadians(currentAngle)), (float)Math.Sin(MathHelper.ToRadians(currentAngle))) * velocity.Length();
                Bullet newBullet = new Bullet(position, 10, 10, orientation, image, newVelocity);
                bullets.Add(newBullet);
            }
            return bullets;
        }

    }
}