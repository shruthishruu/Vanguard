using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class AttackPattern
    {
        // Configuration for the attack pattern
        public AttackConfig Config { get; private set; }

        // Time between attacks
        public float Cooldown { get; set; }

        // Random number generator for attack variations
        private Random _rng;

        // List of basic attacks (can be combined for advanced attacks)
        private List<Func<Vector2, List<Bullet>>> _basicAttacks;

        public AttackPattern(AttackConfig config, float cooldown)
        {
            Config = config;
            Cooldown = cooldown;
            _rng = new Random();
            _basicAttacks = new List<Func<Vector2, List<Bullet>>>();
        }

        // Add a basic attack to the pattern
        public void AddBasicAttack(Func<Vector2, List<Bullet>> attack)
        {
            _basicAttacks.Add(attack);
        }

        // Execute the attack pattern
        public List<Bullet> Execute(Vector2 originPosition)
        {
            if (_basicAttacks.Count == 0)
            {
                throw new InvalidOperationException("No basic attacks defined for this pattern.");
            }

            // Randomly select a basic attack (or combine attacks for advanced patterns)
            int attackIndex = _rng.Next(_basicAttacks.Count);
            return _basicAttacks[attackIndex](originPosition);
        }
    }
    
    public abstract class AttackConfig
    {
        public string BulletType { get; set; }
        public float SpawnRate { get; set; }
        public float Speed { get; set; }
    }

    public class SpreadAttackConfig : AttackConfig
    {
        public int Direction { get; set; }
        public int SpreadAngle { get; set; }
        public int NumBullets { get; set; }
        public int Distance { get; set; }
    }

    public class SpiralAttackConfig : AttackConfig
    {
        public int NumBullets { get; set; }
        public float RotationSpeed { get; set; }
    }

    public class WaveAttackConfig : AttackConfig
    {
        public float Frequency { get; set; }
        public float Amplitude { get; set; }
    }

    public static class AttackPatterns
    {
        public static List<Bullet> SpreadAttack(Vector2 originPosition, Texture2D bulletTexture, SpreadAttackConfig config)
        {
            List<Bullet> bullets = new List<Bullet>();

            float angleStep = config.SpreadAngle / (config.NumBullets - 1);
            float startAngle = config.Direction - (config.SpreadAngle / 2);

            for (int i = 0; i < config.NumBullets; i++)
            {
                float currentAngle = startAngle + (angleStep * i);
                float angleRad = MathHelper.ToRadians(currentAngle);

                Vector2 offset = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad)) * config.Distance;
                Vector2 bulletPosition = originPosition + offset;

                Vector2 velocity = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad)) * config.Speed;

                Bullet bullet = new Bullet(bulletPosition, 5, 5, (int)currentAngle, bulletTexture, velocity);
                bullets.Add(bullet);
            }

            return bullets;
        }

        public static List<Bullet> SpiralAttack(Vector2 originPosition, Texture2D bulletTexture, SpiralAttackConfig config)
        {
            List<Bullet> bullets = new List<Bullet>();

            for (int i = 0; i < config.NumBullets; i++)
            {
                float angle = (i * 36) % 360; // 36 degrees between each bullet
                float angleRad = MathHelper.ToRadians(angle);

                Vector2 velocity = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad)) * config.Speed;

                Bullet bullet = new Bullet(originPosition, 5, 5, (int)angle, bulletTexture, velocity);
                bullets.Add(bullet);
            }

            return bullets;
        }

        public static List<Bullet> WaveAttack(Vector2 originPosition, Texture2D bulletTexture, WaveAttackConfig config)
        {
            List<Bullet> bullets = new List<Bullet>();

            float angleRad = MathHelper.ToRadians(0); // Wave direction (0 degrees for simplicity)
            float yOffset = config.Amplitude * (float)Math.Sin(0 * config.Frequency); // Wave effect

            Vector2 velocity = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad) + yOffset) * config.Speed;

            Bullet bullet = new Bullet(originPosition, 5, 5, 0, bulletTexture, velocity);
            bullets.Add(bullet);

            return bullets;
        }
    }
    public class AttackPatternFactory
    {
        public AttackPattern CreateSpreadAttack(float cooldown, Texture2D bulletTexture)
        {
            var config = new SpreadAttackConfig
            {
                BulletType = "EnemyBullet",
                SpawnRate = 0.5f,
                Speed = 3.0f,
                Direction = 90,
                SpreadAngle = 60,
                NumBullets = 10,
                Distance = 50
            };

            var pattern = new AttackPattern(config, cooldown);
            pattern.AddBasicAttack((position) => AttackPatterns.SpreadAttack(position, bulletTexture, config));
            return pattern;
        }

        public AttackPattern CreateSpiralAttack(float cooldown, Texture2D bulletTexture)
        {
            var config = new SpiralAttackConfig
            {
                BulletType = "EnemyBullet",
                SpawnRate = 0.2f,
                Speed = 2.0f,
                NumBullets = 20,
                RotationSpeed = 1.5f
            };

            var pattern = new AttackPattern(config, cooldown);
            pattern.AddBasicAttack((position) => AttackPatterns.SpiralAttack(position, bulletTexture, config));
            return pattern;
        }

        public AttackPattern CreateWaveAttack(float cooldown, Texture2D bulletTexture)
        {
            var config = new WaveAttackConfig
            {
                BulletType = "EnemyBullet",
                SpawnRate = 0.3f,
                Speed = 2.5f,
                Frequency = 5.0f,
                Amplitude = 2.0f
            };

            var pattern = new AttackPattern(config, cooldown);
            pattern.AddBasicAttack((position) => AttackPatterns.WaveAttack(position, bulletTexture, config));
            return pattern;
        }
    }


}
