using System;

namespace VirtualVanguard_Game.Models
{
    public class CharacterEntityFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "Player")
            {
                return new PlayerEntity(x, y, width, height, imagePath);
            }
            else if (type == "Enemy")
            {
                return new EnemyEntity(x, y, width, height, imagePath);
            }
            else if (type == "Boss")
            {
                return new BossEntity(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid character type");
            }
        }
    }
}