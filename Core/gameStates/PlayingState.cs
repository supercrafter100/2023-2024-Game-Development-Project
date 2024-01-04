using GameDevProject.utility.statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.gameStates;

public class PlayingState : GameState
{
    private GameManager _manager;

    public PlayingState(GameManager manager)
    {
        _manager = manager;
    }
    
    protected override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnDeactivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate(GameTime time)
    {

    }

    public override void OnDraw(SpriteBatch batch)
    {
        _manager.MapManager.RenderTiles(batch);
    }
}