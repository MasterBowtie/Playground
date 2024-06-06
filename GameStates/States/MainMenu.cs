using Apedaile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

class MainMenu : GameState
{
    private enum selections
    {
        NewGame,
        Settings,
        Exit
    }

    private SpriteFont CP_24;
    


    public override void LoadContent(ContentManager contentManager)
    {
        CP_24 = contentManager.Load<SpriteFont>("Fonts/CP_24");

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

        spriteBatch.DrawString(CP_24, "Hello World", new Vector2(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight/2), Color.White);

        spriteBatch.End();
        // throw new System.NotImplementedException();
    }
    public override void SetupInput(KeyboardInput keyboard)
    {
        // throw new System.NotImplementedException();
    }
    public override void Update(GameTime gameTime)
    {
        // throw new System.NotImplementedException();
    }
}