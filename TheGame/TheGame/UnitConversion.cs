namespace TheGame
{
  using Microsoft.Xna.Framework;

  public static class UnitConversion
  {
    private static readonly float PixelsPerMeter = Settings.Default.PixelsPerMeter;

    public static float SimToPixels(float x)
    {
      return x * PixelsPerMeter;
    }

    public static Vector2 SimToPixels(Vector2 x)
    {
      return x * PixelsPerMeter;
    }

    public static float PixelsToSim(float x)
    {
      return x / PixelsPerMeter;
    }

    public static Vector2 PixelsToSim(Vector2 x)
    {
      return x / PixelsPerMeter;
    }
  }
}
