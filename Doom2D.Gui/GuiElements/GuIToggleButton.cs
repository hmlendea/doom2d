using NuciXNA.Primitives;

namespace Doom2D.Gui.GuiElements
{
    public class GuiToggleButton : GuiButton
    {
        public bool Toggled { get; set; }

        public Colour ToggleColour { get; set; }

        public GuiToggleButton()
        {
            ToggleColour = Colour.DarkRed;
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            if (Toggled)
            {
                background.TintColour = ToggleColour;
            }
            else
            {
                background.TintColour = Colour.White;
            }
        }
    }
}
