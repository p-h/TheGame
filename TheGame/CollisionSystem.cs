namespace TheGame
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using Microsoft.Xna.Framework;

  public class CollisionSystem : GameComponent
  {
    private EntityManager entityManager;

    public CollisionSystem(Game game)
      : base(game)
    {
      this.entityManager = game.EntityManager;
    }

    public override void Update(GameTime gameTime)
    {
      var entities = this.entityManager.GetEntitiesWhere(e => e.Bounds.HasValue && e.Colliding.HasValue && e.CollisionType.HasValue);

      foreach (var e in entities)
      {
        e.Colliding = false;
      }

      for (var i = 0; i < entities.Count() - 1; i++)
      {
        var entity1 = entities.ElementAt(i);
        for (var j = i + 1; j < entities.Count(); j++)
        {
          var entity2 = entities.ElementAt(j);
          var intersectionDepth=            entity1.Bounds.Value.GetIntersectionDepth(entity2.Bounds.Value);
          if (entity1.Bounds.Value.Intersects(entity2.Bounds.Value))
          {
            entity1.Colliding = true;
            entity2.Colliding = true;

          }
        }
      }

      base.Update(gameTime);
    }
  }
}
