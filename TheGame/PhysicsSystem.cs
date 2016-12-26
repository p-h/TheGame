namespace TheGame
{
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using Microsoft.Xna.Framework;

  /// <summary>
  /// Manages all the entities capable of physics
  /// </summary>
  public class PhysicsSystem : GameComponent
  {
    /// <summary>
    /// How many pixels are one meter
    /// </summary>
    public const int OneMeterInPixels = 128;

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
        if (e.Acceleration.HasValue && e.Movement.HasValue && e.IsInAir == false)
        {
          var additionalVelocityX = e.Movement.Value.X * e.Acceleration.Value * dt;

          e.Velocity += new Vector2(additionalVelocityX, 0f);
        }

        var oldVelocity = e.Velocity;

        if (e.IsInAir == true)
        {
          e.Velocity += this.Gravity * dt;
        }
        else if (e.IsInAir == false)
        {
          e.Velocity += e.Velocity.Value.X * Vector2.UnitX * e.GroundResistance * dt;
          if (e.JumpAcceleration.HasValue && e.Movement.HasValue && e.Movement.Value.Y < -.5f)
          {
            e.IsInAir = true;

            e.Velocity += Vector2.UnitY * e.JumpAcceleration.Value;
          }
        }

        e.Position += OneMeterInPixels * (oldVelocity + e.Velocity) / 2 * dt;
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
        for (var j = i + 1; j < entities.Count(); j++)
        {
          var entity2 = entities.ElementAt(j);
          if (entity1.Bounds.Value.Intersects(entity2.Bounds.Value))
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
          if (e2.Velocity.HasValue)
          {
            var velocity2 = e2.Velocity.Value;
            switch (CollisionSide(e2.Bounds.Value, e1.Bounds.Value))
            {
              case CollisionSides.FromAbove:
                velocity2.Y = velocity2.Y > 0f ? 0f : velocity2.Y;
                e2.IsInAir = false;
                break;
              case CollisionSides.FromLeft:
                velocity2.X = velocity2.X < 0f ? 0f : velocity2.X;
                break;
              case CollisionSides.FromBelow:
                velocity2.Y = velocity2.Y < 0f ? 0f : velocity2.Y;
                break;
              case CollisionSides.FromRight:
                velocity2.X = velocity2.X > 0f ? 0f : velocity2.X;
                break;
            }
            e2.Velocity = velocity2;
          }
          break;
        case CollisionTypes.None:
          break;
        case CollisionTypes.Kill:
          this.entityManager.RemoveEntity(e2.Id);
          break;
      }
    }

    /// <summary>
    /// Calculates the side from which <paramref name="rectangle1"/> collides with
    /// <paramref name="rectangle2"/>
    /// </summary>
    /// <param name="rectangle1">first rectangle</param>
    /// <param name="rectangle2">second rectangle</param>
    /// <returns>The collision side</returns>
    private static CollisionSides CollisionSide(Rectangle rectangle1, Rectangle rectangle2)
    {
      Debug.Assert(rectangle1.Intersects(rectangle2), "The two entities have to be colliding");

      return rectangle1.Top < rectangle2.Bottom ? CollisionSides.FromAbove
           : rectangle1.Left < rectangle2.Right ? CollisionSides.FromLeft
           : rectangle1.Bottom < rectangle2.Top ? CollisionSides.FromBelow
                                                : CollisionSides.FromRight;
    }
  }
}
