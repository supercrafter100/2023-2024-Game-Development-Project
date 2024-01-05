using System;
using System.Collections.Generic;
using System.Linq;
using GameDevProject.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map;

public class MapManager
{
    private GraphicsDevice _graphics;
    private GameManager _game;
    private TileMap _tileMap;
    
    private int _horizontalTiles = 29;
    private int _verticalTiles = 21;

    public int TileWidth = 32;
    public int TileHeight = 32;

    private List<Tile> _tiles = new();
    
    TileMap.Tiles?[,] gameboard = 
    {
        { null, null, null, null, TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_PLANT, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
        { null, null, TileMap.Tiles.GRASS_TOP_FLOATING_LEFT, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_RIGHT, null, null, TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_ROCKS, null, null, null, null, null, null, TileMap.Tiles.SMALL_ROCKS, null, null, TileMap.Tiles.SMALL_PLANT, null, null, TileMap.Tiles.SMALL_ROCKS, null },
        { null, null, null, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_RIGHT, null, null, TileMap.Tiles.GRASS_TOP_FLOATING_LEFT, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_RIGHT, null, TileMap.Tiles.GRASS_TOP_FLOATING_LEFT, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_RIGHT, null, TileMap.Tiles.FLOATING_GRASS_ALONE, null, TileMap.Tiles.GRASS_TOP_LEFT, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_RIGHT, null },
        { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_BOTTOM_RIGHT, null },
        { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_RIGHT, null, null },
        { TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_ROCKS, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
        { TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_RIGHT, null, null, null, null, null, null, null, null, null, null, null, TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_PLANT, null, null, null, null, null, null, null, null, null, null, null, null, null },
        { TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_PLANT, null, null, null, null, null, null, null, null, TileMap.Tiles.GRASS_TOP_LEFT, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_RIGHT, null, null, null, null, null, null,  null, null, null, null, null, null },
        { TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_RIGHT, null, null, TileMap.Tiles.GRASS_TOP_LEFT, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, null, TileMap.Tiles.GRASS_TOP_LEFT, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_RIGHT, null, null, null },
        { TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_RIGHT, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_RIGHT, null },
        { TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_MIDDLE_CENTER, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, null, null, null, null, null, null, null, null, null, null },
        { TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_RIGHT, null, null, null, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_BOTTOM_RIGHT, null, null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, null, null, null, TileMap.Tiles.SMALL_ROCKS, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER },
        { null, TileMap.Tiles.SMALL_ROCKS, TileMap.Tiles.SMALL_ROCKS, null, null, null, null, null, null, null, null, null, null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_FLOATING_CENTER, null, null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_FLOATING_CENTER, null, null, null, null },
        { TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_RIGHT, null, null, null, null, null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_FLOATING_CENTER, null, null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_FLOATING_CENTER, null, null, null, null },
        { null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, null, null, null, null, null, null, null, null, TileMap.Tiles.DIRT_BOTTOM_FLOATING_CENTER, null, null, null, null, null, null, TileMap.Tiles.DIRT_BOTTOM_FLOATING_CENTER, null, null, TileMap.Tiles.SMALL_ROCKS, null },
        { null, TileMap.Tiles.SMALL_PLANT, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, TileMap.Tiles.GRASS_TOP_FLOATING_LEFT, TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_RIGHT, null, null, null, null, null, TileMap.Tiles.GRASS_TOP_LEFT, TileMap.Tiles.GRASS_TOP_RIGHT, null, null, null, null, null, TileMap.Tiles.GRASS_TOP_LEFT, TileMap.Tiles.GRASS_TOP_RIGHT },
        { TileMap.Tiles.GRASS_TOP_FLOATING_CENTER, TileMap.Tiles.GRASS_TOP_FLOATING_RIGHT, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_CENTER, TileMap.Tiles.DIRT_BOTTOM_RIGHT, null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT },
        { null, null, null, null, null, TileMap.Tiles.DIRT_BOTTOM_LEFT, TileMap.Tiles.DIRT_BOTTOM_RIGHT, null, null, null, null, null, null, null, null, null, null, null, TileMap.Tiles.GRASS_TOP_LEFT, TileMap.Tiles.GRASS_TOP_RIGHT, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null,  null, TileMap.Tiles.GRASS_TOP_LEFT, TileMap.Tiles.GRASS_TOP_RIGHT, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT },
        { TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SIGN_ARROW_RIGHT, TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_PLANT, null, null, null, null, null, null, null, null, null, TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_PLANT, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, null, null, null, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT, TileMap.Tiles.DIRT_MIDDLE_LEFT, TileMap.Tiles.DIRT_MIDDLE_RIGHT },
        { TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER, TileMap.Tiles.GRASS_TOP_CENTER },
    };
    
    public MapManager(GameManager game)
    {
        _game = game;
        _tileMap = new TileMap(_game.RootGame.Content.Load<Texture2D>("tilemap"));

        TileWidth = _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / _horizontalTiles;
        TileHeight = _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / _verticalTiles;
    }

    public void CreateLevelMap()
    {
        for (int y = 0; y < _verticalTiles; y++)
        {
            for (int x = 0; x < _horizontalTiles; x++)
            {
                int xOffset = x * TileWidth;
                int yOffset = y * TileHeight;

                TileMap.Tiles? tile = gameboard[y, x];
                if (tile.HasValue)
                {
                    _tiles.Add(new Tile(xOffset, yOffset, TileWidth, TileHeight, _tileMap.TileTexture, _tileMap.GetSubRectangleForTile(tile.Value), _tileMap.TransparentTiles.Contains(tile.Value)));
                }
            }
        }
    }

    public void RenderMap(SpriteBatch batch)
    {
        
        // Background
        Texture2D background = _game.RootGame.Content.Load<Texture2D>("background");
        batch.Draw(background, new Rectangle(0, 0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight), Color.White);
        
        // Tiles
        foreach (var tile in _tiles)
        {
            tile.Draw(batch);
        }
    }

    #nullable enable
    public Tile? CollidesWithTerrain(Rectangle hitbox)
    {
        return _tiles.Find(tile => tile.HitBox.Intersects(hitbox));
    }
}