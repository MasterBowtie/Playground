using System.Data.SqlTypes;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Apedaile
{
  public abstract class GameState : IGameState 
  {
    protected GraphicsDeviceManager graphics;
    protected SpriteBatch spriteBatch;
    protected KeyboardInput keyboard;

    public void Initialize(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
    {
      this.graphics = graphics;
      this.spriteBatch = new SpriteBatch(graphicsDevice);
    }

    public abstract void SetupInput(KeyboardInput keyboard);
    public abstract void LoadContent(ContentManager contentManager);
    public abstract GameStateEnum ProcessInput(GameTime gameTime);
    public abstract void Render(GameTime gameTime);
    public abstract void Update(GameTime gameTime);
  }
}