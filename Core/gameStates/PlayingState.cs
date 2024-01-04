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
        
    }

    protected override void OnDeactivate()
    {
        
    }

    public override void OnUpdate(GameTime time)
    {
        _manager.Character.Update(time);
    }

    public override void OnDraw(SpriteBatch batch)
    {
        _manager.MapManager.RenderTiles(batch);
        _manager.Character.Draw(batch);
    }
}