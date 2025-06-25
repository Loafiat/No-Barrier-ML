using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using UnityEngine;
using Caputilla;

namespace CapuchinTemplate
{
    [BepInPlugin(ModInfo.GUID, ModInfo.Name, ModInfo.Version)]
    public class Init : BasePlugin
    {
        // I wouldn't recommend modifying this Init class as it can be hard to understand for new modders.
        // If you're experienced then probably ignore these comments as they're mostly here to guide new modders.
        public static Init instance;
        public Harmony harmonyInstance;

        public override void Load()
        {
            AddComponent<Plugin>();
        }

        public override bool Unload()
        {
            return true;
        }
    }

    public class Plugin : MonoBehaviour
    {

        void Start()
        {
            Debug.Log($"{ModInfo.Name} has loaded!");

            // Subscription to Caputilla events
            CaputillaManager.Instance.OnModdedJoin += OnModdedJoin;
            CaputillaManager.Instance.OnModdedLeave += OnModdedLeave;
        }

        void OnModdedJoin()
        {
            GameObject.Find("MapBarrier").SetActive(false);
        }

        void OnModdedLeave()
        {
            GameObject.Find("MapBarrier").SetActive(true);
        }
    }
}
