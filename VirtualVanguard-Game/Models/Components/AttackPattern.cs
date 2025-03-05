using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class AttackPattern : IAttackComponent
    {
        public Vector2 OriginPosition { get; set; }
        public List<Attack> Attacks { get; set; }
        public List<Bullet> Execute()
        {
            List<Bullet> Bullets = new List<Bullet>();
            for (int i = 0; i < Attacks.Count; i++)
            {
                Bullets.AddRange(Attacks[i].Execute());
            }
            return Bullets;
        }
    }
}
