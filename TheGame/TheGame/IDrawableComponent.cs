namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  /// <summary>
  /// <see cref="IDrawableComponent"/> defines all components which can be drawn
  /// </summary>
  public interface IDrawableComponent : IComponent
  {
    /// <summary>
    /// Gets the texture of the <see cref="IDrawableComponent" />
    /// </summary>
    Texture2D Texture { get; }

    /// <summary>
    /// Gets the portion of the Texture which should be drawn to the screen
    /// </summary>
    Rectangle? SourceRectangle { get; }

    /// <summary>
    /// Gets the layer at which this <see cref="IDrawableComponent" /> will be rendered at
    /// </summary>
    float LayerDepth { get; }
  }
}
