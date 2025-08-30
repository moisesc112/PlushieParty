using HarmonyLib;
using PlushieParty.Shared;

namespace PlushieParty.Patches
{
    [HarmonyPatch]
    internal static class CharacterItemsPatch
    {
        [HarmonyPatch(typeof(CharacterItems), "FixedUpdate")]
        [HarmonyPostfix]
        private static void FixedUpdatePostFix(CharacterItems __instance)
        {
            Character character = __instance.GetComponentInParent<Character>();
            Item currentItem = character.data.currentItem;

            if (currentItem == null)
            {

                return;
            }

            if (!ModState.hitPlayers.Contains(character) && (currentItem.itemTags & Item.ItemTags.BingBong) != 0)
            {
                character.refs.afflictions.SubtractStatus(ModUtils.GetBingBongAffliction(), 0.025f);
                __instance.StartCoroutine(ModUtils.IPlushieCooldown(character));
            }
        }        
    }
}
