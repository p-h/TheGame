namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  /// <summary>
  /// An abstract class for all sprites
  /// </summary>
  public abstract class SpriteBase : IDrawableComponent
  {
    /// <summary>
    /// Texture of this sprite
    /// </summary>
    private Texture2D texture;

    /// <summary>
    /// Layer Depth of this sprite
    /// </summary>
    private float layerDepth;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpriteBase"/> class
    /// </summary>
    /// <param name="texture">Texture of this <see cref="SpriteBase"/></param>
    /// <param name="layerDepth">The Layer Depth at which this component should be drawn at</param>
    public SpriteBase(Texture2D texture, LayerDepths layerDepth)
    {
      this.texture = texture;
      this.layerDepth = (float)layerDepth / 10;
    }

    /// <inheritdoc />
    public Texture2D Texture
    {
      get { return this.texture; }
    }

    /// <inheritdoc />
    public abstract Rectangle? SourceRectangle { get; }

    /// <inheritdoc />
    public float LayerDepth
    {
      get { return this.layerDepth; }
    }
  }
}
