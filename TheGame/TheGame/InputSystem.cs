namespace TheGame
{
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
    /// The <see cref="EntityManager"/> if this <see cref="InputSystem"/>
    /// </summary>
    private EntityManager entityManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="InputSystem"/> class
    /// </summary>
    /// <param name="game">The game that this component should be attached to</param>
    public InputSystem(Game game)
      : base(game)
    {
      this.entityManager = game.EntityManager;
    }

    /// <summary>
    /// Gets input and dispatches it to the controllable entities
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public override void Update(GameTime gameTime)
    {
      this.keyboardState = Keyboard.GetState();

      var entities = this.entityManager.GetEntitiesWhere(e => e.Movement.HasValue);

      foreach (var entity in entities)
      {
        var movement = Vector2.Zero;

        if (this.keyboardState.IsKeyDown(Keys.W))
        {
          movement.Y = -1f;
        }

        if (this.keyboardState.IsKeyDown(Keys.A))
        {
          movement.X = -1f;
        }

        if (this.keyboardState.IsKeyDown(Keys.S))
        {
          movement.Y = 1f;
        }

        if (this.keyboardState.IsKeyDown(Keys.D))
        {
          movement.X = 1f;
        }

        entity.Movement = movement;
      }

      base.Update(gameTime);
    }
  }
}
