using CapuchinTemplate;
using Caputilla;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(Plugin), CapuchinTemplate.ModInfo.Name, CapuchinTemplate.ModInfo.Version, CapuchinTemplate.ModInfo.Author)]

namespace CapuchinTemplate
{
    public class Plugin : MelonMod
    {
        public static Plugin instance;

        public override void OnInitializeMelon()
        {
            instance = this;
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