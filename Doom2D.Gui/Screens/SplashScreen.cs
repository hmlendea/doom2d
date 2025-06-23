using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NuciXNA.Gui;
using NuciXNA.Gui.Controls;
using NuciXNA.Gui.Screens;
using NuciXNA.Input;
using NuciXNA.Primitives;

namespace Doom2D.Gui.Screens
{
    /// <summary>
    /// Splash screen.
    /// </summary>
    public class SplashScreen : Screen
    {
        /// <summary>
        /// Gets or sets the delay.
        /// </summary>
        /// <value>The delay.</value>
        public float Delay { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        public GuiImage LogoImage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
        {
            Delay = 3;
            BackgroundColour = Colour.Black;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        protected override void DoLoadContent()
        {
            LogoImage = new GuiImage { ContentFile = "SplashScreen/Logo" };

            GuiManager.Instance.RegisterControls(LogoImage);

            InputManager.Instance.KeyboardKeyPressed += OnInputManagerKeyboardKeyPressed;
            InputManager.Instance.MouseButtonPressed += OnInputManagerMouseButtonPressed;

            SetChildrenProperties();
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        protected override void DoUnloadContent()
        {
            InputManager.Instance.KeyboardKeyPressed -= OnInputManagerKeyboardKeyPressed;
            InputManager.Instance.MouseButtonPressed -= OnInputManagerMouseButtonPressed;
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        protected override void DoUpdate(GameTime gameTime)
        {
            Delay -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            SetChildrenProperties();
        }

        /// <summary>
        /// Draw the content on the specified spriteBatch.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        protected override void DoDraw(SpriteBatch spriteBatch) { }

        void SetChildrenProperties() => LogoImage.Location = new Point2D(
            (ScreenManager.Instance.Size.Width - LogoImage.Size.Width) / 2,
            (ScreenManager.Instance.Size.Height - LogoImage.Size.Height) / 2);

        void OnInputManagerKeyboardKeyPressed(object sender, KeyboardKeyEventArgs e) => ChangeScreen();

        void OnInputManagerMouseButtonPressed(object sender, MouseButtonEventArgs e) => ChangeScreen();

        static void ChangeScreen() => ScreenManager.Instance.ChangeScreens<GameplayScreen>();
    }
}
