namespace Models.Factories
{
    public abstract class SpriteFactory
    {
        public abstract void CreateSprite(string type, int x, int y, int width, int height, string imagePath);
    }
}