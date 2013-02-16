namespace TheGame
{
#if WINDOWS || XBOX
  /// <summary>
  /// The main entry point for the application.
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args">command line arguments</param>
    public static void Main(string[] args)
    {
      using (Game game = new Game())
      {
        game.Run();
      }
    }
  }
#endif
}
