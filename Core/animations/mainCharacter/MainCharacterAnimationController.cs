using System;
using GameDevProject.Core.gameStates;
using GameDevProject.utility.statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.Core.animations.mainCharacter;

public class MainCharacterAnimationController : StateMachine
{
    public GameManager Game;
    public Texture2D SpriteSheet;

    public MainCharacterAnimationController(GameManager game)
    {
        LogPrefix = "[CH]";
        LogChanges = true;
        
        Game = game;
        SpriteSheet = Game.RootGame.Content.Load<Texture2D>("character");
        
        AddState(new AttackState(this));
        AddState(new HappyJumpAwardState(this));
        AddState(new HurtState(this));
        AddState(new IdlingState(this));
        AddState(new RunningState(this));
    }
    
    protected override void OnActivate()
    {
        GoToState<IdlingState>();
    }

    protected override void OnDeactivate()
    {
        
    }

    protected override void OnNoState()
    {
        GoToState<IdlingState>();
    }

    public void Draw(SpriteBatch batch)
    {
        if (ActiveState is GameState state) // Should always be the case but just in case
        {
            state.OnDraw(batch);
        }
        else
        {
            throw new Exception("Active state was not a gamestate!");
        }
    }

    public void Update(GameTime time)
    {
        ActiveState?.OnUpdate(time);

        if (ActiveState is AttackState || ActiveState is HurtState) return; // Automatically switches back to a different state
        
        // Check if left or right keys are pressed to do the walking animation
        if (Mouse.GetState().LeftButton == ButtonState.Pressed) 
        {
            if (ActiveState is not AttackState) GoToState<AttackState>();
        } 
        else if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            if (ActiveState is not RunningState) GoToState<RunningState>();
        }
        else
        {
            if (ActiveState is not IdlingState) GoToState<IdlingState>();
        }
    }
}