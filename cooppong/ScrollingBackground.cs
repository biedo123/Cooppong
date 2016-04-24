using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
namespace cooppong
{
	 class ScrollingBackground  : DrawableGameComponent
	{
		 ScrollingBackground ()
		{
			private Vector2 screenpos, origin, texturesize;
			private Texture2D mytexture;
			private int screenheight;
			public void Load( GraphicsDevice device, Texture2D backgroundTexture )
			{
				mytexture = backgroundTexture;
				screenheight = GraphicsDevice.Viewport.Height;
				int screenwidth = GraphicsDevice.Viewport.Width;
				// Set the origin so that we're drawing from the 
				// center of the top edge.
				origin = new Vector2( mytexture.Width / 2, 0 );
				// Set the screen position to the center of the screen.
				screenpos = new Vector2( screenwidth / 2, screenheight / 2 );
				// Offset to draw the second texture, when necessary.
				texturesize = new Vector2( 0, mytexture.Height );
			}
		}
	}
}

