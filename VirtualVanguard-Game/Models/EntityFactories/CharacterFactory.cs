using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class CharacterFactory : EntityFactory
    {
        private ContentManager Content;
        public CharacterFactory(ContentManager content) : base(content)
        {
            Content = content;
        }
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