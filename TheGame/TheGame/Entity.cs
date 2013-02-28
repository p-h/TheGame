namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  public class Entity
  {
    private readonly uint id;

    public Entity(uint id)
    {
      this.id = id;
    }

    public uint Id
    {
      get
      {
        return this.id;
      }
    }

    #region Components
    public Vector2? Position { get; set; }

    public Vector2? Velocity { get; set; }

    public Vector2? Movement { get; set; }

    public float? Acceleration { get; set; }

    public Point? Size { get; set; }

    public bool? Colliding { get; set; }

    public CollisionTypes? CollisionType { get; set; }

    public Texture2D Texture { get; set; }

    public Rectangle? SourceRectangle { get; set; }

    public float? LayerDepth { get; set; }

    public float? TimeSinceLastFrame { get; set; }

    public bool? Idle { get; set; }

    public float? FrameTime { get; set; }
    #endregion
  }
}
