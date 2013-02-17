namespace TheGame
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Xna.Framework;

  /// <summary>
  /// Manages all the <see cref="MoveablePhysicsComponent"/> Components
  /// </summary>
  public class PhysicsSystem : GameComponent
  {
    /// <summary>
    /// A function to get all the <see cref="ICollidableComponent"/>
    /// </summary>
    private Func<IEnumerable<ICollidableComponent>> getter;

    /// <summary>
    /// Initializes a new instance of the <see cref="PhysicsSystem"/> class
    /// </summary>
    /// <param name="game">The <see cref="Game"/></param>
    public PhysicsSystem(Game game)
      : base(game)
    {
      this.getter = game.EntityManager.GetComponents<ICollidableComponent>;
    }

    /// <summary>
    /// Updates the positions and checks for collisions on the <see cref="ICollidableComponent"/>
    /// </summary>
    /// <inheritdoc select="param" />
    public override void Update(GameTime gameTime)
    {
      var collidables = this.getter();

      this.UpdatePosition((float)gameTime.ElapsedGameTime.TotalSeconds, collidables.OfType<IMoveableComponent>());

      foreach (var c in collidables)
      {
        c.Colliding = false;
      }

      for (var i = 0; i < collidables.Count() - 1; i++)
      {
        var c1 = collidables.ElementAt(i);
        for (var j = i + 1; j < collidables.Count(); j++)
        {
          var c2 = collidables.ElementAt(j);
          var colliding = c1.Bounds.Intersects(c2.Bounds);
          c1.Colliding = c1.Colliding || colliding;
          c2.Colliding = c2.Colliding || colliding;
        }
      }

      base.Update(gameTime);
    }

    /// <summary>
    /// Updates the position of all the components
    /// </summary>
    /// <param name="dt">The time past since the last frame</param>
    /// <param name="moveables">the components to update</param>
    public void UpdatePosition(float dt, IEnumerable<IMoveableComponent> moveables)
    {
      var gravity = new Vector2(0f, 9.81f);
      foreach (var p in moveables)
      {
        var oldVelocity = p.Velocity;
        p.Velocity += gravity * dt;
        p.Position += (oldVelocity + p.Velocity) / 2 * dt;
      }
    }
  }
}
