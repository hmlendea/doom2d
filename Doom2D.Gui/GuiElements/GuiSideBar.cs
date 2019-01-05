using NuciXNA.Gui.GuiElements;
using NuciXNA.Input;
using NuciXNA.Primitives;

using Doom2D.GameLogic.GameManagers;
using Doom2D.Settings;

namespace Doom2D.Gui.GuiElements
{
    public class GuiSideBar : GuiElement
    {
        IEntityManager entities;
        IInventoryManager inventory;
        IGameManager game;

        GuiSideBarPanel panel;
        GuiSkillsPanel skillsPanel;
        GuiSideBarInventoryPanel inventoryPanel;
        GuiEquipmentPanel equipmentPanel;

        GuiToggleButton skillsButton;
        GuiToggleButton inventoryButton;
        GuiToggleButton equipmentButton;
        GuiToggleButton exitButton;

        public GuiSideBar(
            IEntityManager entities,
            IInventoryManager inventory,
            IGameManager game)
        {
            this.entities = entities;
            this.inventory = inventory;
            this.game = game;
        }

        public override void LoadContent()
        {
            panel = new GuiSideBarPanel { Size = new Size2D(240, 262) };
            skillsPanel = new GuiSkillsPanel(entities, game)
            {
                Size = new Size2D(190, 262)
            };
            inventoryPanel = new GuiSideBarInventoryPanel(entities, inventory, game)
            {
                Size = new Size2D(190, 262)
            };
            equipmentPanel = new GuiEquipmentPanel(entities, inventory, game)
            {
                Size = new Size2D(190, 262)
            };

            skillsButton = new GuiToggleButton
            {
                ContentFile = "Interface/SideBar/button",
                Icon = "Interface/SideBar/skills_button_icon",
                Size = new Size2D(30, 32)
            };
            inventoryButton = new GuiToggleButton
            {
                ContentFile = "Interface/SideBar/button",
                Icon = "Interface/SideBar/inventory_button_icon",
                Size = new Size2D(30, 32)
            };
            equipmentButton = new GuiToggleButton
            {
                ContentFile = "Interface/SideBar/button",
                Icon = "Interface/SideBar/equipment_button_icon",
                Size = new Size2D(30, 32)
            };
            exitButton = new GuiToggleButton
            {
                ContentFile = "Interface/SideBar/button-full",
                Icon = "Interface/SideBar/exit_button_icon",
                Size = new Size2D(240, 32)
            };

            AddChild(panel);
            AddChild(skillsPanel);
            AddChild(inventoryPanel);
            AddChild(equipmentPanel);

            AddChild(skillsButton);
            AddChild(inventoryButton);
            AddChild(equipmentButton);
            AddChild(exitButton);

            SkillsButton_Clicked(this, null);

            base.LoadContent();
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            exitButton.Location = new Point2D(0, Size.Height - GameDefines.GuiTileSize);
            panel.Location = new Point2D(0, GameDefines.GuiTileSize);

            skillsPanel.Location = new Point2D(panel.Location.X + 25, panel.Location.Y);
            inventoryPanel.Location = skillsPanel.Location;
            equipmentPanel.Location = skillsPanel.Location;

            skillsButton.Location = Point2D.Empty;
            inventoryButton.Location = new Point2D(skillsButton.ClientRectangle.Right, 0);
            equipmentButton.Location = new Point2D(inventoryButton.ClientRectangle.Right, 0);
        }

        protected override void RegisterEvents()
        {
            skillsButton.Clicked += SkillsButton_Clicked;
            inventoryButton.Clicked += InventoryButton_Clicked;
            equipmentButton.Clicked += EquipmentButton_Clicked;
            exitButton.Clicked += ExitButton_Clicked;
        }

        protected override void UnregisterEvents()
        {
            skillsButton.Clicked -= SkillsButton_Clicked;
            inventoryButton.Clicked -= InventoryButton_Clicked;
            equipmentButton.Clicked -= EquipmentButton_Clicked;
            exitButton.Clicked -= ExitButton_Clicked;
        }

        void SkillsButton_Clicked(object sender, MouseButtonEventArgs e)
        {
            UnselectEverything();

            skillsButton.Toggled = true;
            skillsPanel.Show();
        }

        void InventoryButton_Clicked(object sender, MouseButtonEventArgs e)
        {
            UnselectEverything();

            inventoryButton.Toggled = true;
            inventoryPanel.Show();
        }

        void EquipmentButton_Clicked(object sender, MouseButtonEventArgs e)
        {
            UnselectEverything();

            equipmentButton.Toggled = true;
            equipmentPanel.Show();
        }

        void ExitButton_Clicked(object sender, MouseButtonEventArgs e)
        {
            UnselectEverything();

            exitButton.Toggled = true;
        }

        void UnselectEverything()
        {
            skillsButton.Toggled = false;
            inventoryButton.Toggled = false;
            equipmentButton.Toggled = false;
            exitButton.Toggled = false;

            skillsPanel.Hide();
            inventoryPanel.Hide();
            equipmentPanel.Hide();
        }
    }
}
