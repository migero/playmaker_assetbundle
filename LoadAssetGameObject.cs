// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Asset Bundle")]
    [Tooltip("Load Asset from Asset Bundle.")]
    public class LoadAssetGameObject : FsmStateAction
    {
        [Tooltip("Name of the gameobject to load from the asset bundle, as a string.")]
        public FsmString AssetName;

        [Tooltip("The asset bundle containing the gameobject.")]
        [UIHint(UIHint.Variable)]
        public FsmObject AssetBundle;

        [ActionSection("Events")]
        [Tooltip("Event fired on load success of asset gameobject.")]
        public FsmEvent loadSuccess;

        [Tooltip("Event fired on load failure of asset gameobject.")]
        public FsmEvent loadFailed;

        [ActionSection("Output")]
        [Tooltip("Game object found within the asset bundle.")]
        [UIHint(UIHint.Variable)]
        public FsmGameObject gameObject;

        [ActionSection("Options")]
        [Tooltip("Set to true for optional debug messages in the console. Turn off for builds.")]
        public FsmBool enableDebug;

        private AssetBundle _bundle;

        public override void Reset()
        {
            enableDebug = false;
            AssetBundle = null;
            loadFailed = null;
            loadSuccess = null;
            gameObject = null;
            AssetName = null;
        }

        public override void OnEnter()
        {
            loadBundle();
        }


        void loadBundle()
        {
            _bundle = (AssetBundle) AssetBundle.Value;
            gameObject.Value = _bundle.LoadAsset<GameObject>(AssetName.Value);

            // gameObject load fail
            if (gameObject.Value == null)
            {
                if (enableDebug.Value)
                {
                    Debug.Log("Failed to find gameObject in asset bundle.");
                }

                Fsm.Event(loadFailed);
            }

            // gameObject fetch success
            else
            {
                if (enableDebug.Value)
                {
                    Debug.Log("Asset bundle game object load success.");
                }

                Fsm.Event(loadSuccess);
            }
        }
    }
}