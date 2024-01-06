using System.IO;
using GameDevProject.Core.animations.mainCharacter;
using GameDevProject.Core.input;
using GameDevProject.Core.movement;
using GameDevProject.UI;
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
    public MainCharacterAnimationController AnimationController;
    public CharacterCollissionManager CollisionManager;
    
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    
    public int Lives = 3;
    public int DamageCooldown = 0;
    private int _flickerActive = 5;
    private bool _flickerWait = false;
    public IInputReader InputReader { get; set; }
    private MovementManager _movementManager;
    private HealthOverlay _overlay;

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
        _overlay = new HealthOverlay(this);
        
        
        InputReader = new KeyboardReader();
        Velocity = new Vector2(0, 0);
        Position = new Vector2(1, 1);
        AnimationController = new MainCharacterAnimationController(_game);
        AnimationController.Activate();
        CollisionManager = new CharacterCollissionManager(this);
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
        AnimationController.Update(time);
        
        // Game collisions
        CollisionManager.Update(time);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        var rectangleTexture = new Texture2D(_game.RootGame.GraphicsDevice, 1, 1);
        rectangleTexture.SetData(new[] { Color.White });
        
        // If we are currently in a damaged state we want to flicker
        if (DamageCooldown > 0 && _flickerActive > 0)
        {
            _flickerActive--;
            if (_flickerActive == 0)
            {
                _flickerWait = !_flickerWait;
                _flickerActive = 5;
            }
        }

        if (!(DamageCooldown > 0 && _flickerWait == false))
        {
            AnimationController.Draw(spriteBatch);
        }
        _overlay.Draw(spriteBatch);
    }
}