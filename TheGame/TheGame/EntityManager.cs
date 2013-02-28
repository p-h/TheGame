namespace TheGame
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;

  /// <summary>
  /// The EntityManager manages the components that together constitute the entities
  /// </summary>
  public class EntityManager
  {
    /// <summary>
    /// Holds the next EntityId
    /// </summary>
    private uint nextEntityId;

    /// <summary>
    /// Holds all the <see cref="Entity"/>
    /// </summary>
    private IList<Entity> entities;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityManager"/> class
    /// </summary>
    public EntityManager()
    {
      this.entities = new List<Entity>();
    }

    public Entity CreateEntity()
    {
      var newEntityId = this.nextEntityId;
      ++this.nextEntityId;

      Debug.Assert(!this.entities.Select(e => e.Id).Contains(newEntityId), "Entity is not allowed to exists yet");

      var entity = new Entity(newEntityId);
      this.entities.Add(entity);

      return entity;
    }

    public Entity GetEntityById(uint id)
    {
      return this.entities.First(e => e.Id == id);
    }

    public IEnumerable<Entity> GetEntitiesWhere(Func<Entity, bool> predicate)
    {
      return this.entities.Where(predicate);
    }

    /// <summary>
    /// Remove a Entity from the Entity Manager
    /// </summary>
    /// <param name="id">The ID of the entity</param>
    public void RemoveEntity(uint id)
    {
      var entity = this.entities.FirstOrDefault(e => e.Id == id);

      this.RemoveEntity(entity);
    }

    /// <summary>
    /// Remove a Entity from the Entity Manager
    /// </summary>
    /// <param name="entity">The entity to be removed</param>
    public void RemoveEntity(Entity entity)
    {
      Debug.Assert(this.entities != null, "The entity has to exists for it to be removed");

      this.entities.Remove(entity);
    }
  }
}
