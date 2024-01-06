using System;
using System.Collections.Generic;
using System.Linq;
using GameDevProject.Core;
using GameDevProject.Core.gameStates;
using GameDevProject.Map.levels;
using GameDevProject.Map.tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map;

public class MapManager
{
    private readonly GraphicsDevice _graphics;
    private readonly GameManager _game;
    
    private readonly int _horizontalTiles = 29;
    private readonly int _verticalTiles = 21;

    public readonly int TileWidth = 32;
    public readonly int TileHeight = 32;

    private readonly List<Tile> _tiles = new();
    private readonly TileFactory _tileFactory;

    private readonly List<ILevel> _levels = new();
    public ILevel ActiveLevel;
    
    public MapManager(GameManager game)
    {
        _game = game;
        _tileFactory = new TileFactory(_game);

        TileWidth = _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / _horizontalTiles;
        TileHeight = _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / _verticalTiles;
        
        // Registering levels
        _levels.Add(new Level1(_game));

        // Setting active level
        ActiveLevel = _levels[0];
    }

    public void CreateLevelMap()
    {
        // Clear existing tiles
        _tiles.Clear();
        
        // Generate tile map
        for (int y = 0; y < _verticalTiles; y++)
        {
            for (int x = 0; x < _horizontalTiles; x++)
            {
                int xOffset = x * TileWidth;
                int yOffset = y * TileHeight;

                TileMap.Tiles? tile = ActiveLevel.GameMap[y, x];
                if (tile.HasValue)
                {
                    _tiles.Add(_tileFactory.CreateTile(tile.Value, xOffset, yOffset));
                }
            }
        }
    }

    public void RenderMap(SpriteBatch batch)
    {
        
        // Background
        batch.Draw(ActiveLevel.Background, new Rectangle(0, 0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight), Color.White);
        
        // Tiles
        foreach (var tile in _tiles)
        {
            tile.Draw(batch);
        }
    }

    #nullable enable
    public Tile? CollidesWithTerrain(Rectangle hitbox)
    {
        return _tiles.Find(tile => !tile.IsTransparent && tile.HitBox.Intersects(hitbox));
    }

    public List<Tile> FindAllCollissionsWithMap(Rectangle hitbox)
    {
        return _tiles.FindAll(tile => tile.HitBox.Intersects(hitbox));
    }

    public void GoToNextLevel()
    {
        int currentIndex = _levels.IndexOf(ActiveLevel);
        ILevel? nextLevel = _levels[currentIndex + 1];

        if (nextLevel == null)
        {
            _game.GoToState<WinningState>();
            return;
        }

        ActiveLevel = nextLevel;
        CreateLevelMap(); // Render map tiles again
    }
}