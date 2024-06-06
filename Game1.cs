using System.Collections.Generic;
using Apedaile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Playground;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Dictionary<GameStateEnum, GameState> states;
    private GameState currentState;
    private KeyboardInput keyboard;
    private MouseInput mouse;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {

        graphics.PreferredBackBufferWidth = 1920;
        graphics.PreferredBackBufferHeight = 1080;
        graphics.ApplyChanges();
        // TODO: Add your initialization logic here

        keyboard = new KeyboardInput();
        mouse = new MouseInput();
        states = new Dictionary<GameStateEnum, GameState> {
            {GameStateEnum.MainMenu, new MainMenu()}
        };

        foreach (var item in states)
        {
            item.Value.Initialize(this.GraphicsDevice, graphics);
        }


        states[GameStateEnum.MainMenu].SetupInput(keyboard, mouse);

        currentState = states[GameStateEnum.MainMenu];
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        foreach (var item in states)
        {
            item.Value.LoadContent(this.Content);
        }

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        GameStateEnum nextState = currentState.ProcessInput(gameTime);
        mouse.Update(gameTime, nextState);
        keyboard.Update(gameTime, nextState);

        if (nextState == GameStateEnum.Exit) {
            Exit();
        } else {
            currentState.Update(gameTime);
            currentState = states[nextState];
        }

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        currentState.Render(gameTime);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
