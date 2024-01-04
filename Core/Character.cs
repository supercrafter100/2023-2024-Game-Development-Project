using System.IO;
using GameDevProject.Core.input;
using GameDevProject.Core.movement;
using GameDevProject.utility.animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.Core;

public class Character : IGameObject, IMovable
{
    private GameManager _game;
    
    private Texture2D _texture;
    private Animation _animation;
    
    public Vector2 Position { get; set; }
    public Vector2 Speed { get; set; }
    public IInputReader InputReader { get; set; }
    private MovementManager _movementManager;

    public Character(Texture2D texture, GameManager gameManager)
    {
        _game = gameManager;
        _texture = texture;
        _movementManager = new MovementManager(_game);
        
        InputReader = new KeyboardReader();
        Speed = new Vector2(1, 1);
        Position = new Vector2(1, 1);
        
        _animation = new Animation();
        _animation.AddFrames(AnimationUtility.GetFramesFromTextureProperties(_texture.Width, _texture.Height, 5, 2));
    }
    
    private void Move()
    {
        _movementManager.Move(this);
    }
    
    public void Update(GameTime time)
    {
        // Movement
        Move();
        
        // Animation
        _animation.Update(time);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, _animation.CurrentFrame.SourceRectangle, Color.White);
    }
}