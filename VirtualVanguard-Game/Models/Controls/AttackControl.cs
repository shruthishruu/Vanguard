using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Threading.Tasks.Dataflow;

namespace VirtualVanguard_Game.Models
{
    public class AttackControl
    {
        private ContentManager Content;
        public AttackControl(ContentManager content)
        {
            Content = content;
        }
        public void Update(List<Entity> Characters, GameTime gameTime)
        {
            foreach (var character in Characters)
            {
                if (character is Player player)
                {
                    // Handle player-specific attack logic
                }
                else if (character is Enemy enemy)
                {
                    if (enemy.AttackTimer == TimeSpan.Zero)
                    {
                        enemy.AttackTimer = gameTime.TotalGameTime;
                    }

                    if (gameTime.TotalGameTime - enemy.AttackTimer >= TimeSpan.FromSeconds(1))
                    {
                        Console.WriteLine("Enemy attacks!");
                        enemy.AttackTimer = gameTime.TotalGameTime;
                    }
                }
            }
        }
    }
}
