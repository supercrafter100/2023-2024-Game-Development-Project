﻿using GameDevProject.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map.levels;

public class Level1 : ILevel
{
    private GameManager _game;
    
    public TileMap.Tiles?[,] GameMap { get; set; } = 
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

    public Vector2 SpawnLocation { get; set; } = new(1, 1);
    public IGameObject[] Enemies { get; set; } = { };
    public Texture2D Background { get; set; }

    public Level1(GameManager game)
    {
        _game = game;
        Background = _game.RootGame.Content.Load<Texture2D>("background");
    }
    
    public void Update(GameTime time)
    {
        throw new System.NotImplementedException();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        throw new System.NotImplementedException();
    }
}