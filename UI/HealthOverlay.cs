using GameDevProject.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.UI;

public class HealthOverlay
{
    private int _distanceBetweenHearts = 50;
    private Vector2 _location = new Vector2(20, 20);
    private int _size = 40;
    private Texture2D _texture;
    private Character _character;
    
    public HealthOverlay(Character character)
    {
        _character = character;
        _texture = _character._game.RootGame.Content.Load<Texture2D>("heart");
    }

    public void Draw(SpriteBatch batch)
    {
        for (int x = 0; x < _character.Lives; x++)
        {
            batch.Draw(_texture, new Rectangle((int)(_location.X + (_distanceBetweenHearts * x)), (int)_location.Y, _size, _size), Color.White);
        }
    }
}