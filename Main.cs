using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using System.Collections.Generic;
using Kingmaker;
using Kingmaker.DialogSystem;

namespace BaseMod
{
    public static class Main
    {
        public static UnityModManager.ModEntry.ModLogger Logger;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Logger = modEntry.Logger;
            try
            {
                var harmony = new Harmony("BaseMod");
                harmony.PatchAll();
                Logger.Log("Harmony patches applied");
                foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
                {
                    Logger.Log("TYPE: " + t.FullName);
                }
                // ============ UNCOMMENT THE LINES BELOW IF YOU WISH TO SEE THE METHODS IN THE LOGS ===========
                // MethodLogger.LogMethods(modEntry.Logger, typeof(BlueprintCue));
                // MethodLogger.LogMethods(modEntry.Logger, typeof(BlueprintAnswer));
                // MethodLogger.LogMethods(modEntry.Logger, typeof(LocalizedString));
            }
            catch (ReflectionTypeLoadException ex)
            {
                Logger.Log("FAILED LOADING TYPES:");
                Logger.Error(ex.ToString());
                foreach (var e in ex.LoaderExceptions)
                    Logger.Log(e.ToString());
            }

            return true;
        }
    }

    // ========= THIS IS A LOGGER TO HELP YOU SEE ALL THE METHODS THAT YOU CAN USE TO MODIFY THE GAME ==========
    // ========= UNCOMMENT IF YOU WISH TO USE IT =========
    // public static class MethodLogger
    // {
    //     public static void LogMethods(UnityModManager.ModEntry.ModLogger logger, Type type)
    //     {
    //         logger.Log($"=== Métodos da classe {type.FullName} ===");
    //         foreach (var m in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
    //         {
    //             logger.Log($"{m.ReturnType.Name} {m.Name}({string.Join(", ", Array.ConvertAll(m.GetParameters(), p => p.ParameterType.Name + " " + p.Name))})");
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(BlueprintCue), "get_DisplayText")]
    public static class CharacterCuePatch
    {
        static void Postfix(BlueprintCue __instance, ref string __result)
        {
            // THIS IS AN EXAMPLE, YOU MUST FIND THE GUID YOU WANT TO MODIFY
            if (__instance.AssetGuid == "GUID")
            {
                __result = "[MODDED] " + __result;
                Debug.Log("Altering someone's speech: " + __result);
            }
        }
    }
}
