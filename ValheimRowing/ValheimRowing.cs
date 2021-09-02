// JotunnModStub
// a Valheim mod skeleton using Jötunn
// 
// File:    JotunnModStub.cs
// Project: JotunnModStub

using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace ScreamingMarmotMods
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInProcess("valheim.exe")]
    internal class ValheimRowing : BaseUnityPlugin
    {
        public const string PluginGUID = "com.screamingmarmot.valheimrowing";
        public const string PluginName = "Valheim Rowing";
        public const string PluginVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony("com.screamingmarmotmods.valheimrowing");

        private void Awake()
        {
            harmony.PatchAll();
        }


        [HarmonyPatch(typeof(Ship), nameof(Ship.ApplyMovementControlls))]
        class ShipRowing
        {
            static float s_defaultBackwardForce = 50f;
            static void Prefix(ref float ___m_backwardForce, ref List<Player> ___m_players)
            {
                Debug.Log($"Rudder speed: {___m_backwardForce}");
                Debug.Log($"Ship players size: {___m_players.Count}");
                ___m_backwardForce = s_defaultBackwardForce * 1f + ((float)___m_players.Count / 10f);
                Debug.Log($"Ruder speed post: {___m_backwardForce}");
            }
        };
    }
}