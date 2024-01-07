using System.Linq;
using GameDevProject.Core;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map.tiles;

public class TileFactory
{
    private GameManager _game;
    private Texture2D _tileMapTexture;
    private TileMap _tileMap;
    
    public TileMap.Tiles[] TransparentTiles = new[]
    {
        TileMap.Tiles.SMALL_PLANT, TileMap.Tiles.SMALL_ROCKS, TileMap.Tiles.SIGN_ARROW_UP, TileMap.Tiles.SIGN_ARROW_LEFT, TileMap.Tiles.SIGN_ARROW_RIGHT,
        TileMap.Tiles.ENDING_GLOBE, TileMap.Tiles.PURPLE_SMALL_TRUNK, TileMap.Tiles.PURPLE_GRAVESTONE
    };

    public TileFactory(GameManager game)
    {
        _game = game;
        _tileMapTexture = _game.RootGame.Content.Load<Texture2D>("tilemap");
        _tileMap = new TileMap(_tileMapTexture);
    }
    
    public Tile CreateTile(TileMap.Tiles type, int x, int y)
    {
        if (type == TileMap.Tiles.ENDING_GLOBE)
            return new EndingTile(x, y, _game.MapManager.TileWidth, _game.MapManager.TileHeight, _tileMapTexture, _tileMap.GetSubRectangleForTile(type));

        return new Tile(x, y, _game.MapManager.TileWidth, _game.MapManager.TileHeight, _tileMapTexture, _tileMap.GetSubRectangleForTile(type), TransparentTiles.Contains(type));
    }
}