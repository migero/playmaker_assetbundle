#if UNITY_2017_1_OR_NEWER

// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Asset Bundle")]
	[Tooltip("Unloads all assets in all asset bundles to free associated memory.")]

	public class  UnloadAllAssetBundles : FsmStateAction
	{	
		[Tooltip("If false, assets data inside bundle will be unloaded, but objects already loaded will be kept intact. If true, all objects loaded will be destroyed as well.")]
		public FsmBool unloadAllLoadedObjects;
		
		private AssetBundle _bundle;

		public override void Reset()
		{
			unloadAllLoadedObjects = false;
		}

		public override void OnEnter()
		{
			unloadBundle();
			Finish();
		}
		
		void unloadBundle()
		{
			AssetBundle.UnloadAllAssetBundles(unloadAllLoadedObjects.Value);
		}
	}
}
#endif