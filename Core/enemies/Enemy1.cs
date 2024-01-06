using System;
using GameDevProject.Core.animations.enemy1;
using GameDevProject.Core.gameStates;
using GameDevProject.utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DeathState = GameDevProject.Core.animations.enemy1.DeathState;

namespace GameDevProject.Core.enemies;

public class Enemy1 : Enemy
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
    private float _progress = 0;
    private bool _increasing = true;

    public Enemy1(GameManager game, Vector2 startPosition, Vector2 endPosition)
    {
        LogPrefix = "[E1]";
        LogChanges = true;
        
        _game = game;
        Position = startPosition;

        _startPos = startPosition;
        _endPos = endPosition;
        
        AddState(new AttackState(this));
        AddState(new DeathState(this));
        AddState(new HurtState(this));
        AddState(new IdlingState(this));
        AddState(new RunningState(this));

        Texture = _game.RootGame.Content.Load<Texture2D>("enemy1");
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

    public override void Update(GameTime time)
    {
        // Linear interpolation between two values
        ActiveState?.OnUpdate(time);

        if (ActiveState is DeathState) return;

        if (ActiveState is AttackState) return; // Don't want to move if we are attacking
        if (ActiveState is IdlingState)
        {
            if (_r.Next(0, 1000) < 10) GoToState<RunningState>();
            else return;
        }
        
        // Movement
        Position = Vector2.Lerp(_startPos, _endPos, _progress);
        if (_increasing) _progress += 0.005f;
        else _progress -= 0.005f;

        if (_progress >= 1 && _increasing)
        {
            _increasing = false;
            Direction = Direction.Left;
        }

        if (_progress <= 0 && !_increasing)
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