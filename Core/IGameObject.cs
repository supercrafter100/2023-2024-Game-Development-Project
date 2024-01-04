using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core;

public interface IGameObject
{
    void Update(GameTime time);
    void Draw(SpriteBatch spriteBatch);
}