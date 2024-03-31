using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;

namespace Subscribe
{
	/// <summary>
	/// This is your mod's main class.
	/// </summary>

	/* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		public GameObject SubscriberBoard;


        void Start()
		{
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */
            var bundle = LoadAssetBundle("Subscribermod.subscribe");
            SubscriberBoard = bundle.LoadAsset<GameObject>("Subscribe Mod");
            var Subscriber = bundle.LoadAsset<GameObject>("Subscribe Mod");
            Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnEnable()
		{
			/* Set up your mod here */
			/* Code here runs at the start and whenever your mod is enabled*/

			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			/* Undo mod setup here */
			/* This provides support for toggling mods with ComputerInterface, please implement it :) */
			/* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
            SubscriberBoard = Instantiate(SubscriberBoard);
            SubscriberBoard.transform.position = new Vector3(-62.7106f, 11.9318f, -83.6155f);
            //SubscriberBoard.SetActive(false);
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }

               
	}
}
