using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VirtualVanguard_Game.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace VirtualVanguard_Game;

public class VirtualVanguardGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private EventManager _eventManager;
    private MovementControl _movementControl;
    private List<Entity> _entities;

    public VirtualVanguardGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    public ReadOnlyCollection<Entity> Entities
    {
        // ReadOnlyCollection prevents external systems from adding or deletions in the list
        get { return _entities.AsReadOnly(); }
    }

    protected override void Initialize()
    {
        _eventManager = new EventManager(Content);
        _entities = new List<Entity>();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        // test spawn entities
        _entities.Add(new PlayerEntity(new Vector2(100, 100), 50, 50, Content.Load<Texture2D>("testplayer")));
        _entities.Add(new EnemyEntity(new Vector2(100, 100), 50, 50, Content.Load<Texture2D>("testplayer")));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _eventManager.Update(gameTime);

        // Handle the movement of each entity
        _movementControl.Update(_entities);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        foreach (var entity in _entities) // ✅ Correct syntax
        {
            var rect = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.Width, entity.Height);
            _spriteBatch.Draw(entity.Image, rect, Color.White);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }

}
