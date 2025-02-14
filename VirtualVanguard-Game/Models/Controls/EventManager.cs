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
             double totalSeconds = gameTime.TotalGameTime.TotalSeconds;

             Console.WriteLine($"Total game time: {totalSeconds} seconds");

            if (totalSeconds >= 2 && totalSeconds < 2.1)
            {
                Console.WriteLine("Spawning Player...");
                entityFactory.CreateEntity("Player", 100, 200, 50, 50, "player.png");
            }

            if (totalSeconds >= 5 && totalSeconds < 5.1)
            {
                Console.WriteLine("Spawning Enemy...");
                entityFactory.CreateEntity("Enemy", 0, 0, 50, 50, "enemy.png");
            }

            if (totalSeconds >= 30 && totalSeconds < 30.1)
            {
                Console.WriteLine("Spawning Boss...");
                entityFactory.CreateEntity("Boss", 400, 100, 100, 100, "boss.png");
            }
        }

    }

}
