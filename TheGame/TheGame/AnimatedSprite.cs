namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  /// <summary>
  /// A sprite that has an animation
  /// </summary>
  public class AnimatedSprite : SpriteBase
  {
    /// <summary>
    /// The portion of the spriteSheet that will be drawn
    /// </summary>
    private Rectangle sourceRectangle;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatedSprite"/> class
    /// </summary>
    /// <param name="texture">Texture of this <see cref="AnimatedSprite"/></param>
    /// <param name="layerDepth">The Layer Depth at which this component should be drawn at</param>
    /// <param name="sourceRectangle">The sourceRectangle of this Sprite</param>
    public AnimatedSprite(Texture2D texture, LayerDepths layerDepth, Rectangle sourceRectangle)
      : base(texture, layerDepth)
    {
      this.sourceRectangle = sourceRectangle;
    }

    /// <inheritdoc />
    public override Rectangle? SourceRectangle
    {
      get { return this.sourceRectangle; }
    }

    /// <summary>
    /// Gets or sets the current sprite
    /// </summary>
    public Rectangle CurrentSprite
    {
      get { return this.sourceRectangle; }
      set { this.sourceRectangle = value; }
    }

    /// <summary>
    /// Gets or sets a the time past since the last frame
    /// </summary>
    public float TimeSinceLastFrame { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the sprite is idle
    /// </summary>
    public bool Idle { get; set; }

    /// <summary>
    /// Gets or sets the time between frames
    /// </summary>
    public float Fps { get; set; }
  }
}
