using NuciXNA.Graphics.Drawing;
using NuciXNA.Gui.GuiElements;
using NuciXNA.Input;
using NuciXNA.Primitives;

//using Craftico.Audio;
using Doom2D.Settings;

namespace Doom2D.Gui.GuiElements
{
    /// <summary>
    /// Button GUI element.
    /// </summary>
    public class GuiButton : GuiElement
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        public string Icon { get; set; }

        public string ContentFile { get; set; }

        protected GuiImage background;
        protected GuiImage icon;
        protected GuiText text;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuiButton"/> class.
        /// </summary>
        public GuiButton()
        {
            FontName = "ButtonFont";
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public override void LoadContent()
        {
            background = new GuiImage
            {
                ContentFile = ContentFile
            };
            icon = new GuiImage
            {
                ContentFile = Icon,
                Size = new Size2D(GameDefines.GuiTileSize, GameDefines.GuiTileSize)
            };
            text = new GuiText();

            base.LoadContent();
        }

        protected override void RegisterChildren()
        {
            base.RegisterChildren();

            AddChild(background);
            AddChild(icon);
            AddChild(text);
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            if (!Hovered)
            {
                background.SourceRectangle = new Rectangle2D(0, 0, Size.Width, Size.Height);
            }
            else
            {
                background.SourceRectangle = new Rectangle2D(Size.Width, 0, Size.Width, Size.Height);
            }

            icon.Location = new Point2D((Size - icon.Size) / 2);

            text.Text = Text;
        }

        /// <summary>
        /// Fired by the Clicked event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        protected override void OnClicked(object sender, MouseButtonEventArgs e)
        {
            base.OnClicked(sender, e);

            if (e.Button != MouseButton.LeftButton)
            {
                return;
            }

            //AudioManager.Instance.PlaySound("Interface/click");
        }

        /// <summary>
        /// Fired by the MouseMoved event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        protected override void OnMouseEntered(object sender, MouseEventArgs e)
        {
            base.OnMouseMoved(sender, e);

            //AudioManager.Instance.PlaySound("Interface/select");
        }
    }
}
