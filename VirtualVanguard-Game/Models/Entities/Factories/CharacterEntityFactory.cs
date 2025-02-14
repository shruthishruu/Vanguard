using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class CharacterEntityFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, Vector2 position, int width, int height, Texture2D image)
        {
            if (type == "Player")
            {
                return new PlayerEntity(position, width, height, image);
            }
            else if (type == "Enemy")
            {
                return new EnemyEntity(position, width, height, image);
            }
            else if (type == "Boss")
            {
                return new BossEntity(position, width, height, image);
            }
            else
            {
                throw new ArgumentException("Invalid character type");
            }
        }
    }
}