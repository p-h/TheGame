namespace TheGame
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using Microsoft.Xna.Framework;

  /// <summary>
  /// The EntityManager manages the components that together constitute the entities
  /// </summary>
  public class EntityManager : IGameComponent
  {
    /// <summary>
    /// Holds the next EntityId
    /// </summary>
    private uint nextEntityId;

    /// <summary>
    /// Holds the components per entity id
    /// </summary>
    private IDictionary<uint, IList<IComponent>> entities;

    /// <summary>
    /// Initializes this EntityManager
    /// </summary>
    public void Initialize()
    {
      this.nextEntityId = 0u;
      this.entities = new Dictionary<uint, IList<IComponent>>();
    }

    /// <summary>
    /// Creates a new entity and adds components to it
    /// </summary>
    /// <param name="componentsToAdd">components that will be added to the entity</param>
    public void CreateEntity(IEnumerable<IComponent> componentsToAdd)
    {
      var newEntityId = this.CreateEntity();
      this.AddToEntity(newEntityId, componentsToAdd);
    }

    /// <summary>
    /// Creates a new entity and adds components to it
    /// </summary>
    /// <param name="componentsToAdd">components that will be added to the entity</param>
    public void CreateEntity(params IComponent[] componentsToAdd)
    {
      this.CreateEntity(componentsToAdd.AsEnumerable());
    }

    /// <summary>
    /// Adds components to entities
    /// </summary>
    /// <param name="entityId">The ID of the entity</param>
    /// <param name="componentsToAdd">The components to be added</param>
    public void AddToEntity(uint entityId, IEnumerable<IComponent> componentsToAdd)
    {
      foreach (var c in componentsToAdd)
      {
        this.entities[entityId].Add(c);
      }
    }

    /// <summary>
    /// Adds components to entities
    /// </summary>
    /// <param name="entityId">The ID of the entity</param>
    /// <param name="componentsToAdd">The components to be added</param>
    public void AddToEntity(uint entityId, params IComponent[] componentsToAdd)
    {
      this.AddToEntity(entityId, componentsToAdd.AsEnumerable());
    }

    /// <summary>
    /// Gets the component of a certain type from an entity
    /// </summary>
    /// <typeparam name="T">The component type</typeparam>
    /// <param name="entityId">The entity ID</param>
    /// <returns>the component if available, else null</returns>
    public T GetComponent<T>(uint entityId)
      where T : IComponent
    {
      return this.entities[entityId]
        .OfType<T>()
        .FirstOrDefault();
    }

    /// <summary>
    /// Gets all components of a certain type
    /// </summary>
    /// <typeparam name="T">The type</typeparam>
    /// <returns>the components of type T</returns>
    public IEnumerable<T> GetComponents<T>()
      where T : IComponent
    {
      return from components in this.entities.Values
             from component in components.OfType<T>()
             select component;
    }

    /// <summary>
    /// Gets the components of the specified types if they are all available in one entity
    /// </summary>
    /// <typeparam name="T1">first component type</typeparam>
    /// <typeparam name="T2">second component type</typeparam>
    /// <returns>Tuples of components of type T1 and T2</returns>
    public IEnumerable<Tuple<T1, T2>> GetComponents<T1, T2>()
      where T1 : IComponent
      where T2 : IComponent
    {
      foreach (var entityComponents in this.entities)
      {
        var c1 = entityComponents.Value
          .OfType<T1>()
          .FirstOrDefault();
        var c2 = entityComponents.Value
          .OfType<T2>()
          .FirstOrDefault();

        if (c1 != null && c2 != null)
        {
          yield return Tuple.Create(c1, c2);
        }
      }
    }

    /// <summary>
    /// Gets the components of the specified types if they are all available in one entity
    /// </summary>
    /// <typeparam name="T1">first component type</typeparam>
    /// <typeparam name="T2">second component type</typeparam>
    /// <typeparam name="T3">third component type</typeparam>
    /// <returns>Tuples of components of type T1, T2 and T3</returns>
    public IEnumerable<Tuple<T1, T2, T3>> GetComponents<T1, T2, T3>()
      where T1 : IComponent
      where T2 : IComponent
      where T3 : IComponent
    {
      foreach (var entityComponents in this.entities)
      {
        var c1 = entityComponents.Value
          .OfType<T1>()
          .FirstOrDefault();
        var c2 = entityComponents.Value
          .OfType<T2>()
          .FirstOrDefault();
        var c3 = entityComponents.Value
          .OfType<T3>()
          .FirstOrDefault();

        if (c1 != null && c2 != null && c3 != null)
        {
          yield return Tuple.Create(c1, c2, c3);
        }
      }
    }

    /// <summary>
    /// Increments the next entity counter and adds a new component list to the entity dictionary
    /// </summary>
    /// <returns>ID of the entity</returns>
    private uint CreateEntity()
    {
      var newEntityId = this.nextEntityId;
      ++this.nextEntityId;

      Debug.Assert(!this.entities.ContainsKey(newEntityId), "Entity is not allowed to exists yet");

      this.entities.Add(newEntityId, new List<IComponent>());

      return newEntityId;
    }
  }
}
