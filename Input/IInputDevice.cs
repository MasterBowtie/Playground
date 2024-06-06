using Microsoft.Xna.Framework;

namespace Apedaile
{
  public interface IInputDevice
  {
    public delegate void CommandDelegate(GameTime gameTime, float value);
    public delegate void CommandDelegatePosition(GameTime gameTime, int x, int y);

    void Update(GameTime gameTime);
  }
}