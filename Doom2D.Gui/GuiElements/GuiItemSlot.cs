using Microsoft.Xna.Framework;

using NuciXNA.Graphics.Drawing;
using NuciXNA.Gui.GuiElements;
using NuciXNA.Input;
using NuciXNA.Primitives;

using Doom2D.GameLogic.GameManagers;
using Doom2D.Gui.SpriteEffects;
using Doom2D.Models;

namespace Doom2D.Gui.GuiElements
{
    public class GuiItemSlot : GuiElement
    {
        const int SpriteRows = 32;
        const int SpriteColumns = 32;

        // TODO: Find a way around this
        const string BlankPlaceholder = "placeholder-blank";

        readonly IEntityManager entities;

        GuiImage background;
        GuiImage icon;
        GuiImage placeholderIcon;
        GuiText quantity;

        Colour highlightColour = new Colour(192, 180, 180);

        public string PlaceholderIcon { get; set; }

        public string ItemId { get; set; }

        public bool IsEmpty => string.IsNullOrWhiteSpace(ItemId);

        public int Quantity { get; set; }

        public GuiItemSlot(IEntityManager entities)
        {
            this.entities = entities;

            PlaceholderIcon = BlankPlaceholder;

            ForegroundColour = Colour.Gold;
            Size = new Size2D(36, 36);
        }

        public override void LoadContent()
        {
            background = new GuiImage
            {
                SourceRectangle = new Rectangle2D(0, 0, 36, 36),
                ContentFile = "Interface/Inventory/slot",
                SpriteSheetEffect = new ButtonSpriteSheetEffect(),
                EffectsActive = true
            };
            icon = new GuiImage
            {
                Size = new Size2D(32, 32)
            };
            placeholderIcon = new GuiImage
            {
                Size = icon.Size
            };
            quantity = new GuiText
            {
                Location = new Point2D(2, 2),
                Size = new Size2D(Size.Width - 2, 10),
                FontName = "ItemCardFont",
                FontOutline = FontOutline.BottomRight,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };

            AddChild(background);
            AddChild(icon);
            AddChild(placeholderIcon);
            AddChild(quantity);

            base.LoadContent();

            background.SpriteSheetEffect.Activate();
        }

        public override void Update(GameTime gameTime)
        {
            icon.Visible = Quantity > 0;
            quantity.Visible = Quantity > 1;

            base.Update(gameTime);
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            if (IsEmpty)
            {
                icon.ContentFile = $"Icons/Items/none";
            }
            else
            {
                Item item = entities.GetItem(ItemId);
                icon.ContentFile = $"Icons/Items/{item.SpriteSheet}";
            }

            icon.Location = new Point2D(
                (Size.Width - icon.Size.Width) / 2,
                (Size.Height - icon.Size.Height) / 2);

            placeholderIcon.ContentFile = $"Interface/Inventory/{PlaceholderIcon}";
            placeholderIcon.Location = icon.Location;

            quantity.Text = Quantity.ToString();

            if (!IsEmpty)
            {
                icon.Show();
                placeholderIcon.Hide();
            }
            else if (PlaceholderIcon != BlankPlaceholder)
            {
                icon.Hide();
                placeholderIcon.Show();
            }
            else
            {
                icon.Hide();
                placeholderIcon.Hide();
            }

            if (IsEmpty)
            {
                background.SpriteSheetEffect.Deactivate();
                background.EffectsActive = false;
            }
            else
            {
                background.SpriteSheetEffect.Activate();
                background.EffectsActive = true;
            }
        }
    }
}
