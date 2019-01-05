using NuciXNA.Gui.GuiElements;

namespace Doom2D.Gui.GuiElements
{
    public class GuiSideBarPanel : GuiElement
    {
        GuiImage background;

        public override void LoadContent()
        {
            background = new GuiImage
            {
                ContentFile = "Interface/SideBar/panel"
            };

            AddChild(background);

            base.LoadContent();
        }
    }
}
