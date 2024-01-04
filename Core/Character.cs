using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core;

public class Character : IGameObject
{
    private Texture2D _texture;
    private Rectangle _segmentRectangle;
    private int _horizontalOffset = 0;

    public Character(Texture2D texture)
    {
        _texture = texture;
        _segmentRectangle = new Rectangle(_horizontalOffset, 0, 180, 247);
    }
    
    public void Update(GameTime time)
    {
        _horizontalOffset += 180;
        if (_horizontalOffset > 720)
        {
            _horizontalOffset = 0;          
        }
        _segmentRectangle.X = _horizontalOffset;

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, new Vector2(0, 0), _segmentRectangle, Color.White);
    }
}