using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using VirtualVanguard_Game.Models;

namespace VirtualVanguard_Game.Models
{
    public class BulletFactory : EntityFactory
    {
        private Dictionary<string, Texture2D> bulletTextures;

        public BulletFactory(ContentManager content, EntityManager entityManager) : base(content, entityManager)
        {
            // Load bullet textures once and store them
            bulletTextures = new Dictionary<string, Texture2D>
            {
                { "EnemyBullet", content.Load<Texture2D>("EnemyBullet") },
                { "PlayerBullet", content.Load<Texture2D>("PlayerBullet") },
                { "BossBullet", content.Load<Texture2D>("BossBullet") }
            };
        }

        public override void CreateEntity(string type, Vector2 position, int width, int height, int orientation)
        {
            if (!bulletTextures.ContainsKey(type))
                throw new ArgumentException("Invalid bullet type");

            Texture2D image = bulletTextures[type];

            Vector2 defaultVelocity = new Vector2(0, 5); // Bullets move down by default
            AddEntity(new Bullet(position, width, height, orientation, image, defaultVelocity));
        }

        public void CreateAttack(string bulletType, Vector2 spawnPosition, string patternType)
        {
            if (!bulletTextures.ContainsKey(bulletType))
                throw new ArgumentException("Invalid bullet type");

            // Get the pre-defined pattern configuration
            var patternConfig = GetPatternConfiguration(patternType);

            // Create the attack pattern with pre-defined values
            AttackPattern pattern = new AttackPattern(bulletType, patternConfig.SpawnRate, patternConfig.Speed, patternConfig.Direction, GetPatternFunction(patternType));
            List<Bullet> bullets = pattern.Execute(spawnPosition, bulletTextures[bulletType]);
            foreach (var bullet in bullets)
            {
                entityManager.AddEntity(bullet);
            }
        }

        private (float SpawnRate, float Speed, float Direction) GetPatternConfiguration(string patternType)
        {
            return patternType.ToLower() switch
            {
                "spiral" => (SpawnRate: 0.1f, Speed: 3.0f, Direction: 0f), // Spiral pattern configuration
                "wave" => (SpawnRate: 0.2f, Speed: 2.5f, Direction: 90f), // Wave pattern configuration
                "straight" => (SpawnRate: 0.3f, Speed: 4.0f, Direction: 180f), // Straight pattern configuration
                _ => (SpawnRate: 0.3f, Speed: 4.0f, Direction: 180f), // Default to straight shot
            };
        }

        private Func<AttackPattern, Vector2, Texture2D, List<Bullet>> GetPatternFunction(string patternType)
        {
            return patternType.ToLower() switch
            {
                "spiral" => AttackPatterns.SpiralAttack,
                "wave" => AttackPatterns.WaveAttack,
                "straight" => AttackPatterns.StraightShot,
                _ => AttackPatterns.StraightShot, // Default to straight shot
            };
        }

        private class AttackPattern
        {
            public string BulletType { get; }
            public float SpawnRate { get; }
            public float Speed { get; }
            public float Direction { get; }
        
            private readonly Func<AttackPattern, Vector2, Texture2D, List<Bullet>> patternFunction;
            private float timeSinceLastShot = 0f;

            public AttackPattern(string bulletType, float spawnRate, float speed, float direction, 
                                 Func<AttackPattern, Vector2, Texture2D, List<Bullet>> patternFunction)
            {
                BulletType = bulletType;
                SpawnRate = spawnRate;
                Speed = speed;
                Direction = direction;
                this.patternFunction = patternFunction;
            }

            public List<Bullet> Execute(Vector2 spawnPosition, Texture2D bulletTexture)
            {
                List<Bullet> bullets = new List<Bullet>();
                timeSinceLastShot += 1f / SpawnRate;

                if (timeSinceLastShot >= 1f / SpawnRate)
                {
                    bullets.AddRange(patternFunction.Invoke(this, spawnPosition, bulletTexture));
                    timeSinceLastShot = 0f;
                }

                return bullets;
            }
        }

        private static class AttackPatterns
        {
            public static List<Bullet> StraightShot(AttackPattern pattern, Vector2 spawnPosition, Texture2D bulletTexture)
            {
                List<Bullet> bullets = new List<Bullet>();
                float angleRad = MathHelper.ToRadians(pattern.Direction);
                Vector2 velocity = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad)) * pattern.Speed;

                bullets.Add(new Bullet(spawnPosition, 5, 5, (int)pattern.Direction, bulletTexture, velocity));
                return bullets;
            }

            public static List<Bullet> SpiralAttack(AttackPattern pattern, Vector2 spawnPosition, Texture2D bulletTexture)
            {
                List<Bullet> bullets = new List<Bullet>();
                int numBullets = 10;

                for (int i = 0; i < numBullets; i++)
                {
                    float angle = (pattern.Direction + (i * 36)) % 360;
                    float angleRad = MathHelper.ToRadians(angle);
                    Vector2 velocity = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad)) * pattern.Speed;

                    bullets.Add(new Bullet(spawnPosition, 5, 5, (int)angle, bulletTexture, velocity));
                }

                return bullets;
            }

            public static List<Bullet> WaveAttack(AttackPattern pattern, Vector2 spawnPosition, Texture2D bulletTexture)
            {
                List<Bullet> bullets = new List<Bullet>();

                float frequency = 5f;
                float amplitude = 2f;
                float angleRad = MathHelper.ToRadians(pattern.Direction);
                float yOffset = amplitude * (float)Math.Sin(pattern.Direction * frequency);

                Vector2 velocity = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad) + yOffset) * pattern.Speed;

                bullets.Add(new Bullet(spawnPosition, 5, 5, (int)pattern.Direction, bulletTexture, velocity));

                return bullets;
            }
        }
    }
}