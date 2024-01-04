using GameDevProject.Core.gameStates;
using GameDevProject.Map;
using GameDevProject.utility.statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Core;

public class GameManager : StateMachine, IGameObject
{
    public Game1 RootGame;
    public MapManager MapManager;
    public Character Character;

    public GameManager(Game1 game)
    {
        RootGame = game;
        MapManager = new MapManager(RootGame.GraphicsDevice, RootGame.GraphicsDeviceManager);
        
        AddState(new MainMenuState());
        AddState(new PlayingState(this));
        AddState(new DeathState());
    }


    protected override void OnActivate()
    {
        // Go to the main menu
        GoToState<MainMenuState>();
        
        // Load in the maps
        MapManager.CreateLevelMap();
    }

    protected override void OnDeactivate()
    {
        GotoNoState(true);
    }

    protected override void OnNoState()
    {
        GoToState<MainMenuState>();
    }

    public void Update(GameTime time)
    {
        ActiveState?.OnUpdate(time);
    }

    public void Draw(SpriteBatch batch)
    {
        if (ActiveState is GameState state) state.OnDraw(batch);
    }
}