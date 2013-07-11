namespace TheGame
{
  using Microsoft.Xna.Framework;
  using Microsoft.Xna.Framework.Graphics;

  /// <summary>
  /// This is the main type for your game
  /// </summary>
  public class Game : Microsoft.Xna.Framework.Game
  {
    /// <summary>
    /// SpriteBatch of this Game
    /// </summary>
    private SpriteBatch spriteBatch;

    /// <summary>
    /// EntityManager of this Game
    /// </summary>
    private EntityManager entityManager;

    /// <summary>
    /// GraphicsDeviceManager of this Game
    /// </summary>
    private GraphicsDeviceManager graphics;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game" /> class
    /// </summary>
    public Game()
    {
      this.graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";

      this.entityManager = new EntityManager();
    }

    /// <summary>
    /// Gets the SpriteBatch
    /// </summary>
    public SpriteBatch SpriteBatch
    {
      get { return this.spriteBatch; }
    }

    /// <summary>
    /// Gets the EntityManager
    /// </summary>
    public EntityManager EntityManager
    {
      get { return this.entityManager; }
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
      base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      // Create a new SpriteBatch, which can be used to draw textures.
      this.spriteBatch = new SpriteBatch(GraphicsDevice);

      var backgroundTile = Content.Load<Texture2D>("background_tile");
      var kat = Content.Load<Texture2D>("kat");

      var physicsSystem = new PhysicsSystem(new Vector2(0f, 9.81f));

      var screenWidth = UnitConversion.PixelsToSim(Window.ClientBounds.Width);
      var screenHeight = UnitConversion.PixelsToSim(Window.ClientBounds.Height);
      var tileWidth = UnitConversion.PixelsToSim(backgroundTile.Width);
      var tileHeight = UnitConversion.PixelsToSim(backgroundTile.Height);

      for (var i = 0f; i <= screenWidth; i += tileWidth)
      {
        var position = new Vector2(i, screenHeight - tileHeight);
        var foo = UnitConversion.SimToPixels(position);
        EntityFactory.CreateTile(this.entityManager, physicsSystem, position, backgroundTile);
      }

      EntityFactory.CreateTile(this.entityManager, physicsSystem, new Vector2(screenWidth - tileWidth, screenHeight - (tileHeight * 2)), backgroundTile);
      EntityFactory.CreateTile(this.entityManager, physicsSystem, new Vector2(0f, screenHeight - (tileHeight * 2)), backgroundTile);

      EntityFactory.CreatePlayer(this.entityManager, physicsSystem, Vector2.Zero, kat);

      Components.Add(new DrawingSystem(this));
      Components.Add(physicsSystem);
      Components.Add(new AnimationSystem(this));
      Components.Add(new InputSystem(this));
      Components.Add(new MovementSystem(this));
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// all content.
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      base.Draw(gameTime);
    }
  }
}
