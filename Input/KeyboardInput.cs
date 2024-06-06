using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Apedaile
{
  public class KeyboardInput : IInputDevice
  {
    private KeyboardState previousState;
    private Dictionary<GameStateEnum, Dictionary<Actions, CommandEntry_K>> stateCommands = new Dictionary<GameStateEnum, Dictionary<Actions, CommandEntry_K>>();


    public Dictionary<GameStateEnum, Dictionary<Actions, CommandEntry_K>> getStateCommands()
    {
      return stateCommands;
    }

    public void registerCommand(Keys key, bool keyPressOnly, IInputDevice.CommandDelegate callback, GameStateEnum state, Actions action)
    {
      if (stateCommands.ContainsKey(state))
      {
        var commandEntries = stateCommands[state];
        Actions remove = Actions.none;
        foreach (var item in commandEntries)
        {
          if (item.Value.callback == callback)
          {
            remove = item.Key;
          }
        }

        commandEntries.Remove(remove);

        if (commandEntries.ContainsKey(action))
        {
          commandEntries.Remove(action);
        }

        commandEntries.Add(action, new CommandEntry_K(key, keyPressOnly, callback, action));
      }
      else
      {
        stateCommands.Add(state, new Dictionary<Actions, CommandEntry_K>());
        stateCommands[state].Add(action, new CommandEntry_K(key, keyPressOnly, callback, action));
      }
    }

    public void Update(GameTime gameTime, GameStateEnum state)
    {
      KeyboardState keyState = Keyboard.GetState();

      if (state == GameStateEnum.Exit)
      {
        return;
      }

      Dictionary<Actions, CommandEntry_K> commandEntries = stateCommands[state];
      foreach (CommandEntry_K entry in commandEntries.Values)
      {
        if (entry.keyPressOnly && keyPressed(entry.key))
        {
          entry.callback(gameTime, 1.0f);
        }
        else if (!entry.keyPressOnly && keyState.IsKeyDown(entry.key))
        {
          entry.callback(gameTime, 1.0f);
        }
        previousState = keyState;
      }
    }

    private bool keyPressed(Keys key)
    {
      return (Keyboard.GetState().IsKeyDown(key) && !previousState.IsKeyDown(key));
    }
  }
}