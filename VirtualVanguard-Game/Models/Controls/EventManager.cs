using System;

namespace VirtualVanguard_Game.Models
{
    public class EventManager : Control
    {
        CharacterEntityFactory characterFactory
        public EventManager() { 
            characterFactory = new CharacterEntityFactory();
        }

        public override void Update()
        {
            Console.WriteLine("Updating EventManager without time.");
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
            // Printing the total game time in seconds
            Console.WriteLine($"Total game time: {gameTime.TotalGameTime.TotalSeconds} seconds");

            // this is where you add events
            // example of spawning enemy
            if (gameTime.TotalGameTime.TotalSeconds == 5):
                Console.WriteLine("Spawning enemy");
                characterFactory.CreateEntity("Enemy", 0, 0, 50, 50, "enemy.png");
                
        }

    }

}
