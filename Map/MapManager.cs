using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map;

public class MapManager
{
    private GraphicsDevice _graphics;
    
    private int _horizontalTiles = 8;
    private int _verticalTiles = 8;

    private int _tileWidth;
    private int _tileHeight;

    private List<Tile> _tiles = new();
    
    int[,] gameboard = new int[,]
    {
        { 1,1,1,1,1,1,1,1 },
        { 0,0,1,1,0,1,1,1 },
        { 1,0,0,0,0,0,0,1 },
        { 1,1,1,1,1,1,0,1 },
        { 1,0,0,0,0,0,0,2 },
        { 1,0,1,1,1,1,1,2 },
        { 1,0,0,0,0,0,0,0 },
        { 1,1,1,1,1,1,1,1 }
    };
    
    public MapManager(GraphicsDevice graphics, GraphicsDeviceManager deviceManager)
    {
        _graphics = graphics;


        _tileWidth = deviceManager.PreferredBackBufferWidth / _horizontalTiles;
        _tileHeight = deviceManager.PreferredBackBufferHeight / _verticalTiles;
        
        CreateLevelMap();
    }

    private void CreateLevelMap()
    {
        for (int y = 0; y < _verticalTiles; y++)
        {
            for (int x = 0; x < _horizontalTiles; x++)
            {
                int xOffset = x * _tileWidth;
                int yOffset = y * _tileHeight;

                if (gameboard[y, x] == 1)
                {
                    _tiles.Add(new Tile(xOffset, yOffset, _tileWidth, _tileHeight, Color.Yellow, _graphics));
                }
            }
        }
    }

    public void RenderTiles(SpriteBatch batch)
    {
        foreach (var tile in _tiles)
        {
            tile.Draw(batch);
        }
    }
}