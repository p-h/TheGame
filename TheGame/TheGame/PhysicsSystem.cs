namespace TheGame
{
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Xna.Framework;

  /// <summary>
  /// Manages all the entities capable of physics
  /// </summary>
  public class PhysicsSystem : GameComponent
  {
    /// <summary>
    /// The gravity constant of this world
    /// </summary>
    public readonly Vector2 Gravity = new Vector2(0f, 9.81f);

    /// <summary>
    /// The <see cref="EntityManager"/> of this <see cref="PhysicsSystem"/>
    /// </summary>
    private EntityManager entityManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="PhysicsSystem"/> class
    /// </summary>
    /// <param name="game">The <see cref="Game"/></param>
    public PhysicsSystem(Game game)
      : base(game)
    {
      this.entityManager = game.EntityManager;
    }

    /// <summary>
    /// Updates the positions and checks for collisions on the collidable
    /// entities
    /// </summary>
    /// <inheritdoc select="param" />
    public override void Update(GameTime gameTime)
    {
      var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

      var toUpdatePosition = this.entityManager.GetEntitiesWhere(e => e.Position.HasValue && e.Velocity.HasValue);
      var toHandleCollision = this.entityManager.GetEntitiesWhere(e => e.Position.HasValue && e.Size.HasValue);

      this.UpdatePosition(dt, toUpdatePosition);
      this.HandleCollisions(toHandleCollision);

      base.Update(gameTime);
    }

    /// <summary>
    /// Updates the position of all the entities
    /// </summary>
    /// <param name="dt">The time past since the last frame</param>
    /// <param name="entities">the entities to update</param>
    public void UpdatePosition(float dt, IEnumerable<Entity> entities)
    {
      foreach (var e in entities)
      {
        if (e.Acceleration.HasValue && e.Movement.HasValue)
        {
          e.Velocity += dt * e.Movement * e.Acceleration;
        }

        var oldVelocity = e.Velocity;
        e.Velocity += this.Gravity * dt;
        e.Position += (oldVelocity + e.Velocity) / 2 * dt;
      }
    }

    /// <summary>
    /// Detects collisions and acts upon them
    /// </summary>
    /// <param name="entities">The entities to check</param>
    private void HandleCollisions(IEnumerable<Entity> entities)
    {
      foreach (var c in entities)
      {
        c.Colliding = false;
      }

      for (var i = 0; i < entities.Count() - 1; i++)
      {
        var entity1 = entities.ElementAt(i);
        var bounds1 = new Rectangle((int)entity1.Position.Value.X, (int)entity1.Position.Value.Y, entity1.Size.Value.X, entity1.Size.Value.Y);
        for (var j = i + 1; j < entities.Count(); j++)
        {
          var entity2 = entities.ElementAt(j);
          var bounds2 = new Rectangle((int)entity2.Position.Value.X, (int)entity2.Position.Value.Y, entity2.Size.Value.X, entity2.Size.Value.Y);
          if (bounds1.Intersects(bounds2))
          {
            entity1.Colliding = true;
            entity2.Colliding = true;

            this.ActOnCollision(entity1, entity2);
            this.ActOnCollision(entity2, entity1);
          }
        }
      }
    }

    /// <summary>
    /// If a collision between two <see cref="Entity"/> occurs this method is
    /// called and decides what to do
    /// </summary>
    /// <param name="e1">The first <see cref="Entity"/></param>
    /// <param name="e2">The second <see cref="Entity"/></param>
    private void ActOnCollision(Entity e1, Entity e2)
    {
      switch (e1.CollisionType)
      {
        case CollisionTypes.Stop:
          e2.Velocity = Vector2.Zero;
          break;
        case CollisionTypes.None:
          break;
        case CollisionTypes.Kill:
          this.entityManager.RemoveEntity(e2.Id);
          break;
      }
    }
  }
}
