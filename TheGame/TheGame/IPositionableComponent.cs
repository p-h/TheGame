namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// <see cref="IPositionableComponent"/> defines all the components that have a position
  /// </summary>
  public interface IPositionableComponent : IComponent
  {
    /// <summary>
    /// Gets the value of the position as a Vector2
    /// </summary>
    Vector2 Position { get; }
  }
}
