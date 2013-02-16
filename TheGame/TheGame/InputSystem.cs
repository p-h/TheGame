namespace TheGame
{
  using System;
  using System.Collections.Generic;
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Input;

  /// <summary>
  /// This class handles all the input of the game
  /// </summary>
  public class InputSystem : GameComponent
  {
    /// <summary>
    /// The current state of the keyboard
    /// </summary>
    private KeyboardState keyboardState;

    /// <summary>
    /// Gets all the <see cref="IControllableComponent"/>
    /// </summary>
    private Func<IEnumerable<IControllableComponent>> getter;

    /// <summary>
    /// Initializes a new instance of the <see cref="InputSystem"/> class
    /// </summary>
    /// <param name="game">The game that this component should be attached to</param>
    public InputSystem(Game game)
      : base(game)
    {
      this.getter = game.EntityManager.GetComponents<IControllableComponent>;
    }

    /// <summary>
    /// Gets input and dispatches it to the controllable components
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public override void Update(GameTime gameTime)
    {
      var controllables = this.getter();
      this.keyboardState = Keyboard.GetState();

      foreach (var controllable in controllables)
      {
        var movement = Point.Zero;

        if (this.keyboardState.IsKeyDown(Keys.W))
        {
          movement.Y = 1;
        }

        if (this.keyboardState.IsKeyDown(Keys.S))
        {
          movement.Y = -1;
        }

        if (this.keyboardState.IsKeyDown(Keys.A))
        {
          movement.X = -1;
        }

        if (this.keyboardState.IsKeyDown(Keys.D))
        {
          movement.X = 1;
        }

        controllable.Movement = movement;
      }

      base.Update(gameTime);
    }
  }
}
