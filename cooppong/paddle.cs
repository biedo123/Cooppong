using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cooppong
{
	class Paddle: DrawableGameComponent
	{
		public Vector2 Position{get;set;}
	
		private Vector2 _speed;
		public Texture2D texture{get;set;}
		public float scale{ get; set; }

		public Rectangle Bounds
		{
			get { return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }
		}

		public Paddle(Game game)
			: base(game)
		{
			Game.Components.Add(this);
		}
		protected override void LoadContent()
		{
			_speed = new Vector2(4,3);
	
			base.LoadContent();
		}

		public void moveleft() {
			Position = new Vector2 (Position.X - _speed.X, Position.Y);
		}


		public void moveright() {
			Position = new Vector2 (Position.X + _speed.X , Position.Y);
		}
		public void moveUp(){
			Position = new Vector2 (Position.X, Position.Y + _speed.Y);
		}
		public void moveDown(){
			Position = new Vector2 (Position.X, Position.Y - _speed.Y);
		}

		public override void Update(GameTime gameTime){
			base.Update(gameTime);
		}



		public override void Draw(GameTime gameTime)
		{
			Game1.spriteBatch.Draw(texture, Position, Color.White  );
			base.Draw(gameTime);
		}
	}
}

