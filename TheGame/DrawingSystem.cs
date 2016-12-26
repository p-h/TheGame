namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  /// <summary>
  /// DrawingSystem draws the the entities to the screen
  /// </summary>
  public class DrawingSystem : DrawableGameComponent
  {
    /// <summary>
    /// SpriteBatch of this DrawingSystem
    /// </summary>
    private SpriteBatch spriteBatch;

    /// <summary>
    /// The <see cref="EntityManager" /> of this <see cref="DrawingSystem"/>
    /// </summary>
    private EntityManager entityManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="DrawingSystem" /> class
    /// </summary>
    /// <param name="game">The game that this component should be attached to</param>
    public DrawingSystem(Game game)
      : base(game)
    {
      this.spriteBatch = game.SpriteBatch;
      this.entityManager = game.EntityManager;
    }

    /// <summary>
    /// Gets all the entities capable of being drawn and draws them to the
    /// screen
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public override void Draw(GameTime gameTime)
    {
      this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

      var entities = this.entityManager.GetEntitiesWhere(e =>
        e.Position.HasValue &&
        e.Texture != null &&
        e.LayerDepth.HasValue);

      foreach (var entity in entities)
      {
        this.spriteBatch.Draw(
          entity.Texture,
          entity.Position.Value,
          entity.SourceRectangle,
          Color.White,
          0f,
          Vector2.Zero,
          1f,
          SpriteEffects.None,
          entity.LayerDepth.Value);
      }

      this.spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
