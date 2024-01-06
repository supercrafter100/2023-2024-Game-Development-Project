using System;
using GameDevProject.UI;
using GameDevProject.utility.statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.gameStates;

public class DeathState : GameState
{
    private DeathScreen _screen;
    private GameManager _game;

    public DeathState(GameManager game)
    {
        _game = game;
        _screen = new DeathScreen(_game);
    }
    
    protected override void OnActivate()
    {

    }

    protected override void OnDeactivate()
    {
        
    }
    
    public override void OnUpdate(GameTime time)
    {
        _screen.Update(time);
    }

    public override void OnDraw(SpriteBatch batch)
    {
        _screen.Draw(batch);
    }
}