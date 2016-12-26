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

      for (var i = 0; i <= Window.ClientBounds.Width; i += 64)
      {
        var tile = this.entityManager.CreateEntity();
        tile.Texture = backgroundTile;
        tile.LayerDepth = (float)LayerDepths.Background / 10f;
        tile.Position = new Vector2(i, Window.ClientBounds.Height - backgroundTile.Height);
        tile.Size = new Point(backgroundTile.Bounds.X, backgroundTile.Bounds.Y);
        tile.Colliding = false;
        tile.CollisionType = CollisionTypes.Stop;
        tile.Size = new Point(64, 64);
      }

      var leftTile = this.entityManager.CreateEntity();
      leftTile.Texture = backgroundTile;
      leftTile.LayerDepth = (float)LayerDepths.Background / 10f;
      leftTile.Position = new Vector2(Window.ClientBounds.Width - 64, Window.ClientBounds.Height - 64 - backgroundTile.Height);
      leftTile.Size = new Point(backgroundTile.Bounds.X, backgroundTile.Bounds.Y);
      leftTile.Colliding = false;
      leftTile.CollisionType = CollisionTypes.Stop;
      leftTile.Size = new Point(64, 64);

      var playerEntity = this.entityManager.CreateEntity();
      playerEntity.Position = Vector2.Zero;
      playerEntity.Velocity = Vector2.Zero;
      playerEntity.Movement = Vector2.Zero;
      playerEntity.Acceleration = 10f;
      playerEntity.GroundResistance = .5f;
      playerEntity.SourceRectangle = new Rectangle(0, 0, 64, 64);
      playerEntity.Idle = false;
      playerEntity.TimeSinceLastFrame = 0f;
      playerEntity.FrameTime = .1f;
      playerEntity.Texture = kat;
      playerEntity.LayerDepth = (float)LayerDepths.Characters / 10f;
      playerEntity.Colliding = false;
      playerEntity.CollisionType = CollisionTypes.None;
      playerEntity.Size = new Point(64, 64);
      playerEntity.IsInAir = true;
      playerEntity.JumpAcceleration = -5f;

      Components.Add(new DrawingSystem(this));
      Components.Add(new CollidableOverlay(this));
      Components.Add(new PhysicsSystem(this));
      /*Components.Add(new AnimationSystem(this));*/
      Components.Add(new InputSystem(this));
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
