﻿using Microsoft.Xna.Framework;
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
    private AttackControl _attackControl;
    private CharacterFactory _characterFactory;
    private CollectableFactory _collectableFactory;
    private BulletFactory _bulletFactory;
    private EntityManager _entityManager;

    public VirtualVanguardGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _entityManager = new EntityManager();
        _characterFactory = new CharacterFactory(Content, _entityManager);
        _collectableFactory = new CollectableFactory(Content, _entityManager);
        _bulletFactory = new BulletFactory(Content, _entityManager);
        
        _movementControl = new MovementControl(_entityManager);
        _attackControl = new AttackControl(_entityManager);
        _eventManager = new EventManager(_characterFactory);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _characterFactory.CreateEntity("Player", new Vector2(100, 100), 50, 50, 0);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _eventManager.Update(gameTime);

        // Handle the movement of each entity
        _movementControl.Update();
        _attackControl.Update(gameTime);


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        foreach (var entity in _entityManager.GetAllEntities())
        {
            var rect = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.Width, entity.Height);
            _spriteBatch.Draw(entity.Image, rect, Color.White);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }

}
