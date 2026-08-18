using System.Reflection;
using Menu.Classes;
using Menu.Mods;
using static Menu.Menu.Main;
using Menu.Settings;
using Pathfinding.RVO;
namespace Menu.Menu
{
    public class Buttons
    {
        /*
         * Here is where all of your buttons are located.
         * To create a button, you may use the following code:
         * 
         * Move to Category:
         *   new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opens the main settings page for the menu."},
         *   new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
         * 
         * Togglable Mod:
         *   new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
         *   
         * Making mods enabled by default:
         *  new ButtonInfo { buttonText = "Gunlib Fix", method =() => currentCategory = 0, isTogglable = true, toolTip = "Fixes issue With IItemp Gunlib not disabling", enabled = true },
         */

        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opens the main settings page for the menu."},

                new ButtonInfo { buttonText = "Room Mods", method =() => currentCategory = 4, isTogglable = false, toolTip = "Opens the room mods tab."},
                new ButtonInfo { buttonText = "Movement Mods", method =() => currentCategory = 5, isTogglable = false, toolTip = "Opens the movement mods tab."},
                new ButtonInfo { buttonText = "Safety Mods", method =() => currentCategory = 6, isTogglable = false, toolTip = "Opens the safety mods tab."},
                new ButtonInfo { buttonText = "Visual Mods", method =() => currentCategory = 8, isTogglable = false, toolTip = "Opens the visual mods tab."},
                new ButtonInfo { buttonText = "Overpowered Mods", method =() => currentCategory = 9, isTogglable = false, toolTip = "Opens the overpowered mods tab."},
                new ButtonInfo { buttonText = "Advantage Mods", method =() => currentCategory = 10, isTogglable = false, toolTip = "Opens the advantage mods tab."},
                new ButtonInfo { buttonText = "Other Mods", method =() => currentCategory = 7, isTogglable = false, toolTip = "Opens the other mods tab."},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => currentCategory = 2, isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => currentCategory = 3, isTogglable = false, toolTip = "Opens the movement settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => MenuSettings.rightHanded = true, disableMethod =() => MenuSettings.rightHanded = false, toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => MenuSettings.disableNotifications = false, disableMethod =() => MenuSettings.disableNotifications = true, enabled = MenuSettings.disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => MenuSettings.fpsCounter = true, disableMethod =() => MenuSettings.fpsCounter = false, enabled = MenuSettings.fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => MenuSettings.disconnectButton = true, disableMethod =() => MenuSettings.disconnectButton = false, enabled = MenuSettings.disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},

                new ButtonInfo { buttonText = "Change Fly Speed", overlapText = "Change Fly Speed [Normal]", method =() => Mods.MenuMovement.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the speed of the fly mod."},
            },

            new ButtonInfo[] { // Room Mods [4]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Disconnect", method =() => NetworkSystem.Instance.ReturnToSinglePlayer(), isTogglable = false, toolTip = "Disconnects you from the room."},
            },

            new ButtonInfo[] { // Movement Mods [5]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Platforms", method =() => MenuMovement.Platforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
                new ButtonInfo { buttonText = "Fly", method =() => MenuMovement.Fly(), toolTip = "Sends you forward when holding A."},
                new ButtonInfo { buttonText = "Teleport Gun", method =() => MenuMovement.TeleportGun(), toolTip = "Teleports you to wherever your pointer is when pressing trigger."},
                new ButtonInfo { buttonText = "WASD fly", method =() => MenuMovement.WASDFly(), toolTip = "Allows you to fly with WASD"}
            },

            new ButtonInfo[] { // Safety Mods [6]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Anti Report", method =() => Safety.AntiReportDisconnect(), toolTip = "Disconnects you when someone tries to report you."}, // all roads lead to report bans

                new ButtonInfo { buttonText = "Flush RPCs", method =() => Safety.Flushrpc(), toolTip = "Flushes all RPCs to prevent RPC spam."},
            },

            new ButtonInfo[] { // Other [7]
                new ButtonInfo { buttonText = "Return To Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns you to the main page of the menu."},
                new ButtonInfo { buttonText = "Gunlib Fix", method =() => currentCategory = 0, isTogglable = true, toolTip = "Fixes issue With IItemp Gunlib not disabling", enabled = true },
            },
            new ButtonInfo[] { // Visual Mods [8]
                new ButtonInfo { buttonText = "Return To Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns you to the main page of the menu."},
            },

            new ButtonInfo[] { // Overpowered Mods [9]
                new ButtonInfo { buttonText = "GetNameGun", method =() => Overpowered.FireGunAtPlayer(), toolTip = "Gets the name of the player you are pointing at."},
                new ButtonInfo { buttonText = "Instant Tag Gun", method =() => Overpowered.InstantTagGun(), toolTip = "Teleports you to the player you are pointing at when pressing trigger."},
                new ButtonInfo { buttonText = "Return To Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns you to the main page of the menu."},
            },

            new ButtonInfo[] { //Advantage Mods [10]
                new ButtonInfo { buttonText = "Return To Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns you to the main page of the menu."},
            },
        };
    }
}
