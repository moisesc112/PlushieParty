using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PlushieParty;

[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;
    private readonly Harmony _harmony = new(Id);

    private void Awake()
    {
        Log = Logger;
        Log.LogInfo($"Plugin {Name} is loaded!");
        _harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}
