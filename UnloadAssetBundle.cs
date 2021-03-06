// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Asset Bundle")]
	[Tooltip("Unloads all assets in the bundle and frees all the memory associated.")]

	public class  UnloadAssetBundle : FsmStateAction
	{

		[RequiredField]
		[Tooltip("Name of the asset bundle to unload.")]
		[UIHint(UIHint.Variable)]
		public FsmObject AssetBundle;
		
		[Tooltip("If false, assets data inside bundle will be unloaded, but objects already loaded will be kept intact. If true, all objects loaded will be destroyed as well.")]
		public FsmBool unloadAllLoadedObjects;
		
		private AssetBundle _bundle;

		public override void Reset()
		{

			AssetBundle = null;
			unloadAllLoadedObjects = false;
			
		}

		public override void OnEnter()
		{
			unloadBundle();
			Finish();
		}
		
		
		void unloadBundle()
		{
			_bundle = (AssetBundle)AssetBundle.Value;
			_bundle.Unload(unloadAllLoadedObjects.Value);
		}
	}
}