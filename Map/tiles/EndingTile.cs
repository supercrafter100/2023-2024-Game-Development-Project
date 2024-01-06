using GameDevProject.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map.tiles;

public class EndingTile : Tile, IGameObject
{
    public EndingTile(int x, int y, int width, int height, Texture2D texture, Rectangle offsetRectangle) : base(x, y, width, height, texture, offsetRectangle, true)
    {
        
    }
    
    public void Update(GameTime time)
    {
        
    }
}