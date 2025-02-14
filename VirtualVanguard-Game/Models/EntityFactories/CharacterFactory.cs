using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class CharacterFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, Vector2 position, int width, int height, int orientation, Texture2D image)
        {
            if (type == "Player")
            {
                
            }
            else if (type == "Enemy")
            {
                
            }
            else if (type == "Boss")
            {

            }
            else
            {
                throw new ArgumentException("Invalid entity type");
            }
            return new Character(position, width, height, orientation, image);
        }
    }
}