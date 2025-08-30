using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PlushieParty.Shared
{
    internal static class ModState
    {
        public static readonly List<Character> hitPlayers = new();
        public static CharacterAfflictions.STATUSTYPE bingBongStatus = CharacterAfflictions.STATUSTYPE.Hunger;
    }
}
