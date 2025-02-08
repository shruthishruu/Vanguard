using System;
using GameProject;

namespace Game  
{
    public static class Program
    {
        public static void Main()
        {
            using (var game = new Game1())  
            {
                game.Run();
            }
        }
    }
}

