namespace TheGame
{
  using System;
  using System.Collections.Generic;
  using Microsoft.Xna.Framework;

  /// <summary>
  /// This class takes of the animation in the <see cref="AnimatedSprite"/>
  /// </summary>
  public class AnimationSystem : GameComponent
  {
    /// <summary>
    /// This function gets all the <see cref="AnimatedSpriteaa"/>
    /// </summary>
    private Func<IEnumerable<AnimatedSprite>> getter;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimationSystem"/> class
    /// </summary>
    /// <param name="game">The game that this component should be attached to</param>
    public AnimationSystem(Game game)
      : base(game)
    {
      this.getter = game.EntityManager.GetComponents<AnimatedSprite>;
    }

    /// <summary>
    /// Updates the animation of all the <see cref="AnimatedSprite"/>
    /// </summary>
    /// <inheritdoc select="param" />
    public override void Update(GameTime gameTime)
    {
      var sprites = this.getter();

      foreach (var sprite in sprites)
      {
        sprite.TimeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (!sprite.Idle && sprite.TimeSinceLastFrame >= sprite.FrameTime)
        {
          sprite.TimeSinceLastFrame = 0f;
          var currentSprite = sprite.CurrentSprite;

          if (sprite.CurrentSprite.Right < sprite.Texture.Width)
          {
            currentSprite.Offset(sprite.CurrentSprite.Width, 0);
          }
          else
          {
            currentSprite.X = 0;
          }

          sprite.CurrentSprite = currentSprite;
        }
      }

      base.Update(gameTime);
    }
  }
}
