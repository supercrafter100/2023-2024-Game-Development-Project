using GameDevProject.Core.enemies;
using GameDevProject.Core.gameStates;
using GameDevProject.utility;
using GameDevProject.utility.animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.animations.enemy3;

public class DeathState : GameState
{
    private Enemy _controller;
    private Animation _animation;
    private bool _animationEnded = false;

    public DeathState(Enemy controller)
    {
        _controller = controller;
        _animation = new Animation();
        _animation.AddFrames(AnimationUtility.GetFramesFromTexture(96, 32, 32, 3));
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
        if (_animationEnded) return;
        
        if (_animation.Counter == _animation.Frames.Count - 1)
        {
            _animationEnded = true;
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