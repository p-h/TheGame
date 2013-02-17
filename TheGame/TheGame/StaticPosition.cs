namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// StaticPosition is a Position Component that does not change
  /// </summary>
  public class StaticPosition : IPositionableComponent
  {
    /// <summary>
    /// Holds the Vector2 value of this position
    /// </summary>
    private readonly Vector2 value;

    /// <summary>
    /// Initializes a new instance of the <see cref="StaticPosition" /> class
    /// </summary>
    /// <param name="position">Position of this StaticPosition</param>
    public StaticPosition(Vector2 position)
    {
      this.value = position;
    }

    /// <inheritdoc />
    public Vector2 Position
    {
      get { return this.value; }
    }
  }
}
