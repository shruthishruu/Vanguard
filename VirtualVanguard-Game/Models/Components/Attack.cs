
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public abstract class Attack : IAttackComponent
    {
        public abstract List<Bullet> Execute(Vector2 position);
    }
}