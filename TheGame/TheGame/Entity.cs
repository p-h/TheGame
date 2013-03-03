namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  /// <summary>
  /// All entities in this game use this class.
  /// The systems then operate on the instances of this class that have the
  /// necessary components
  /// </summary>
  public class Entity
  {
    /// <summary>
    /// A runtime constant that distinguishes this <see cref="Entity"/> from the others
    /// </summary>
    private readonly uint id;

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class
    /// </summary>
    /// <param name="id">The ID this entity will have</param>
    public Entity(uint id)
    {
      this.id = id;
    }

    /// <summary>
    /// Gets the ID of this <see cref="Entity"/>
    /// </summary>
    public uint Id
    {
      get
      {
        return this.id;
      }
    }

    #region Components
    /// <summary>
    /// Gets or sets this entity's Position
    /// </summary>
    public Vector2? Position { get; set; }

    /// <summary>
    /// Gets or sets this entity's Velocity
    /// </summary>
    public Vector2? Velocity { get; set; }

    /// <summary>
    /// Gets or sets this entity's Movement
    /// </summary>
    public Vector2? Movement { get; set; }

    /// <summary>
    /// Gets or sets this entity's Acceleration
    /// </summary>
    public float? Acceleration { get; set; }

    /// <summary>
    /// Gets or sets this entity's Size
    /// </summary>
    public Point? Size { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this entity is Colliding
    /// </summary>
    public bool? Colliding { get; set; }

    /// <summary>
    /// Gets this entity's collision bounds
    /// </summary>
    public Rectangle? Bounds
    {
      get
      {
        return this.Position.HasValue && this.Size.HasValue ?
          new Rectangle((int)this.Position.Value.X, (int)this.Position.Value.Y, this.Size.Value.X, this.Size.Value.Y) :
          (Rectangle?)null;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this entity is in the air
    /// </summary>
    public bool? IsInAir { get; set; }

    /// <summary>
    /// Gets or sets the jump acceleration
    /// </summary>
    public float? JumpAcceleration { get; set; }

    /// <summary>
    /// Gets or sets the ground resistance
    /// </summary>
    public float? GroundResistance { get; set; }

    /// <summary>
    /// Gets or sets this entity's <see cref="CollisionTypes"/>
    /// </summary>
    public CollisionTypes? CollisionType { get; set; }

    /// <summary>
    /// Gets or sets this entity's Texture
    /// </summary>
    public Texture2D Texture { get; set; }

    /// <summary>
    /// Gets or sets this entity's SourceRectangle
    /// </summary>
    public Rectangle? SourceRectangle { get; set; }

    /// <summary>
    /// Gets or sets this entity's LayerDepth
    /// </summary>
    public float? LayerDepth { get; set; }

    /// <summary>
    /// Gets or sets this entity's TimeSinceLastFrame
    /// </summary>
    public float? TimeSinceLastFrame { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this entity is idle
    /// </summary>
    public bool? Idle { get; set; }

    /// <summary>
    /// Gets or sets this entity's FrameTime
    /// </summary>
    public float? FrameTime { get; set; }
    #endregion
  }
}
