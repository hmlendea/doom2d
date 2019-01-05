using System;

using NuciXNA.Primitives;
using NuciXNA.Graphics.Drawing;
using NuciXNA.Gui.GuiElements;
using NuciXNA.Input;

namespace Doom2D.Gui.GuiElements
{
    public class GuiSkillCard : GuiElement
    {
        GuiImage regularBackground;
        GuiImage detailsBackground;
        GuiImage skillIcon;

        GuiText currentLevelText;
        GuiText baseLevelText;
        GuiText detailsText;

        public string SkillIcon { get; set; }

        public int CurrentLevel { get; set; }

        public int BaseLevel { get; set; }

        public int Experience { get; set; }

        public string SkillDetails { get; set; }

        public GuiSkillCard()
        {
            Size = new Size2D(60, 32);
        }

        public override void LoadContent()
        {
            regularBackground = new GuiImage { ContentFile = "Interface/skillcard" };
            detailsBackground = new GuiImage { ContentFile = "Interface/skillcard_details" };
            skillIcon = new GuiImage { Size = new Size2D(26, 26) };

            currentLevelText = new GuiText
            {
                FontName = "SkillCardFont",
                FontOutline = FontOutline.BottomRight,
                Size = new Size2D(12, 10),
                ForegroundColour = Colour.Yellow
            };
            baseLevelText = new GuiText
            {
                FontName = "SkillCardFont",
                FontOutline = FontOutline.BottomRight,
                Size = new Size2D(12, 10),
                ForegroundColour = Colour.Yellow
            };
            detailsText = new GuiText
            {
                FontName = "SkillCardFont",
                ForegroundColour = Colour.Yellow
            };

            AddChild(regularBackground);
            AddChild(detailsBackground);
            AddChild(skillIcon);

            AddChild(currentLevelText);
            AddChild(baseLevelText);
            AddChild(detailsText);

            detailsBackground.Visible = false;
            detailsText.Visible = false;

            base.LoadContent();
        }

        protected override void SetChildrenProperties()
        {
            skillIcon.Location = new Point2D(5, 5);
            skillIcon.ContentFile = SkillIcon;

            currentLevelText.Text = CurrentLevel.ToString();
            currentLevelText.Location = new Point2D(32, 4);

            baseLevelText.Text = BaseLevel.ToString();
            baseLevelText.Location = new Point2D(44, 16);

            detailsText.Text = $"Xp:{Environment.NewLine}{Experience}";

            base.SetChildrenProperties();
        }

        protected override void OnMouseEntered(object sender, MouseEventArgs e)
        {
            base.OnMouseEntered(sender, e);

            regularBackground.Hide();
            skillIcon.Hide();
            currentLevelText.Hide();
            baseLevelText.Hide();

            detailsBackground.Show();
            detailsText.Show();
        }

        protected override void OnMouseLeft(object sender, MouseEventArgs e)
        {
            base.OnMouseLeft(sender, e);

            regularBackground.Show();
            skillIcon.Show();
            currentLevelText.Show();
            baseLevelText.Show();

            detailsBackground.Hide();
            detailsText.Hide();
        }
    }
}
