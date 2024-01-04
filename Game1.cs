using GameDevProject.Core;
using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject;

public class Game1 : Game
{
    public GraphicsDeviceManager GraphicsDeviceManager;
    private SpriteBatch _spriteBatch;

    private GameManager _gameManager;

    public Game1()
    {
        GraphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _gameManager = new GameManager(this);
        _gameManager.Activate();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _gameManager.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        // Draw sprites
        _spriteBatch.Begin();
        _gameManager.Draw(_spriteBatch);
        _spriteBatch.End();
        // End draw sprites
        
        base.Draw(gameTime);
    }
}
