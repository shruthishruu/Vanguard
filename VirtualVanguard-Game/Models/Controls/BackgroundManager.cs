using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace VirtualVanguard_Game.Models
{
    public class BackgroundManager
    {
        private ContentManager Content;
        private Dictionary<string, Texture2D> _backgroundTextures;
        private Texture2D currentBackground;
        public BackgroundManager(ContentManager content) 
        {
            Content = content;
            // Load all background textures
            _backgroundTextures = new Dictionary<string, Texture2D>
            {
                { "background1", Content.Load<Texture2D>("Background1") }, // Name of your image file (without extension)
                { "background2", Content.Load<Texture2D>("Background2") },
                { "background3", Content.Load<Texture2D>("Background3") }
            };
            currentBackground = _backgroundTextures["background1"];
        }
        // Method to change the current background
        public void SetBackground(string backgroundKey)
        {
            if (_backgroundTextures.ContainsKey(backgroundKey))
            {
                currentBackground = _backgroundTextures[backgroundKey];
            }
            else
            {
                throw new ArgumentException($"Background '{backgroundKey}' not found.");
            }
        }
        public Texture2D GetCurrentBackground()
        {
            return currentBackground;
        }

    }
}