using System;
using GameDevProject.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.UI.elements;

public class Text : IGameObject
{
    private String _text;
    private Vector2 _location;
    private SpriteFont _font;
    private float _scale;

    public Text(String text, Vector2 position, SpriteFont font, float scale = 1)
    {
        _text = text;
        _location = position;
        _font = font;
        _scale = scale;
    }
    
    public void Update(GameTime time)
    {
        // Not used
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Vector2 textMiddlePoint = _font.MeasureString(_text) / 2;
        spriteBatch.DrawString(_font, _text, _location, Color.White, 0, textMiddlePoint, _scale, SpriteEffects.None, 0.5f);
    }
}