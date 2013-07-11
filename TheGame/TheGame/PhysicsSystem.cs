namespace TheGame
{
  using System;
  using FarseerPhysics.Collision;
  using FarseerPhysics.Dynamics;
  using Microsoft.Xna.Framework;

  /// <summary>
  /// Manages all the entities capable of physics
  /// </summary>
  public class PhysicsSystem : World, IGameComponent, IUpdateable
  {
    private int updateOrder;

    public PhysicsSystem(Vector2 gravity)
      : base(gravity)
    {
    }

    public PhysicsSystem(Vector2 gravity, AABB span)
      : base(gravity, span)
    {
    }

    public event EventHandler<EventArgs> EnabledChanged;

    public event EventHandler<EventArgs> UpdateOrderChanged;

    public new bool Enabled
    {
      get
      {
        return base.Enabled;
      }

      set
      {
        if (base.Enabled != value)
        {
          base.Enabled = value;
          if (this.EnabledChanged != null)
          {
            this.EnabledChanged(this, EventArgs.Empty);
          }
        }
      }
    }

    public int UpdateOrder
    {
      get
      {
        return this.updateOrder;
      }

      set
      {
        if (this.updateOrder != value)
        {
          this.updateOrder = value;
          if (this.UpdateOrderChanged != null)
          {
            this.UpdateOrderChanged(this, EventArgs.Empty);
          }
        }
      }
    }

    public void Initialize()
    {
    }

    /// <summary>
    /// Updates the positions and checks for collisions on the collidable
    /// entities
    /// </summary>
    /// <inheritdoc select="param" />
    public void Update(GameTime gameTime)
    {
      this.Step(Settings.Default.PhysicsSystemUpdateRate);
    }
  }
}
