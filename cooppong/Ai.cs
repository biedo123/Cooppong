using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cooppong
{
	class Ai : DrawableGameComponent
	{
		private Paddle _Aipaddle1;
		private Paddle _Aipaddle2;

		public Ai(Game game, Paddle Aipaddle1, Paddle Aipaddle2)
			: base(game)
		{
			_Aipaddle1 = Aipaddle1;
			_Aipaddle2 = Aipaddle2;

			Game.Components.Add(this);
		}
			
		public override void Update(GameTime gameTime)
		{
//			MouseState mouseState = Mouse.GetState();
//
//			if(mouseState.LeftButton == ButtonState.Pressed)
//			{
//				if ((_Aipaddle1.Position.Y  < Ball) && (_Aipaddle1.Position.Y + 200 > mouseState.Y))
//				{
//					_Aipaddle1.moveUp();
//				}
//				// Do whatever you want here
//				else if ((_Aipaddle1.Position.X + 280 < mouseState.X) && (_Aipaddle1.Position.Y + 200 > mouseState.Y)){
//					_Aipaddle1.moveDown();
//				}
//				//	
//
//				else if ((_Aipaddle2.Position.X + 140 > mouseState.X) && (_Aipaddle2.Position.Y - 125 < mouseState.Y)){
//					_Aipaddle2.moveUp();
//				}
//				else if ((_Aipaddle2.Position.X + 280 < mouseState.X) && (_Aipaddle2.Position.Y - 125 < mouseState.Y)){
//					_Aipaddle2.moveDown();
//				}
//			}
				
			base.Update(gameTime);
			//    


		}
		public void SetPaddle(Paddle AiPaddle1, Paddle AiPaddle2)
		{
			_Aipaddle1 = AiPaddle1;
			_Aipaddle2 = AiPaddle2;
		}


	}
}

