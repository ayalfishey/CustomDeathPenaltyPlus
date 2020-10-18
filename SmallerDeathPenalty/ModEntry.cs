﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;
using System.Collections.Generic;
using System.Linq;

namespace SmallerDeathPenalty
{
    public class ModEntry
        : Mod, IAssetEditor
    {
        private ModConfig Config;
        //Allow asset to be editted if name matches
        public bool CanEdit<T>(IAssetInfo asset)
        {
            if (asset.AssetNameEquals("Strings\\StringsFromCSFiles"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Edit asset
        public void Edit<T>(IAssetData asset)
        {
            var editor = asset.AsDictionary<string, string>().Data;

            //Does the PlayerStateSaver not exist or is the player's money greater than 10,000g?
            if (PlayerStateSaver.state == null || Game1.player.Money > 10000)
            {
                //Edit events to reflect capped amount lost, default
                editor["Event.cs.1068"] = "Dr. Harvey charged me 500g for the hospital visit.";
                editor["Event.cs.1058"] = "I seem to have lost 500g";
            }
            else
            {
                //Edit events to reflect discounted amount lost
                editor["Event.cs.1068"] = $"Dr. Harvey charged me {PlayerStateSaver.state.money - (int)Math.Round(PlayerStateSaver.state.money * 0.95)}g for the hospital visit. ";
                editor["Event.cs.1058"] = $"I seem to have lost {PlayerStateSaver.state.money - (int)Math.Round(PlayerStateSaver.state.money * 0.95)}g.";
            }
            if (Config.RestoreItems == true)
            {
                //Remove unnecessary strings
                editor["Event.cs.1060"] = "";
                editor["Event.cs.1061"] = "";
                editor["Event.cs.1062"] = "";
                editor["Event.cs.1063"] = "";
                editor["Event.cs.1071"] = "";
            }
               
        }
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += this.OnUpdateTicked;
            helper.Events.GameLoop.GameLaunched += this.GameLaunched;
            this.Config = this.Helper.ReadConfig<ModConfig>();
        }

        private void GameLaunched(object sender, GameLaunchedEventArgs e)
        {
            Helper.Content.AssetEditors.Add(new UIFixes(Helper));
        }
        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            //Check if player died each half second
            if (e.IsMultipleOf(30))
            {
                //Save funds upon death
                if (PlayerStateSaver.state == null && Game1.killScreen)
                {
                    PlayerStateSaver.Save();

                    //Reload asset upon death to reflect amount lost
                    Helper.Content.InvalidateCache("Strings\\StringsFromCSFiles");
                }
            }
            //Restore state after event ends
            else if (PlayerStateSaver.state != null && Game1.CurrentEvent == null && Game1.player.CanMove)
            {
                PlayerStateSaver.Load();
                if (Config.RestoreItems == true)
                {
                    PlayerStateSaver.RestoreItems();
                }
                //Reset PlayerStateSaver
                PlayerStateSaver.state = null;
                this.Monitor.Log("Player state restored...",LogLevel.Debug);
            }
        }
    }
}
