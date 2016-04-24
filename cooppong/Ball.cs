using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cooppong
{
	public class Ball : DrawableGameComponent
	{
		public Vector2 Position { get; set; }
		public Vector2 _speed;
		public Texture2D _texture;
		public int score1 = 0;
		public int score2 = 0;
		private SpriteFont _Neon;
		private String scoreshow;
		public Rectangle Bounds
		{
			get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }
		}
		public Ball(Game game)
			: base(game)
		{
			Game.Components.Add(this);
		}

		protected override void LoadContent()
		{
			Position = new Vector2(GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2);
			_speed = new Vector2(1, 2);
			_texture = Game.Content.Load<Texture2D>("ball");
			_Neon = Game.Content.Load<SpriteFont>("Verdana35Regular");

			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			Position += _speed;
			bounce();
			outofgame();
			scoreshow = score2.ToString() +"-" + score1.ToString();


			base.Update(gameTime);
		}

		private void bounce()
		{
			// Linkermuur

		}
		public void outofgame(){
			//boven en onder
			if (Position.Y + _texture.Height > GraphicsDevice.Viewport.Height || Position.Y < 0)
			{
				_speed.Y *= -1;
				Position = new Vector2((GraphicsDevice.Viewport.Width/2),(GraphicsDevice.Viewport.Height/2));
				_speed = new Vector2(1, 2);
				score2++;
			}
			//links
			if (Position.X + _texture.Width > GraphicsDevice.Viewport.Width)
			{
				Position = new Vector2((GraphicsDevice.Viewport.Width/2),(GraphicsDevice.Viewport.Height/2));
				score1++;

				_speed = new Vector2(2, 1);
			}
			if (Position.X < 0)
			{
				Position = new Vector2((GraphicsDevice.Viewport.Width/2),(GraphicsDevice.Viewport.Height/2));
				_speed = new Vector2(1, -2);
				score1++;

			}
		}


		public override void Draw(GameTime gameTime)
		{
			//Game1.spriteBatch.DrawString(_Neon, scoreshow, new Vector2((GraphicsDevice.Viewport.Width / 4) * 3, GraphicsDevice.Viewport.Height - 200), Color.White);
			//Game1.spriteBatch.DrawString(_Neon, scoreshow, new Vector2((GraphicsDevice.Viewport.Width / 4) , 150), Color.White, 22, new Vector2(0,0), 0 ,0, 0);
			//Game1.spriteBatch.Draw(_texture, Position,  null ,Color.White, 0f, Vector2.Zero,0.1f, SpriteEffects.None,0f);
			Game1.spriteBatch.Draw(_texture, Position, Color.White);
			base.Draw(gameTime);
		}


	}

}
