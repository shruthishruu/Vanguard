using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class SpreadAttack : Attack
    {
        private Texture2D image;
        private int angle;
        private int numBullets;
        private Vector2 orientation;
        private int speed;

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
            this.orientation = orientation;
            this.image = image;
            this.angle = angle;
            this.numBullets = numBullets;
            this.speed = speed;
        }
        public override List<Bullet> Execute(Vector2 position, bool isPlayerBullet)
        {
            List<Bullet> bullets = new List<Bullet>();

            // Starting angle based on the orientation
            float startAngle = (float)Math.Atan2(orientation.Y, orientation.X) - MathHelper.ToRadians(angle / 2.0f);
            float angleIncrement = MathHelper.ToRadians(angle) / (numBullets - 1);

            for (int i = 0; i < numBullets; i++)
            {
                // Calculate the orientation for each bullet
                Vector2 newOrientation = new Vector2(
                    (float)Math.Cos(startAngle + angleIncrement * i),
                    (float)Math.Sin(startAngle + angleIncrement * i)
                );
                // Adjust velocity according to the new orientation
                Vector2 newVelocity = new Vector2(speed * newOrientation.X, speed * newOrientation.Y);
                if (isPlayerBullet)
                {
                    PlayerBullet newBullet = new PlayerBullet(position, 10, 10, newOrientation, image, newVelocity);
                    bullets.Add(newBullet);
                }
                else
                {
                    EnemyBullet newBullet = new EnemyBullet(position, 10, 10, newOrientation, image, newVelocity);
                    bullets.Add(newBullet);
                }
            }

            return bullets;
        }

    }
}