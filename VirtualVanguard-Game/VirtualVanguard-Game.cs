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
    private List<Control> _controls;

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
        _controls = new List<Control>();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
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

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
