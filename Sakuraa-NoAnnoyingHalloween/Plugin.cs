using System;
using BepInEx;
using UnityEngine;
using Utilla;
using GorillaTagScripts;

namespace Sakuraa_NoAnnoyingHalloween
{
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		bool Enabled;
        private GameObject lightningManager = null;
		private GameObject ghostLurker = null;

        void Start()
		{
            lightningManager = GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/LightningManager");
			ghostLurker = GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab");
            Enabled = true;
			Debug.Log("Sakuraas Lightning Disabler started!");
        }

		void OnEnable()
		{
			Enabled = true;
			if (inRoom && lightningManager != null)
			{
				lightningManager.SetActive(false);
				ghostLurker.SetActive(false);
            }
		}

		void OnDisable()
		{
			Enabled = false;
            lightningManager.SetActive(true);
			ghostLurker.SetActive(true);
        }

		void Update()
		{
            if (lightningManager != null && inRoom && Enabled)
            {
                lightningManager.SetActive(false);
				ghostLurker.SetActive(false);
            }
			else
			{
				lightningManager.SetActive(true);
				ghostLurker.SetActive(true);
			}
        }

		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			inRoom = true;
		}

		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			inRoom = false;
		}
	}
}
