using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace VirtualVanguard_Game.Models
{
    public class GameManager : IGameEventObserver
    {
        private static GameManager instance;
        public static GameManager Instance => instance ??= new GameManager();

        private EventManager eventManager;

        public bool IsPlayerAlive { get; private set; } = true;
        public bool HasPlayerWon { get; private set; } = false;

        private readonly double gameDuration = 40.0;

        public void OnEvent(GameEvent gameEvent)
        {
            switch (gameEvent.EventType)
            {
                case "CheckWinCondition":
                    var data = (dynamic)gameEvent.Data;
                    CheckWinCondition(data.gameTime, data.entities);
                    break;

                case "PlayerDied":
                    IsPlayerAlive = false;
                    Console.WriteLine("Game Over! You lost!");
                    break;

                case "GameWon":
                    HasPlayerWon = true;
                    Console.WriteLine("You Win! Victory Achieved!");
                    break;
            }
        }

        private void CheckWinCondition(GameTime gameTime, IReadOnlyList<Entity> entities)
        {
            bool noEnemiesLeft = entities.All(entity => !(entity is Enemy));
            if (gameTime.TotalGameTime.TotalSeconds >= gameDuration || noEnemiesLeft)
            {
                HasPlayerWon = true;
                Console.WriteLine("You Win! Victory Achieved!");

                // Notify that the game is won
                eventManager?.Notify(new GameEvent("GameWon"));
            }
        }
    }
}
