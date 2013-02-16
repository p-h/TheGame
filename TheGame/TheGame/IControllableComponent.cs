namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// Defines a controllable component
  /// </summary>
  public interface IControllableComponent : ICollidableComponent
  {
    /// <summary>
    /// Gets or sets the movement
    /// </summary>
    Point Movement { get; set; }

    // TODO: Define a away to specify the inputs here
  }
}
