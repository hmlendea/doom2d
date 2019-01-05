using NuciXNA.Gui.GuiElements;
using NuciXNA.Primitives;

using Doom2D.GameLogic.GameManagers;
using Doom2D.Models;

namespace Doom2D.Gui.GuiElements
{
    public class GuiSkillsPanel : GuiElement
    {
        readonly IEntityManager entities;
        readonly IGameManager game;

        Mob player;

        GuiSkillCard hitpointsCard;
        GuiSkillCard faithCard;

        public GuiSkillsPanel(
            IEntityManager entities,
            IGameManager game)
        {
            this.entities = entities;
            this.game = game;
        }

        public override void LoadContent()
        {
            hitpointsCard = new GuiSkillCard { SkillIcon = "Icons/Skills/vigour" };
            faithCard = new GuiSkillCard { SkillIcon = "Icons/Skills/faith" };

            AddChild(hitpointsCard);
            AddChild(faithCard);

            player = entities.GetPlayer();

            base.LoadContent();
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            int spacingX = 1;

            // TODO: Ugly fix
            if (game == null)
            {
                return;
            }

            hitpointsCard.CurrentLevel = player.Vigour.CurrentLevel;
            hitpointsCard.BaseLevel = player.Vigour.BaseLevel;
            hitpointsCard.Experience = player.Vigour.Experience;
            hitpointsCard.Location = new Point2D(
                Location.X + (Size.Width - 3 * hitpointsCard.Size.Width - 2 * spacingX) / 2,
                Location.Y + (Size.Width - 3 * hitpointsCard.Size.Width - 2 * spacingX) / 2);

            faithCard.CurrentLevel = player.Faith.CurrentLevel;
            faithCard.BaseLevel = player.Faith.BaseLevel;
            faithCard.Experience = player.Faith.Experience;
            faithCard.Location = new Point2D(
                hitpointsCard.ClientRectangle.Right + spacingX,
                hitpointsCard.ClientRectangle.Top);
        }
    }
}
