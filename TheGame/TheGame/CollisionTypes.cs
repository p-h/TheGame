namespace TheGame
{
  /// <summary>
  /// An enumeration that determines the types of collisions possible
  /// </summary>
  public enum CollisionTypes
  {
    /// <summary>
    /// A collision that stops the the Entity from moving
    /// </summary>
    Stop,

    /// <summary>
    /// A meaningless collision
    /// </summary>
    None,

    /// <summary>
    /// Fatal collision
    /// </summary>
    Kill
  }
}
