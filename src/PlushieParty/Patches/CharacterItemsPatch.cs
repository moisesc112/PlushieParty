using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

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
            }    

        }

        public static bool inCoroutine = false;


        [HarmonyPatch(typeof(CharacterItems), "FixedUpdate")]
        [HarmonyPostfix]
        private static void FixedUpdatePostFix(CharacterItems __instance)
        {
            Character character = __instance.GetComponentInParent<Character>();
            Item now = character.data.currentItem;

            if (now == null)
            {
                return;
            }

            if (!inCoroutine && (now.itemTags & Item.ItemTags.BingBong) != 0)
            {
                __instance.StartCoroutine(IPlushieCooldown(character));
            }

        }

        private static IEnumerator IPlushieCooldown(Character character)
        {
            inCoroutine = true;
            Plugin.Log.LogInfo("Poison Coroutine Started");
            yield return new WaitForSeconds(1f);
            Plugin.Log.LogInfo("Poison Coroutine Finished");
            character.refs.afflictions.SubtractStatus(CharacterAfflictions.STATUSTYPE.Poison, 0.1f);
            inCoroutine = false;
        }





        [HarmonyPatch(typeof(GUIManager), "LateUpdate")]
        [HarmonyPostfix]
        private static void LateUpdatePostFix(GUIManager __instance)
        {
            if (InputSystem.actions.FindAction($"Hotbar{5}").WasPressedThisFrame())
            {
                Plugin.Log.LogInfo("Hotbar 5 is being Pressed in GUIManager");

                __instance.AddStatusFX(CharacterAfflictions.STATUSTYPE.Poison, 14f);
            }


        }


        [HarmonyPatch(typeof(Character), "Update")]
        [HarmonyPostfix]
        private static void UpdatePostFix(Character __instance)
        {
           
            if (__instance == null)
            {
                Plugin.Log.LogInfo("Character is null in Character");
                return;
            }

            if (InputSystem.actions.FindAction($"Hotbar{5}").WasPressedThisFrame())
            {
                Plugin.Log.LogInfo("Hotbar 5 is being Pressed in Character");

                __instance.refs.afflictions.AddStatus(CharacterAfflictions.STATUSTYPE.Poison, 0.5f);

            }


        }


    }
}
