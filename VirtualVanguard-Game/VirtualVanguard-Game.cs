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
        _eventManager = new EventManager();
        _entities = new List<Entity>();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        // test spawn entities
        _entities.Add(new PlayerEntity(new Vector2(100, 100), 50, 50, Content.Load<Texture2D>("testplayer")));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _eventManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        foreach (var entity in _entities) // ✅ Correct syntax
        {
            _spriteBatch.Draw(entity.Image, entity.Position, Color.White);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }

}
