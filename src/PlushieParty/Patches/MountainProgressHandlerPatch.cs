using HarmonyLib;
using PlushieParty.Shared;
using UnityEngine;

namespace PlushieParty.Patches
{
    internal static class MountainProgressHandlerPatch
    {
        [HarmonyPatch(typeof(MountainProgressHandler), "TriggerReached")]
        [HarmonyPostfix]
        private static void TriggerReachedPostFix(MountainProgressHandler.ProgressPoint progressPoint)
        {

            switch (progressPoint.title)
            {
                case "SHORE":
                    ModUtils.SetBingBongAffliction(CharacterAfflictions.STATUSTYPE.Hunger);                    
                    break;
                case "TROPICS":
                    ModUtils.SetBingBongAffliction(CharacterAfflictions.STATUSTYPE.Poison);
                    break;
                case "ALPINE":
                    ModUtils.SetBingBongAffliction(CharacterAfflictions.STATUSTYPE.Hot);
                    break;
                case "MESA":
                    ModUtils.SetBingBongAffliction(CharacterAfflictions.STATUSTYPE.Cold);
                    break;
                case "CALDERA":
                    ModUtils.SetBingBongAffliction(CharacterAfflictions.STATUSTYPE.Cold);
                    break;
                case "THE KILN":
                    ModUtils.SetBingBongAffliction(CharacterAfflictions.STATUSTYPE.Injury);
                    break;
                case "PEAK":
                    ModUtils.SetBingBongAffliction(CharacterAfflictions.STATUSTYPE.Hunger);
                    break;

            }

        }
    }
}
