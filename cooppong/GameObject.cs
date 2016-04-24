using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cooppong
{
	public class GameObject : DrawableGameComponent
	{
		private Vector2 _position;
		private Texture2D _texture;

		// PROPERTIES

		public Texture2D Texture
		{
			get { return _texture; }
			set { _texture = value; }
		}

		public Vector2 Position
		{
			get { return _position; }
			set { _position = value; }
		}

		public Rectangle BoundingBox
		{
			get
			{
				return new Rectangle(
					(int)Position.X,
					(int)Position.Y,
					Texture.Width,
					Texture.Height
				);
			}
		}

		public GameObject (Game game, Vector2 position)
			: base(game)
		{
			Game.Components.Add(this);
			_position = position;


		}

		public override void Draw(GameTime gameTime)
		{

			Game1.spriteBatch.Draw(_texture, _position, Color.White);
			base.Draw(gameTime);
		}

		public new void Dispose(bool disposing)
		{
			Game.Components.Remove(this);


			// Game1.spriteBatch.Draw(_texture, _position, BoundingBox, Color.White);
			base.Dispose(disposing);

		}
	}
}
