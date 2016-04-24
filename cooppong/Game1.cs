#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace cooppong
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		//paddles

		private Paddle Paddle1;
		private Paddle Paddle2;

		private Paddle AiPaddle1;
		private Paddle AiPaddle2;
		//ball
		private Ball ball;
		//tracking ball for AI
		//private AiBall AiBall;
		protected float Scale;

		private Ai Ai;
		private Players players;


		public static SpriteBatch spriteBatch;
		private Texture2D background;

		public Game1 ()
			: base()
		{
			this.IsMouseVisible = true;

			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.ApplyChanges();
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			graphics.IsFullScreen = true;
		graphics.PreferredBackBufferWidth = 750;  // set this value to the desired width of your window
		graphics.PreferredBackBufferHeight = 550; 
			graphics.ApplyChanges();
			// TODO: Add your initialization logic here
			ball = new Ball(this);
		//	AiBall = new AiBall (this);
			//float Scale = GraphicsDevice.Viewport.Height / 10 * 9;
			Paddle1 = new Paddle(this);

			Paddle2 = new Paddle(this);
		

			AiPaddle1 = new Paddle (this);


			AiPaddle2 = new Paddle (this);
		

			players = new Players(this, Paddle1, Paddle2);
			players.SetPaddle(Paddle1, Paddle2);

			Ai = new Ai (this, AiPaddle1, AiPaddle2);
			Ai.SetPaddle (AiPaddle1, AiPaddle2);
//			graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
//			graphics.PreferredBackBufferHeight = 600; 

			base.Initialize ();

				
		}
			
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);
			Paddle1.texture = Content.Load<Texture2D>("Greenbat");
			Paddle1.Position = new Vector2((GraphicsDevice.Viewport.Width / 2)- (Paddle1.texture.Width / 2), GraphicsDevice.Viewport.Height / 10);

			Paddle2.texture = Content.Load<Texture2D>("Pinkbat");
			Paddle2.Position = new Vector2((GraphicsDevice.Viewport.Width /2)- (Paddle2.texture.Width / 2), GraphicsDevice.Viewport.Height / 10 * 9);

			AiPaddle1.texture = Content.Load<Texture2D> ("Redbat");
			AiPaddle1.Position = new Vector2 ( GraphicsDevice.Viewport.Width / 10, (GraphicsDevice.Viewport.Height / 2 )- AiPaddle1.texture.Height / 2);
			//TODO: use this.Content to load your game content here 
			AiPaddle2.texture = Content.Load<Texture2D> ("Redbat");
			AiPaddle2.Position = new Vector2 ((GraphicsDevice.Viewport.Width / 10 )* 9, (GraphicsDevice.Viewport.Height / 2)- AiPaddle1.texture.Height / 2);

			background = Content.Load<Texture2D>("Bluegrid");

		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{

			AiMovement ();



			Paddlehit ();

	
			if (ball._speed.X > 40 && ball._speed.Y > 40)
			{
				ball._speed = new Vector2(40,40);

			}



			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			#endif

			// The time since Update was called last.
			float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

			// TODO: Add your game logic here.
			Scale += elapsed;
			Scale = Scale % 6;
					// The time since Update was called last.
//					float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

				// TODO: Add your game logic here.
//				scale += elapsed;
//				scale = scale % 6;

				


			base.Update (gameTime);
		}


		public void Paddlehit() {
			if ((Paddle1.Bounds.Intersects (ball.Bounds)) || (Paddle2.Bounds.Intersects (ball.Bounds))) {
				if (ball._speed.Y < 0) {
					ball._speed.X = ball._speed.X *  2/ 16 * 9;
					ball._speed.Y *= -1;
				}
				else if (ball._speed.Y > 0) {
					ball._speed.X = ball._speed.X * 2 / 16 *9;
					ball._speed.Y *= -1;
				}
			}

			if ((AiPaddle1.Bounds.Intersects (ball.Bounds)) || (AiPaddle2.Bounds.Intersects (ball.Bounds))) {
				if (ball._speed.X < 0) {
					ball._speed.Y = ball._speed.Y * 2 /16 *9;
					ball._speed.X *= -1;
				}
				else if (ball._speed.X > 0) {
					ball._speed.Y = ball._speed.Y * 2 /16 *9;
					ball._speed.X *= -1;
				}
			}
		}

		public void AiMovement() {
			if ((ball.Position.Y - AiPaddle1.texture.Height/2 > AiPaddle1.Position.Y) && (ball.Position.X < GraphicsDevice.Viewport.Width / 2)) {
				AiPaddle1.moveUp ();
			}

			if ((ball.Position.Y - AiPaddle1.texture.Height/2 < AiPaddle1.Position.Y) && (ball.Position.X < GraphicsDevice.Viewport.Width / 2)) {
				AiPaddle1.moveDown ();
			}
			if ((ball.Position.Y - AiPaddle2.texture.Height/2 > AiPaddle2.Position.Y) && (ball.Position.X > GraphicsDevice.Viewport.Width / 2)) {
				AiPaddle2.moveUp ();
			}

			if ((ball.Position.Y - AiPaddle2.texture.Height/2 < AiPaddle2.Position.Y) && (ball.Position.X > GraphicsDevice.Viewport.Width / 2)) {
				AiPaddle2.moveDown ();
			}
		}
		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			//TODO: Add your drawing code here
			spriteBatch.Begin ();
			spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
		//	spriteBatch.Draw (movinggrid, new Rectangle(gridX, gridY, 2920, 1840), Color.White);
			base.Draw (gameTime);
			spriteBatch.End ();
		}
	}
}

