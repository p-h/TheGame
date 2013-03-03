namespace TheGame
{
  using Microsoft.Xna.Framework;

  public struct Collision
  {
    public Entity Collider;
    public Entity Collidee;
    public Vector2 IntersectionDepth;

    public Collision(Entity collider, Entity collidee, Vector2 intersectionDepth)
    {
      this.Collider = collider;
      this.Collidee = collidee;
      this.IntersectionDepth = intersectionDepth;
    }
  }
}
