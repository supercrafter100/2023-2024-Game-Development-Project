using GameDevProject.Core.gameStates;
using GameDevProject.utility.animation;
using GameDevProject.utility.statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.animations.mainCharacter;

public class IdlingState: GameState
{
    private MainCharacterAnimationController _controller;
    private Animation _animation;

    public IdlingState(MainCharacterAnimationController controller)
    {
        _controller = controller;
        _animation = new Animation();
        _animation.AddFrames(AnimationUtility.GetFramesFromTexture(0, 32, 32, 8));
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
        batch.Draw(_controller.SpriteSheet, _controller.Game.Character.DestinationCharacterRectangle, _animation.CurrentFrame.SourceRectangle, Color.White);
    }
}