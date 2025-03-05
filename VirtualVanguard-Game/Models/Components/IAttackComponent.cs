
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public interface IAttackComponent
    {
        public Vector2 OriginPosition { get; set; }
        public List<Bullet> Execute();
    }
}