using System;
using GameDevProject.Core;
using GameDevProject.Core.gameStates;
using GameDevProject.UI.elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.UI;

public class StartScreen : IGameObject
{
    private GameManager _game;
    private SpriteFont _font;

    private Texture2D _plainTexture;
    
    private Text _titleText;
    private Button _startbutton;
    
    
    
    public StartScreen(GameManager game)
    {
        _game = game;
        _plainTexture = new Texture2D(_game.RootGame.GraphicsDevice, 1, 1);
        _plainTexture.SetData(new[] { Color.White });

        _font = _game.RootGame.Content.Load<SpriteFont>("font");
        
        // UI element initialization
        Vector2 titleTextPosition = new Vector2(_game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / 2,
            _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / 4);
        _titleText = new Text("Game Development Project", titleTextPosition, _font, 5);

        Vector2 startButtonPosition = new Vector2(_game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth / 2,
            _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
        _startbutton = new Button("Start", startButtonPosition, _font, _plainTexture, () =>
        {
            _game.GoToState<PlayingState>();
        },5);
    }
    
    public void Update(GameTime time)
    {
        _startbutton.Update(time);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw background
        spriteBatch.Draw(_plainTexture, new Rectangle(0, 0, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferWidth, _game.RootGame.GraphicsDeviceManager.PreferredBackBufferHeight), Color.Black);

        // UI elements
        _titleText.Draw(spriteBatch);
        _startbutton.Draw(spriteBatch);
    }   
}