using GameDevProject.utility.animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core;

public class Character : IGameObject
{
    private Texture2D _texture;
    private Animation _animation;

    public Character(Texture2D texture)
    {
        _texture = texture;
        _animation = new Animation();
        
        _animation.AddFrames(AnimationUtility.GetFramesFromTextureProperties(_texture.Width, _texture.Height, 5, 2));
    }
    
    public void Update(GameTime time)
    {
        _animation.Update(time);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, new Vector2(0, 0), _animation.CurrentFrame.SourceRectangle, Color.White);
    }
}