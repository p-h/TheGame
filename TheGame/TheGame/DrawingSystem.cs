namespace TheGame
{
  using System;
  using System.Collections.Generic;
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
    /// Function to get the <see cref="IDrawableComponent" /> and their position from the <see cref="EntityManager" />
    /// </summary>
    private Func<IEnumerable<Tuple<IDrawableComponent, IPositionableComponent>>> getter;

    /// <summary>
    /// Initializes a new instance of the <see cref="DrawingSystem" /> class
    /// </summary>
    /// <param name="game">The game that this component should be attached to</param>
    public DrawingSystem(Game game)
      : base(game)
    {
      this.spriteBatch = game.SpriteBatch;
      this.getter = game.EntityManager.GetComponents<IDrawableComponent, IPositionableComponent>;
    }

    /// <summary>
    /// Gets all the <see cref="IDrawableComponent" /> and <see cref="IPositionableComponent" />
    /// which belong to one entity and draws them to the screen
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public override void Draw(GameTime gameTime)
    {
      this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

      foreach (var data in this.getter())
      {
        var drawable = data.Item1;
        var position = data.Item2.Position;
        this.spriteBatch.Draw(
          drawable.Texture,
          position,
          drawable.SourceRectangle,
          Color.White,
          0f,
          Vector2.Zero,
          1f,
          SpriteEffects.None,
          drawable.LayerDepth);
      }

      this.spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
