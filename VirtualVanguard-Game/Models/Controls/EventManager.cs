using System;

namespace VirtualVanguard_Game.Models
{
    public class EventManager : Control
    {
        public EventManager() { }

        public override void Update()
        {
            Console.WriteLine("Updating EventManager without time.");
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            // Printing the total game time in seconds
            Console.WriteLine($"Total game time: {gameTime.TotalGameTime.TotalSeconds} seconds");
        }

    }

}
