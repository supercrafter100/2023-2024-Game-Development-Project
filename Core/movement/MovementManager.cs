using System;
using System.IO;
using GameDevProject.Map;
using Microsoft.Xna.Framework;

namespace GameDevProject.Core.movement;

public class MovementManager
{
    private GameManager _game;
    private bool _grounded = false;
    public MovementManager(GameManager manager)
    {
        _game = manager;
    }
    
    public void Move(IMovable movable)
    {
        Vector2 direction = movable.InputReader.ReadInput();
        
        // Movement in the horizontal axis
        float horizontalDistanceToTravel = direction.X * movable.Velocity.X;
        Vector2 futureHorizontalPosition = movable.Position + new Vector2(horizontalDistanceToTravel, 0);
        Rectangle futureHorizontalHitbox = new Rectangle((int)(_game.Character.HitBox.X +  + horizontalDistanceToTravel),
            _game.Character.HitBox.Y, _game.Character.HitBox.Width,
            _game.Character.HitBox.Height);
        
        if (futureHorizontalPosition.X < _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth -
            _game.Character.HitBox.Width && futureHorizontalPosition.X > 0 && _game.MapManager.CollidesWithTerrain(futureHorizontalHitbox) == null)
        {
            movable.Position = futureHorizontalPosition;
        }
        
        // Movement in the vertical axis
        // Increase the y velocity of our character, if it collides with something after this, we don't do anything and set the velocity back to 0
        if (direction.Y > 0 && _grounded)
        {
            Console.WriteLine("JUMP");
            movable.Velocity = new Vector2(movable.Velocity.X, -5);
            _grounded = false;
        }

        
        movable.Velocity = new Vector2(movable.Velocity.X, Math.Clamp(movable.Velocity.Y + 0.1f, -30, 80));
        
        float verticalDistanceToTravel = movable.Velocity.Y;
        Vector2 futureVerticalPosition = movable.Position + new Vector2(0, verticalDistanceToTravel);
        Rectangle futureVerticalHitbox = new Rectangle(_game.Character.HitBox.X,
            (int)(_game.Character.HitBox.Y + verticalDistanceToTravel), _game.Character.HitBox.Width,
            _game.Character.HitBox.Height);
        
        if (futureVerticalPosition.Y < _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth -
            _game.Character.HitBox.Height && futureVerticalPosition.Y > 0 && _game.MapManager.CollidesWithTerrain(futureVerticalHitbox) == null)
        {
            movable.Position = futureVerticalPosition;
        }
        else if (futureVerticalPosition.Y < 0)
        {
            movable.Velocity = new Vector2(movable.Velocity.X, 0);
        }
        else 
        {
            _grounded = true;
            movable.Velocity = new Vector2(movable.Velocity.X, 0);
        }
        
        // dirty fix to bump character back up if there is an active collision with the ground
        if (_game.MapManager.CollidesWithTerrain(_game.Character.HitBox) != null)
        {
            Tile tileWeHit = _game.MapManager.CollidesWithTerrain(_game.Character.HitBox);
            movable.Position = new Vector2(movable.Position.X, tileWeHit!.HitBox.Y - tileWeHit.HitBox.Height - (_game.Character.HitBox.Height / 2) + 3);
        }
    }
}