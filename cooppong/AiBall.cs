using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cooppong
{
	public class AiBall : DrawableGameComponent
	{
		public Vector2 Position { get; set; }
		public Vector2 _speed;
		public Texture2D _texture;
		public Rectangle Bounds
		{
			get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }
		}
		public AiBall(Game game)
			: base(game)
		{
			Game.Components.Add(this);
		}

		protected override void LoadContent()
		{
			Position = new Vector2(100, 200);
			_speed = new Vector2(4, 8);
			_texture = Game.Content.Load<Texture2D>("ball");

			base.LoadContent();
		}
		public override void Update(GameTime gameTime)
		{
			Position += _speed;



			base.Update(gameTime);
		}






		public override void Draw(GameTime gameTime)
		{
			Game1.spriteBatch.Draw(_texture, Position, Color.White);

			base.Draw(gameTime);
		}


	}

}
