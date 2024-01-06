using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map;

public class TileMap
{
    private readonly int _tileWidth = 32;
    private readonly int _tileHeight = 32;
    
    private readonly int _rows;
    private readonly int _cols;
    
    public Texture2D TileTexture;
    
    public enum Tiles
    {
        SMALL_PLANT = 0,
        FLOATING_GRASS_ALONE = 1,
        SMALL_ROCKS = 2,
        ENDING_GLOBE = 3,
        SIGN_ARROW_RIGHT = 4,
        SIGN_ARROW_LEFT = 5,
        SIGN_ARROW_UP = 6,
        SMALL_FLOWER = 7,
        GRASS_TOP_LEFT = 16,
        GRASS_TOP_CENTER = 17,
        GRASS_TOP_RIGHT = 18,
        GRASS_TOP_ALONE = 19,
        GRASS_TOP_FLOATING_LEFT = 20,
        GRASS_TOP_FLOATING_CENTER = 21,
        GRASS_TOP_FLOATING_RIGHT = 22,
        DIRT_MIDDLE_LEFT = 32,
        DIRT_MIDDLE_CENTER = 33,
        DIRT_MIDDLE_RIGHT = 34,
        DIRT_MIDDLE_FLOATING_CENTER = 35,
        DIRT_BOTTOM_LEFT = 48,
        DIRT_BOTTOM_CENTER = 49,
        DIRT_BOTTOM_RIGHT = 50,
        DIRT_BOTTOM_FLOATING_CENTER = 51,
    }

    public TileMap(Texture2D texture)
    {
        TileTexture = texture;
        
        // Calculate how many rows and columns we have
        _rows = texture.Width / _tileWidth;
        _cols = texture.Height / _tileHeight;
    }

    public Rectangle GetSubRectangleForTile(int index)
    {
        return GetSubRectangleForTile((Tiles)index);
    }

    public Rectangle GetSubRectangleForTile(Tiles tile)
    {
        int x = (int)tile % _cols;
        int y = (int)tile / _rows;

        return new Rectangle(x * _tileWidth, y * _tileHeight, _tileWidth,
             _tileHeight);
    }
}