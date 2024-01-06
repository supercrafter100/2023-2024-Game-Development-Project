﻿using GameDevProject.Core.gameStates;
using GameDevProject.utility.animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.Core.animations.mainCharacter;

public class HappyJumpAwardState : GameState
{
    private MainCharacterAnimationController _controller;
    private Animation _animation;

    public HappyJumpAwardState(MainCharacterAnimationController controller)
    {
        _controller = controller;
        _animation = new Animation();
        _animation.AddFrames(AnimationUtility.GetFramesFromTexture(96, 32, 32, 6));
    }
    protected override void OnActivate()
    {
        
    }

    protected override void OnDeactivate()
    {
        _animation.Reset();
    }

    public override void OnUpdate(GameTime time)
    {
        if (_animation.Counter == _animation.Frames.Count - 1)
        {
            _controller.GotoNoState();
            return;
        }
        
        _animation.Update(time);
    }

    public override void OnDraw(SpriteBatch batch)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            batch.Draw(_controller.SpriteSheet, _controller.Game.Character.DestinationCharacterRectangle, _animation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
        }
        else
        {
            batch.Draw(_controller.SpriteSheet, _controller.Game.Character.DestinationCharacterRectangle, _animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}