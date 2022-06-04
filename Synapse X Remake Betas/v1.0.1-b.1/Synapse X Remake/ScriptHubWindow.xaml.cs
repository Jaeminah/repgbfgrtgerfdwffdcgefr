using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WeAreDevs_API;

namespace Synapse_X_Remake
{
    /// <summary>
    /// Interaction logic for ScriptHubWindow.xaml
    /// </summary>
    public partial class ScriptHubWindow : Window
    {

        ExploitAPI module = new ExploitAPI();

        public ScriptHubWindow()
        {
            InitializeComponent();
        }
        private void DexV2_Selected(object sender, RoutedEventArgs e)
        {
            DescriptionBox.Text = "A powerful game explorer GUI. Shows every instance of the game and all their properties. Useful for developers.";
        }

        private void ESP_Selected(object sender, RoutedEventArgs e)
        {
            DescriptionBox.Text = "Simple ESP Works on any games.";
        }

        private void InfiniteYield_Selected(object sender, RoutedEventArgs e)
        {
            DescriptionBox.Text = "Best admin script works on all FE games.";
        }

        private void Reviz_Selected(object sender, RoutedEventArgs e)
        {
            DescriptionBox.Text = "Best admin script works on all FE and FD games.";
        }

        private void Btools_Selected(object sender, RoutedEventArgs e)
        {
            DescriptionBox.Text = "Allows you to edit the world.";
        }

        private void SimpleExplorer_Selected(object sender, RoutedEventArgs e)
        {
            DescriptionBox.Text = "Similar to Dex explorer but much faster and better for free exploits.";
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DexExplorer.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Dex Explorer.txt");
                module.SendLimitedLuaScript(script);
            }
            if (Fly.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Fly.txt");
                module.SendLimitedLuaScript(script);
            }

            if (Aimbot.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/WRD Aimbot.txt");
                module.SendLimitedLuaScript(script);
            }

            if (GravitySwitch.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Gravity Switch.txt");
                module.SendLimitedLuaScript(script);
            }

            if (AntiAFK.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/anti-afk via autofocus.txt");
                module.SendLimitedLuaScript(script);
            }

            if (DemonfallTrainer.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Demonfall Trainer.txt");
                module.SendLimitedLuaScript(script);
            }

            if (phatomForcesHitBox.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Demonfall Trainer.txt");
                module.SendLimitedLuaScript(script);
            }

            if (TimberAutoFarm.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Timber! Autofarm.txt");
                module.SendLimitedLuaScript(script);
            }

            if (Apoc2Map.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Apoc2 Map Radar.txt");
                module.SendLimitedLuaScript(script);
            }

            if (WorldZeroKillAura.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/WZKillAura.txt");
                module.SendLimitedLuaScript(script);
            }

            if (CriticalStrikeGUI.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Critical Strike GUI.txt");
                module.SendLimitedLuaScript(script);
            }

            if (PFEasyFly.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/PF Easy Fly.txt");
                module.SendLimitedLuaScript(script);
            }

            if (RoCitizenInfiniteMoney.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/RoCitizens Infinite Money.txt");
                module.SendLimitedLuaScript(script);
            }

            if (ClickTP.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Click Teleport.txt");
                module.SendLimitedLuaScript(script);
            }

            if (UniversalESPandAimbot.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Universal ESP + Aimbot.txt");
                module.SendLimitedLuaScript(script);
            }

            if (WRDESP.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/WRD ESP.txt");
                module.SendLimitedLuaScript(script);
            }

            if (EzHub.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Ez Hub.txt");
                module.SendLimitedLuaScript(script);
            }

            if (OwlHub.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/OwlHub.txt");
                module.SendLimitedLuaScript(script);
            }

            if (InfiniteJump.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Infinite Jump.txt");
                module.SendLimitedLuaScript(script);
            }

            if (InfiniteYield.IsSelected)
            {
                string script = File.ReadAllText("./bin/script-hub/Infinite Yield.txt");
                module.SendLimitedLuaScript(script);
            }
        }

        private void DexExplorer_Selected(object sender, RoutedEventArgs e)
        {
            string description = "A powerful game explorer GUI. Shows every instance of the game and all their properties. Useful for developers.";
            DescriptionBox.Text = description;

        }

        private void Fly_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Why walk when you can fly?";
            DescriptionBox.Text = description;
        }

        private void Aimbot_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Snaps aim to player heads. Featuring wall detection, team check, and mouse movement bypass.";
            DescriptionBox.Text = description;
        }

        private void GravitySwitch_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Press e to toggle the game's gravity.";
            DescriptionBox.Text = description;
        }

        private void AntiAFK_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Even when you switch to another window, you will appear to be active.";
            DescriptionBox.Text = description;

        }

        private void DemonfallTrainer_Selected(object sender, RoutedEventArgs e)
        {

            string description = "A Demonfall trainer featuring a mob ESP, auto breath, god mode, anti-debuffs, and trinket farm.";
            DescriptionBox.Text = description;

        }

        private void phatomForcesHitBox_Selected(object sender, RoutedEventArgs e)
        {

            string description = "Makes enemies easier to hit by enlarging their hitbox.";
            DescriptionBox.Text = description;

        }

        private void TimberAutoFarm_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Slowly, but surely automatically farms in the game Timber.";
            DescriptionBox.Text = description;
        }

        private void Apoc2Map_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Slowly, but surely automatically farms in the game Timber.";
            DescriptionBox.Text = description;
        }

        private void WorldZeroKillAura_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Adds a kill aura for the game, World // Zero.";
            DescriptionBox.Text = description;
        }

        private void CriticalStrikeGUI_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Displays a cheat trainer to use for the game, Critical Strike.";
            DescriptionBox.Text = description;
        }

        private void PFEasyFly_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Enables you to fly through the game, Phantom Forces.";
            DescriptionBox.Text = description;
        }

        private void RoCitizenInfiniteMoney_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Drown in cash while playing RoCitizens.";
            DescriptionBox.Text = description;
        }

        private void ClickTP_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Left ctrl + click on any spot on the game and you will immediately teleport to it!";
            DescriptionBox.Text = description;

        }

        private void UniversalESPandAimbot_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Introduces an ESP and aimbot for all games.";
            DescriptionBox.Text = description;

        }

        private void WRDESP_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Draws boxes around other players.";
            DescriptionBox.Text = description;
        }

        private void EzHub_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Multi-game script hub with a beautifully made UI.";
            DescriptionBox.Text = description;
        }

        private void OwlHub_Selected(object sender, RoutedEventArgs e)
        {
            string description = "One of the most popular script hubs. 30+ games.";
            DescriptionBox.Text = description;
        }

        private void InfiniteJump_Selected(object sender, RoutedEventArgs e)
        {
            string description = "Spam the spacebar to jump as high as you want.";
            DescriptionBox.Text = description;
        }

        private void InfiniteYield_Selected_1(object sender, RoutedEventArgs e)
        {
            string description = "A command line script hub with over 6 years of development";
            DescriptionBox.Text = description;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();        
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CTopMost_Checked(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void CTopMost_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string ctopmost = File.ReadAllText("./bin/ontopsettings.txt");
            bool sconvert = bool.Parse(ctopmost);

            if (sconvert == true)
            {
                CTopMost.IsChecked = true;
            }
            else
            {
                CTopMost.IsChecked = false;
            }
        }
    }
}
