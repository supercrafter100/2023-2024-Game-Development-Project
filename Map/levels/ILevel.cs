using System.Collections.Generic;
using GameDevProject.Core;
using GameDevProject.Core.enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map.levels;

public interface ILevel
{
    public TileMap.Tiles?[,] GameMap { get; set; }
    public Vector2 SpawnLocation { get; set; }
    public List<Enemy> Enemies { get; set; }
    public Texture2D Background { get; set; }
}