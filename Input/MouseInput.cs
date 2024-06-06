using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Apedaile
{
  public class MouseInput: IInputDevice
  {
    private MouseState previousState;

    private Dictionary<GameStateEnum, Dictionary<Actions, CommandEntry_M>> stateCommands = new Dictionary<GameStateEnum, Dictionary<Actions, CommandEntry_M>>();

    public void registerCommand(string button, bool pressOnly, IInputDevice.CommandDelegate callback, GameStateEnum state, Actions action)
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
        commandEntries.Add(action, new CommandEntry_M(button, pressOnly, callback, action));
      }
      else 
      {
        stateCommands.Add(state, new Dictionary<Actions, CommandEntry_M>());
        stateCommands[state].Add(action, new CommandEntry_M(button, pressOnly, callback, action));
      }
    }

    public void Update(GameTime gameTime, GameStateEnum state)
    {
      MouseState mouseState = Mouse.GetState();

      if (stateCommands.ContainsKey(state))
      {

        Dictionary<Actions, CommandEntry_M> commandEntries = stateCommands[state];
        foreach (CommandEntry_M entry in commandEntries.Values)
        {
          if (entry.pressOnly && buttonPressed(entry.button))
          {
            entry.callback(gameTime, 1.0f);
          }
          else if (!entry.pressOnly && buttonState(mouseState, entry.button))
          {
            entry.callback(gameTime, 1.0f);
          }
        }
      }

      previousState = mouseState;
    }

    private bool buttonState(MouseState state, string button) {
      if (button == "LeftButton")
      {
        return state.LeftButton == ButtonState.Pressed;
      }
      if (button == "RightButton")
      {
        return state.RightButton == ButtonState.Pressed;
      }
      if (button == "MiddleButton")
      {
        return state.MiddleButton == ButtonState.Pressed;
      }
      if (button == "XButton1")
      {
        return state.XButton1 == ButtonState.Pressed;
      }
      if (button == "XButton2")
      {
        return state.XButton2 == ButtonState.Pressed;
      }
      return false;
    }

    private bool buttonPressed(string button) 
    {
      MouseState mouseState = Mouse.GetState();
      return buttonState(mouseState, button) && !buttonState(previousState, button);
    }
  }
}