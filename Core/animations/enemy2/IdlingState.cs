using GameDevProject.Core.enemies;
using GameDevProject.Core.gameStates;
using GameDevProject.utility.animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.animations.enemy2;

public class IdlingState: GameState
{
    private Enemy _controller;
    private Animation _animation;

    public IdlingState(Enemy controller)
    {
        _controller = controller;
        _animation = new Animation();
        _animation.AddFrames(AnimationUtility.GetFramesFromTexture(0, 32, 32, 4));
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
        _animation.Update(time);
    }

    public override void OnDraw(SpriteBatch batch)
    {
        batch.Draw(_controller.Texture, _controller.DestinationCharacterRectangle, _animation.CurrentFrame.SourceRectangle, Color.White);
    }
}