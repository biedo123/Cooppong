using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;

namespace cooppong
{
	class Players : DrawableGameComponent
	{
		private Paddle _paddle1;
		private Paddle _paddle2;
		private SpriteFont _Neon;
		private String scoreshow;
		public Players(Game game, Paddle paddle1, Paddle paddle2)
			: base(game)
		{
			_paddle1 = paddle1;
			_paddle2 = paddle2;

			Game.Components.Add(this);
		}



		protected override void LoadContent()
		{
			_Neon = Game.Content.Load<SpriteFont>("Verdana35Regular");

			base.LoadContent();
		}
		public override void Update(GameTime gameTime)
		{
			MouseState mouseState = Mouse.GetState();
			scoreshow = mouseState.X.ToString () + mouseState.Y.ToString () + mouseState.Position.X;
//			if(mouseState.LeftButton == ButtonState.Pressed)
//			{
			if ((_paddle1.Position.X + (_paddle1.texture.Width/2) > mouseState.X) && (_paddle1.Position.Y + 200 > mouseState.Y) || (mouseState.LeftButton == ButtonState.Pressed) || (mouseState.RightButton == ButtonState.Pressed))
				{
					_paddle1.moveleft();
				}
				// Do whatever you want here
			else if ((_paddle1.Position.X + (_paddle1.texture.Width/2) < mouseState.X) && (_paddle1.Position.Y + 200 > mouseState.Y)){
					_paddle1.moveright();
				}
//	

			else if ((_paddle2.Position.X + (_paddle2.texture.Width/2) > mouseState.X) && (_paddle2.Position.Y - 200 < mouseState.Y)){
					_paddle2.moveleft();
				}
			else if ((_paddle2.Position.X + (_paddle2.texture.Width/2) < mouseState.X) && (_paddle2.Position.Y - 200 < mouseState.Y)){
					_paddle2.moveright();
				}
//			}

			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				_paddle2.moveleft();
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				_paddle2.moveright();
			}

			base.Update(gameTime);
			//    
		
		}
		public void SetPaddle(Paddle paddle1, Paddle paddle2)
		{
			_paddle1 = paddle1;
			_paddle2 = paddle2;
		}
		public override void Draw(GameTime gameTime)
		{
			//Game1.spriteBatch.DrawString(_Neon, scoreshow, new Vector2(0,0), Color.White);
			//Game1.spriteBatch.DrawString(_Neon, scoreshow, new Vector2((GraphicsDevice.Viewport.Width / 4) , 150), Color.White, 22, new Vector2(0,0), 0 ,0, 0);
			base.Draw(gameTime);
		}

	

	}
}
	
