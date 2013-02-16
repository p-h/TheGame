namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// <see cref="ICollidableComponent"/> defines all the components that can collide
  /// </summary>
  public interface ICollidableComponent : IComponent
  {
    /// <summary>
    /// Gets the rectangle with which a collision can be checked for
    /// </summary>
    Rectangle Bounds { get; }

    /// <summary>
    /// Gets or sets a value indicating whether this component is colliding with something
    /// </summary>
    bool Colliding { get; set; }
  }
}
