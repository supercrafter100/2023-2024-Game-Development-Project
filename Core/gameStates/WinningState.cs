﻿using GameDevProject.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core.gameStates;

public class WinningState : GameState
{
    private WinScreen _screen;
    private GameManager _game;

    public WinningState(GameManager game)
    {
        _game = game;
        _screen = new WinScreen(_game);
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