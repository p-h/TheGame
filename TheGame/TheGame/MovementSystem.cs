namespace TheGame
{
  using System;
  using Microsoft.Xna.Framework;

  public class MovementSystem : GameComponent
  {
    private EntityManager enitityManager;

    public MovementSystem(Game game)
      : base(game)
    {
      this.enitityManager = game.EntityManager;
    }

    public override void Update(GameTime gameTime)
    {
      var entities = this.enitityManager.GetEntitiesWhere(e => e.Body != null && e.Idle.HasValue && e.Movement.HasValue && e.Acceleration.HasValue && e.Friction.HasValue);

      foreach (var entity in entities)
      {
        ApplyMovement(entity);
      }

      base.Update(gameTime);
    }

    private static void ApplyMovement(Entity entity)
    {
      var movement = entity.Movement.Value;
      var acceleration = entity.Acceleration.Value;
      if (Math.Abs(movement.X) >= .5f)
      {
        entity.Idle = false;
        entity.Body.Friction = 0f;
        var appliedMovement = Vector2.UnitX * movement.X * acceleration;
        entity.Body.LinearVelocity = entity.Body.LinearVelocity * Vector2.UnitY;
        entity.Body.LinearVelocity += appliedMovement;
      }
      else
      {
        entity.Body.Friction = entity.Friction.Value;
        entity.Idle = true;
      }
    }
  }
}
