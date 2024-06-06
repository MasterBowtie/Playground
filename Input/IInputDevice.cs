using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Apedaile
{
  public interface IInputDevice
  {
    public delegate void CommandDelegate(GameTime gameTime, float value);
    public delegate void CommandDelegatePosition(GameTime gameTime, int x, int y);

    void Update(GameTime gameTime, GameStateEnum state);
  }

  public struct CommandEntry_K
  {
    public Keys key;
    public bool keyPressOnly;
    public IInputDevice.CommandDelegate callback;
    public Actions action;

    public CommandEntry_K(Keys key, bool keyPressOnly, IInputDevice.CommandDelegate callback, Actions action)
    {
      this.key = key;
      this.keyPressOnly = keyPressOnly;
      this.callback = callback;
      this.action = action;
    }
  }

  public struct CommandEntry_M
  {
    public string button;
    public bool pressOnly;
    public IInputDevice.CommandDelegate callback;
    public Actions action;

    public CommandEntry_M(string button, bool pressOnly, IInputDevice.CommandDelegate callback, Actions action)
    {
      this.button = button;
      this.pressOnly = pressOnly;
      this.action = action;
      this.callback = callback;
    }
  }
}