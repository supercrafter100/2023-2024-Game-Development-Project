using System.IO;
using GameDevProject.Core.animations.mainCharacter;
using GameDevProject.Core.input;
using GameDevProject.Core.movement;
using GameDevProject.utility.animation;
using GameDevProject.utility.collisions;
using GameDevProject.utility.statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.Core;

public class Character : IGameObject, IMovable, ICollidable
{
    public GameManager _game;
    
    private MainCharacterAnimationController _animationController;
    
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public IInputReader InputReader { get; set; }
    private MovementManager _movementManager;

    public Rectangle HitBox
    {
        get => new((int) Position.X + _game.MapManager.TileWidth / 4, (int) (Position.Y + _game.MapManager.TileHeight * 0.6), (int)(_game.MapManager.TileWidth * 0.8), (int)(_game.MapManager.TileHeight * 0.7));
        set => HitBox = value;
    }
    
    public Rectangle DestinationCharacterRectangle => new((int)Position.X, (int)Position.Y, (int)(_game.MapManager.TileWidth * 1.3), (int)(_game.MapManager.TileHeight * 1.3));

    public Character(GameManager gameManager)
    {
        _game = gameManager;
        _movementManager = new MovementManager(_game);
        
        InputReader = new KeyboardReader();
        Velocity = new Vector2(1, 0);
        Position = new Vector2(1, 1);
        _animationController = new MainCharacterAnimationController(_game);
        _animationController.Activate();
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
        _animationController.Update(time);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        var rectangleTexture = new Texture2D(_game.RootGame.GraphicsDevice, 1, 1);
        rectangleTexture.SetData(new[] { Color.White });
        //spriteBatch.Draw(rectangleTexture, HitBox, Color.Red);
        
        _animationController.Draw(spriteBatch);
    }
}