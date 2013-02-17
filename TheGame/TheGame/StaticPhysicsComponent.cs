namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// A not Movable <see cref="ICollidableComponent"/> component
  /// </summary>
  public class StaticPhysicsComponent : ICollidableComponent, IPositionableComponent
  {
    /// <summary>
    /// the position if this <see cref="StaticPhysicsComponent"/>
    /// </summary>
    private Vector2 position;

    /// <summary>
    /// the width if this <see cref="StaticPhysicsComponent"/>
    /// </summary>
    private int width;

    /// <summary>
    /// the height if this <see cref="StaticPhysicsComponent"/>
    /// </summary>
    private int height;

    /// <summary>
    /// Initializes a new instance of the <see cref="StaticPhysicsComponent"/> class
    /// </summary>
    /// <param name="position">the position</param>
    /// <param name="width">the width</param>
    /// <param name="height">the height</param>
    public StaticPhysicsComponent(Vector2 position, int width, int height)
    {
      this.position = position;
      this.width = width;
      this.height = height;
    }

    /// <inheritdoc />
    public Rectangle Bounds
    {
      get { return new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height); }
    }

    /// <inheritdoc />
    public bool Colliding { get; set; }

    /// <inheritdoc />
    public Vector2 Position
    {
      get { return this.position; }
    }
  }
}
