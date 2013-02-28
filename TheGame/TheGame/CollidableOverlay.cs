namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  /// <summary>
  /// Draws an overlay for all <see cref="ICollidableComponent"/>
  /// </summary>
  public class CollidableOverlay : DrawableGameComponent
  {
    /// <summary>
    /// A 1x1 pixels big white texture
    /// </summary>
    private Texture2D dummyTexture;

    /// <summary>
    /// The <see cref="SpriteBatch"/>
    /// </summary>
    private SpriteBatch spriteBatch;

    /// <summary>
    /// The <see cref="EntityManager"/> of this <see cref="CollidableOverlay"/>
    /// </summary>
    private EntityManager entityManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="CollidableOverlay" /> class
    /// </summary>
    /// <param name="game">The game that this component should be attached to</param>
    public CollidableOverlay(Game game)
      : base(game)
    {
      this.spriteBatch = game.SpriteBatch;
      this.dummyTexture = new Texture2D(game.GraphicsDevice, 1, 1);
      this.dummyTexture.SetData(new[] { Color.White });
      this.entityManager = game.EntityManager;
    }

    /// <summary>
    /// Draws all the overlays
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public override void Draw(GameTime gameTime)
    {
      var entities = this.entityManager.GetEntitiesWhere(e =>
        e.Position.HasValue &&
        e.Size.HasValue &&
        e.Colliding.HasValue);

      this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

      foreach (var entity in entities)
      {
        var bounds = new Rectangle((int)entity.Position.Value.X, (int)entity.Position.Value.Y, entity.Size.Value.X, entity.Size.Value.Y);
        this.spriteBatch.Draw(
          this.dummyTexture,
          bounds,
          null,
          (entity.Colliding.Value ? Color.Red : Color.White) * .5f,
          0f,
          Vector2.Zero,
          SpriteEffects.None,
          (float)LayerDepths.Debug);
      }

      this.spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
