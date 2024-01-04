using System;
using Microsoft.Xna.Framework;

namespace GameDevProject.Core.movement;

public class MovementManager
{
    private GameManager _game;
    public MovementManager(GameManager manager)
    {
        _game = manager;
    }
    
    public void Move(IMovable movable)
    {
        Vector2 direction = movable.InputReader.ReadInput();
        Vector2 distance = direction * movable.Speed;

        // Collisions
        Vector2 futurePosition = movable.Position + distance;
        if (futurePosition.X < (_game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth - 180) &&
            futurePosition.X > 0 &&
            (futurePosition.Y < _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight - 247) &&
            futurePosition.Y > 0)
        {
            movable.Position = futurePosition;
        }
    }
}