﻿using GameDevProject.Core.enemies;
using GameDevProject.Core.gameStates;
using GameDevProject.utility;
using GameDevProject.utility.animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.animations.enemy1;

public class HurtState : GameState
{
    private Enemy _controller;
    private Animation _animation;

    public HurtState(Enemy controller)
    {
        _controller = controller;
        _animation = new Animation();
        _animation.AddFrames(AnimationUtility.GetFramesFromTexture(96, 64, 32, 4));
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
        if (_controller.Direction == Direction.Left)
        {
            batch.Draw(_controller.Texture, _controller.DestinationCharacterRectangle, _animation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
        }
        else
        {
            batch.Draw(_controller.Texture, _controller.DestinationCharacterRectangle, _animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}