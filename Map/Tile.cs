using System;
using GameDevProject.utility.collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map;

public class Tile: ICollidable
{
    private int _x;
    private int _y;
    private int _w;
    private int _h;
    private Color _color;
    private Texture2D _texture;
    
    public Rectangle HitBox { get; set; }

    public Tile(int x, int y, int width, int height, Color color, GraphicsDevice graphics)
    {
        _x = x;
        _y = y;
        _w = width;
        _h = height;
        _color = color;
        _texture = new Texture2D(graphics, 1, 1);
        _texture.SetData(new[] { _color });
        HitBox = new Rectangle(_x, _y, _w, _h);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, new Rectangle(_x, _y, _w, _h), Color.Yellow);
    }
}