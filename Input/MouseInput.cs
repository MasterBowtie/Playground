using System;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Apedaile
{
  public class MouseInput: IInputDevice
  {
    private MouseState previousState;


    public void Update(GameTime gameTime)
    {
      MouseState mouseState = Mouse.GetState();
      System.Console.WriteLine(mouseState);
    }
    private bool keyPressed(Keys key) 
    {
      //TODO:
      return (false);
    }
  }
}