
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public interface IAttackComponent
    {
        public List<Bullet> Execute(Vector2 position, bool isPlayerBullet);
    }
}