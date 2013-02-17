namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// <see cref="IMoveableComponent"/> defines all the components which are movable
  /// </summary>
  public interface IMoveableComponent : IPositionableComponent
  {
    /// <summary>
    /// Gets or sets the position component
    /// </summary>
    new Vector2 Position { get; set; }

    /// <summary>
    /// Gets or sets the Velocity
    /// </summary>
    Vector2 Velocity { get; set; }

    /// <summary>
    /// Gets or sets the Movement
    /// </summary>
    Vector2 Movement { get; set; }
  }
}
