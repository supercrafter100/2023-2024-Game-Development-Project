using GameDevProject.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map.levels;

public interface ILevel : IGameObject
{
    public TileMap.Tiles?[,] GameMap { get; set; }
    public Vector2 SpawnLocation { get; set; }
    public IGameObject[] Enemies { get; set; }
    public Texture2D Background { get; set; }
}