using System.Collections;
using UnityEngine;

namespace PlushieParty.Shared
{
    internal static class ModUtils
    {
        public static CharacterAfflictions.STATUSTYPE GetBingBongAffliction()
        {
            return ModState.bingBongStatus;
        }

        public static void SetBingBongAffliction(CharacterAfflictions.STATUSTYPE status)
        {
            ModState.bingBongStatus = status;
        }

        public static IEnumerator IPlushieCooldown(Character character)
        {
            ModState.hitPlayers.Add(character);
            yield return new WaitForSeconds(4f);
            ModState.hitPlayers.Remove(character);
        }

    }
}
