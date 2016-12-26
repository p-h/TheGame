namespace TheGame
{
  using Microsoft.Xna.Framework;

  /// <summary>
  /// This class takes care of the entities capable of animating
  /// </summary>
  public class AnimationSystem : GameComponent
  {
    /// <summary>
    /// The <see cref="EntityManager"/> of this <see cref="AnimationSystem"/>
    /// </summary>
    private EntityManager entityManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimationSystem"/> class
    /// </summary>
    /// <param name="game">The game that this component should be attached to</param>
    public AnimationSystem(Game game)
      : base(game)
    {
      this.entityManager = game.EntityManager;
    }

    /// <summary>
    /// Updates the animation of all the <see cref="AnimatedSprite"/>
    /// </summary>
    /// <inheritdoc select="param" />
    public override void Update(GameTime gameTime)
    {
      var entities = this.entityManager.GetEntitiesWhere(e =>
        e.Texture != null &&
        e.FrameTime.HasValue &&
        e.TimeSinceLastFrame.HasValue &&
        e.SourceRectangle.HasValue &&
        e.Idle.HasValue);

      foreach (var entity in entities)
      {
        entity.TimeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (!entity.Idle.Value && entity.TimeSinceLastFrame >= entity.FrameTime)
        {
          entity.TimeSinceLastFrame = 0f;
          var sourceRectangle = entity.SourceRectangle.Value;

          if (sourceRectangle.Right < entity.Texture.Width)
          {
            sourceRectangle.X += sourceRectangle.Width;
          }
          else
          {
            sourceRectangle.X = 0;
          }

          entity.SourceRectangle = sourceRectangle;
        }
      }

      base.Update(gameTime);
    }
  }
}
