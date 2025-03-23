using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace VirtualVanguard_Game.Models
{
    public class GameManager
    {
        private static GameManager instance;
        public static GameManager Instance => instance ??= new GameManager();

        public bool IsPlayerAlive { get; private set; } = true;
        public bool HasPlayerWon { get; private set; } = false;

        private readonly double gameDuration = 40.0;

        public void CheckWinCondition(GameTime gameTime, IReadOnlyList<Entity> entities)
        {
            bool noEnemiesLeft = entities.All(entity => !(entity is Enemy));
            if (gameTime.TotalGameTime.TotalSeconds >= gameDuration || noEnemiesLeft)
            {
                HasPlayerWon = true;
                Console.WriteLine("You Win! Victory Achieved!");
            }
        }

        public void CheckLossCondition(Character player)
        {
            if (player.GetLife() <= 0)
            {
                IsPlayerAlive = false;
                Console.WriteLine("Game Over! You lost!");
            }
        }
    }
}
