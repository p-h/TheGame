namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// IPositionComponent defines all the components that have a position
  /// </summary>
  public interface IPositionComponent : IComponent
  {
    /// <summary>
    /// Gets the value of the position as a Vector2
    /// </summary>
    Vector2 Position { get; }
  }
}
