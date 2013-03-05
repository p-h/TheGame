namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// Manages all the entities capable of physics
  /// </summary>
  public class PhysicsSystem : GameComponent
  {
    /// <summary>
    /// The gravity constant of this world
    /// </summary>
    public readonly Vector2 Gravity = new Vector2(0f, 9.81f);

    /// <summary>
    /// The <see cref="EntityManager"/> of this <see cref="PhysicsSystem"/>
    /// </summary>
    private EntityManager entityManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="PhysicsSystem"/> class
    /// </summary>
    /// <param name="game">The <see cref="Game"/></param>
    public PhysicsSystem(Game game)
      : base(game)
    {
      this.entityManager = game.EntityManager;
    }
  }
}
