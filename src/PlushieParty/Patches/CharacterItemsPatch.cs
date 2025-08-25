using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PlushieParty.Patches
{
    [HarmonyPatch]
    internal class CharacterItemsPatch
    {

        [HarmonyPatch(typeof(CharacterItems), nameof(CharacterItems.Equip))]
        [HarmonyPostfix]
        private static void EquipPostFix(CharacterItems __instance, Item item, ref Item __result)
        {
            Character character = __instance.GetComponentInParent<Character>();
            Item now = character.data.currentItem;

            Plugin.Log.LogInfo("Current Item: " +  now);

            if (item == null)
            {
                return; 
            }

            if ((now.itemTags & Item.ItemTags.BingBong) != 0)
            {
                Plugin.Log.LogInfo("BingBong is Held");

                GUIManager.instance.AddStatusFX(CharacterAfflictions.STATUSTYPE.Poison, 14f);
                character.refs.afflictions.AddStatus(CharacterAfflictions.STATUSTYPE.Poison, 0.5f);
            }    

        }


    



    }
}
