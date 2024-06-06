using System;
using Apedaile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class MainMenu : GameState
{
    private enum selections
    {
        NewGame,
        Settings,
        Exit
    }

    private SpriteFont CP_48;
    private MouseInput mouseInput;
    


    public override void LoadContent(ContentManager contentManager)
    {
        CP_48 = contentManager.Load<SpriteFont>("Fonts/CP_48");

        // throw new System.NotImplementedException();
    }
    public override GameStateEnum ProcessInput(GameTime gameTime)
    {
        // throw new System.NotImplementedException();

        return GameStateEnum.MainMenu;
    }
    public override void Render(GameTime gameTime)
    {
        spriteBatch.Begin();

        spriteBatch.DrawString(CP_48, "Hello World", new Vector2(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight/2), Color.White);

        spriteBatch.End();
        // throw new System.NotImplementedException();
    }
    public override void SetupInput(KeyboardInput keyboard, MouseInput mouse)
    {
        mouse.registerCommand("LeftButton", true, PrintHello, GameStateEnum.MainMenu, Actions.select);
        // throw new System.NotImplementedException();
    }
    public override void Update(GameTime gameTime)
    {
        // throw new System.NotImplementedException();
    }

    private void PrintHello(GameTime gameTime, float value) {
        MouseState mouseState = Mouse.GetState();
        System.Console.WriteLine(String.Format("X:{0} Y:{1}", mouseState.X, mouseState.Y));
    }
}