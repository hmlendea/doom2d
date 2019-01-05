using Microsoft.Xna.Framework;
using NuciXNA.Gui.Screens;
using NuciXNA.Primitives;

using Doom2D.Settings;

namespace Doom2D.Gui
{
    public class Camera
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public PointF2D Location { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size2D Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Camera"/> class.
        /// </summary>
        public Camera()
        {
            Location = PointF2D.Empty;

            // TODO: Give it it's proper size once the game HUD is implemented
            Size = new Size2D(
                ScreenManager.Instance.Size.Width / GameDefines.MapTileSize + 2,
                ScreenManager.Instance.Size.Height / GameDefines.MapTileSize + 2);
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {

        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {

        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {

        }

        public void CentreOnLocation(PointF2D location)
        {
            Location = new PointF2D(
                location.X - Size.Width / 2,
                location.Y - Size.Height / 2);
        }
    }
}
