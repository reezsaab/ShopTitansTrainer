﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Riposte;
using ShopTitansCheat.Components;
using ShopTitansCheat.Data;
using UnityEngine;

namespace ShopTitansCheat.Utils
{
    class Config
    {
        private static readonly Lazy<Config> Lazy = new Lazy<Config>(() => new Config());
        public static Config Instance => Lazy.Value;

        Config()
        {
            
        }

        internal void SaveCraftingList(string fileName)
        {
            if (Settings.Crafting.CraftingEquipmentsList.Count == 0)
            {
                Log.Instance.PrintMessageInGame("No Items Too Save !", OverlayMessageControl.MessageType.Error);
            }
            else
            {
                File.WriteAllText($"{fileName}.json", JsonConvert.SerializeObject(Settings.Crafting.CraftingEquipmentsList, Formatting.Indented));
                Log.Instance.PrintMessageInGame("Saved Sucesfully!", OverlayMessageControl.MessageType.Neutral);
            }
        }

        internal void LoadCraftingList(string fileName)
        {
            string text;

            using (StreamReader streamReader = new StreamReader($"{fileName}.json"))
            {
                text = streamReader.ReadToEnd();
            }
            var deserializeObject = JsonConvert.DeserializeObject<List<Equipment>>(text);
            Settings.Crafting.CraftingEquipmentsList = deserializeObject;
        }
    }
}
