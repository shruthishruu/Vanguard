namespace VirtualVanguard_Game.Models
{
    static public class EventManager: Boundary
    {
        /// <summary>
        /// Constructor for EventManager
        /// </summary>
        /// <param name="time"> The current time of the game </param>
        override public void Update(int time)
        {
            // Print the current time
            Console.WriteLine(time);
        }
    }
}