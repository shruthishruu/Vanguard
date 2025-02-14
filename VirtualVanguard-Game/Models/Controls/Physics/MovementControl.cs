using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VirtualVanguard_Game.Models
{
    public class MovementControl : Control
    {
        private Random rnd;

        public MovementControl()
        {
            rnd = new Random();
        }

        public override void Update() {

        }
        public void Update(List<Entity> entities)
        {
            // Implement movement logic here
            foreach (var entity in entities)
            {
                // Should be used to calculate the max x and y positions for each entity based off size.
                // Note: Not working correctly now, needs some tinkering.
                int maxX = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - entity.Width;
                int maxY = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - entity.Height;

                if (entity is PlayerEntity player)
                {
                    bool upPressed = Keyboard.GetState().IsKeyDown(Keys.Up);
                    bool downPressed = Keyboard.GetState().IsKeyDown(Keys.Down);
                    bool leftPressed = Keyboard.GetState().IsKeyDown(Keys.Left);
                    bool rightPressed = Keyboard.GetState().IsKeyDown(Keys.Right);

                    float posX = entity.Position.X;
                    float posY = entity.Position.Y;

                    // Handle player movement (use keyboard input)
                    if (upPressed && posY > 0) {
                        posY = posY - 1;
                    }
                    if (downPressed && posY < maxY)
                    {
                        posY = posY + 1;
                    }
                    if (leftPressed && posX > 0)
                    {
                        posX = posX - 1;
                    }
                    if (rightPressed && posX < maxX)
                    {
                        posX = posX + 1;
                    }

                    entity.Position = new Vector2(posX, posY);
                }
                else if (entity is EnemyEntity enemy)
                {
                    // Handle enemy movement (move randomly)
                    float posX = entity.Position.X;
                    float posY = entity.Position.Y;

                    // Randomly picking number between 0 and 3
                    // Based off that number the Enemy Moves
                    int nextMove = rnd.Next(0,4);

                    switch (nextMove) {
                        case 0:
                            if (posY > 0)
                                posY = posY - 1;
                            break;
                        case 1:
                            if (posY < maxX)
                                posY = posY + 1;
                            break;
                        case 2:
                            if (posX > 0)
                                posX = posX - 1;
                            break;
                        case 3:
                            if (posX < maxY)
                                posX = posX + 1;
                            break;
                        default:
                            break;
                    }

                    entity.Position = new Vector2(posX, posY);
                }
                else if (entity is PlayerBulletEntity bullet)
                {
                    // Handle bullet movement (move in straight line)
                }
                else if (entity is PowerupEntity powerup)
                {
                    // Handle powerup movement
                }
            }
        }
    }
}
