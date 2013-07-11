namespace TheGame
{
  using FarseerPhysics.Dynamics;
  using FarseerPhysics.Factories;
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  public static class EntityFactory
  {
    public static Entity CreateTile(EntityManager entityManager, World world, Vector2 position, Texture2D texture)
    {
      var tile = entityManager.CreateEntity();
      var width = UnitConversion.PixelsToSim(texture.Width);
      var height = UnitConversion.PixelsToSim(texture.Height);

      tile.Texture = texture;
      tile.LayerDepth = (float)LayerDepths.Background / 10f;
      tile.Body = BodyFactory.CreateRectangle(world, width, height, 5f);
      tile.Body.BodyType = BodyType.Static;
      tile.Body.FixedRotation = true;
      tile.Body.Position = position;
      tile.Body.Friction = 1f;
      tile.Body.CollisionGroup = (short)CollisionGroups.Tile;

      return tile;
    }

    public static Entity CreatePlayer(EntityManager entityManager, World world, Vector2 position, Texture2D texture)
    {
      var player = entityManager.CreateEntity();

      var radius = UnitConversion.PixelsToSim(32f);

      player.Velocity = Vector2.Zero;
      player.Movement = Vector2.Zero;
      player.Acceleration = 5f;
      player.SourceRectangle = new Rectangle(0, 0, 64, 64);
      player.Idle = true;
      player.TimeSinceLastFrame = 0f;
      player.FrameTime = .1f;
      player.Texture = texture;
      player.LayerDepth = (float)LayerDepths.Characters / 10f;
      player.Colliding = false;
      player.Body = BodyFactory.CreateCircle(world, radius, 5f);
      player.Body.BodyType = BodyType.Dynamic;
      player.Body.FixedRotation = true;
      player.Body.CollisionGroup = (short)CollisionGroups.Player;
      player.Body.Position = position;
      player.Friction = 1f;
      player.Body.Mass = 20f;

      return player;
    }
  }
}
