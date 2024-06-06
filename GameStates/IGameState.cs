using System.Data.SqlTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Apedaile
{
  public interface IGameState 
  {
    void Initialize(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics);

    void LoadContent(ContentManager contentManager);

    // void SetupInput(Storage storage, KeyboardInput keyboard);

    GameStateEnum ProcessInput(GameTime gameTime);

    void Update(GameTime gameTime);

    void Render(GameTime gameTime);
  }
}