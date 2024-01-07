using System;
using GameDevProject.Core.animations.enemy3;
using GameDevProject.Core.gameStates;
using GameDevProject.utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DeathState = GameDevProject.Core.animations.enemy3.DeathState;

namespace GameDevProject.Core.enemies;

public class Enemy3 : Enemy
{
    private GameManager _game;
    private Random _r = new();
    
    public override Rectangle HitBox
    {
        get => new((int) Position.X + _game.MapManager.TileWidth / 4, (int) (Position.Y + _game.MapManager.TileHeight * 0.6), (int)(_game.MapManager.TileWidth * 0.8), (int)(_game.MapManager.TileHeight * 0.7));
        set => HitBox = value;
    }
    
    public override Texture2D Texture { get; set; }
    public override Rectangle DestinationCharacterRectangle => new((int)Position.X, (int)Position.Y, (int)(_game.MapManager.TileWidth * 1.3), (int)(_game.MapManager.TileHeight * 1.3));
    
    private Vector2 _startPos;
    private Vector2 _endPos;
    private bool _increasing = true;

    public Enemy3(GameManager game, Vector2 startPosition, Vector2 endPosition)
    {
        LogPrefix = "[E1]";
        LogChanges = true;
        
        _game = game;
        Position = startPosition;

        _startPos = startPosition;
        _endPos = endPosition;
        
        AddState(new AttackState(this));
        AddState(new DeathState(this));
        AddState(new IdlingState(this));
        AddState(new RunningState(this));

        Texture = _game.RootGame.Content.Load<Texture2D>("enemy3");
    }
    
    protected override void OnActivate()
    {
        GoToState<IdlingState>();
    }

    protected override void OnDeactivate()
    {
        GotoNoState();
    }

    protected override void OnNoState()
    {
        GoToState<RunningState>();
    }
    
    // ENEMY BEHAVIOR:
    // - Will randomly walk like enemy1
    // - If character is less than a certain amount away from the player, the enemy will move away from the player their X coordinate
    // - If character is more than a certain amount away from the player, the enemy will roam randomly
    public override void Update(GameTime time)
    {
        // Linear interpolation between two values
        ActiveState?.OnUpdate(time);

        if (ActiveState is DeathState) return;

        if (Vector2.Distance(Position, _game.Character.Position) < 500)
        {
            if (Vector2.Distance(Position, _game.Character.Position) < 100)
            {
                if (ActiveState is not AttackState) GoToState<AttackState>();
            } else if (ActiveState is not RunningState)
            {
                GoToState<RunningState>();
            }
            
            // Move towards the player's coordinate
            if (_game.Character.Position.X > Position.X && Position.X > _startPos.X)
            {
                Direction = Direction.Left;
                Position = new Vector2(Position.X - 2.5f, Position.Y);
            } else if (_game.Character.Position.X < Position.X && Position.X < _endPos.X)
            {
                Direction = Direction.Right;
                Position = new Vector2(Position.X + 2.5f, Position.Y);
            }
            return;
        }

        if (ActiveState is AttackState) return; // Don't want to move if we are attacking
        if (ActiveState is IdlingState)
        {
            if (_r.Next(0, 1000) < 10) GoToState<RunningState>();
            else return;
        }
        
        // Movement
        Position = new Vector2(Position.X + (_increasing ? 2.5f : -2.5f), Position.Y);

        if (Position.X >= _endPos.X && _increasing)
        {
            _increasing = false;
            Direction = Direction.Left;
        }

        if (Position.X <= _startPos.X && !_increasing)
        {
            _increasing = true;
            Direction = Direction.Right;
        }
        
        // Random chance to start idling
        if (_r.Next(0, 1000) == 1) GoToState<IdlingState>();
        
        // Random chance to start an attack
        if (_r.Next(0, 1000) == 1) GoToState<AttackState>();
        
        // Random chance to change direction
        if (_r.Next(0, 1000) < 5)
        {
            _increasing = !_increasing;
            Direction = Direction == Direction.Left ? Direction.Right : Direction.Left;
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (ActiveState is GameState state) state.OnDraw(spriteBatch);
    }
}