using System;

namespace VirtualVanguard_Game.Models
{
    public class PlayerMovementControl : MovementControl
    {
        public override void Update(PlayerEntity player, int keyboardInput)
        {
            if (keyboardInput == 1) // Up
            {
                player.Y -= player.Speed;
            }
            else if (keyboardInput == 2) // Down
            {
                player.Y += player.Speed;
            }
            else if (keyboardInput == 3) // Left
            {
                player.X -= player.Speed;
            }
            else if (keyboardInput == 4) // Right
            {
                player.X += player.Speed;
            }
        }
    }
}
