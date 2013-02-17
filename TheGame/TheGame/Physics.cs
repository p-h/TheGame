namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// PhysicsComponent is used to give an entity the ability to collide
  /// </summary>
  public class Physics : IPositionableComponent, ICollidableComponent
  {
    /// <summary>
    /// Position of this PhysicsComponent
    /// </summary>
    private Vector2 position;

    /// <summary>
    /// Width of this PhysicsComponent
    /// </summary>
    private int width;

    /// <summary>
    /// Height of this PhysicsComponent
    /// </summary>
    private int height;

    /// <summary>
    /// Initializes a new instance of the <see cref="Physics"/> class
    /// </summary>
    /// <param name="position">The initial position of this PhysicsComponent</param>
    /// <param name="width">The Width of this PhysicsComponent</param>
    /// <param name="height">The Height of this PhysicsComponent</param>
    public Physics(Vector2 position, int width, int height)
    {
      this.position = position;
      this.width = width;
      this.height = height;
    }

    /// <inheritdoc/>
    public Vector2 Position
    {
      get { return this.position; }
    }

    /// <inheritdoc/>
    public Rectangle Bounds
    {
      get { return new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height); }
    }

    /// <inheritdoc/>
    public bool Colliding { get; set; }
  }
}
