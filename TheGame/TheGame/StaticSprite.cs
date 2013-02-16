namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  /// <summary>
  /// StaticSprite is a sprite that does not change
  /// </summary>
  public class StaticSprite : SpriteBase
  {
    /// <inheritdoc />
    public StaticSprite(Texture2D texture, LayerDepths layerDepth)
      : base(texture, layerDepth)
    {
    }

    /// <inheritdoc />
    public override Rectangle? SourceRectangle
    {
      get { return null; }
    }
  }
}
