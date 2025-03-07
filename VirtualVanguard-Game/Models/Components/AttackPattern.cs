using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class AttackPattern : IAttackComponent
    {
        public List<Attack> Attacks { get; set; }
        public AttackPattern()
        {
            Attacks = new List<Attack>();
        }
        public void AddAttack(Attack attack)
        {
            Attacks.Add(attack);
        }
        public List<Bullet> Execute(Vector2 position)
        {
            List<Bullet> Bullets = new List<Bullet>();
            for (int i = 0; i < Attacks.Count; i++)
            {
                Bullets.AddRange(Attacks[i].Execute(position));
            }
            return Bullets;
        }
    }
}
