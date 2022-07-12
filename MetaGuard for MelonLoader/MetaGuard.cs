using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using UnhollowerRuntimeLib;
using System.IO;
using System.Reflection;

namespace MetaGuard_for_MelonLoader {
    public class MetaGuard : MelonMod {
        AssetBundle MetaGuardAssetBundle;
        GameObject MetaGuardPrefab;
        GameObject MetaGuardObject;
        GameObject VRUIObject;

        public override void OnApplicationStart() {
            LoggerInstance.Msg("MetaGuard: Loading Prefab...");

            /*
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MetaGuard_for_MelonLoader.metaguard"))
            using (var tempStream = new MemoryStream((int)stream.Length)) {
                stream.CopyTo(tempStream);
                MetaGuardAssetBundle = AssetBundle.LoadFromMemory_Internal(tempStream.ToArray(), 0);
                MetaGuardAssetBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            }
            MetaGuardPrefab = MetaGuardAssetBundle.LoadAsset_Internal("Assets/MetaGuard.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
            */

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MetaGuard_for_MelonLoader.metaguard"))
            using (var tempStream = new MemoryStream((int)stream.Length)) {
                stream.CopyTo(tempStream);

                MetaGuardAssetBundle = AssetBundle.LoadFromMemory_Internal(tempStream.ToArray(), 0);
                MetaGuardAssetBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            }

            MetaGuardPrefab = MetaGuardAssetBundle.LoadAsset_Internal("Assets/MetaGuard.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
            MetaGuardPrefab.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            LoggerInstance.Msg("MetaGuard: Prefab Loaded!");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
            LoggerInstance.Msg("MetaGuard: Inserting Prefab...");
            LoggerInstance.Msg(MetaGuardPrefab);
            LoggerInstance.Msg(MetaGuardPrefab.name);
            MetaGuardObject = UnityEngine.Object.Instantiate(MetaGuardPrefab);
            VRUIObject = MetaGuardObject.transform.GetChild(0).gameObject;
            LoggerInstance.Msg("MetaGuard: Prefab Inserted!");
            LoggerInstance.Msg(MetaGuardObject);
            LoggerInstance.Msg(MetaGuardObject.name);
        }

        public override void OnUpdate() {
            if (Input.GetKeyDown(KeyCode.T)) {
                LoggerInstance.Msg("You just pressed T");

                /*
                GameObject VRUIMenuObject = VRUIObject.transform.GetChild(2).gameObject;
                Camera MainCamera = Camera.main;
                LoggerInstance.Msg(MainCamera.transform.position.ToString());
                VRUIMenuObject.transform.position = MainCamera.transform.position + MainCamera.transform.forward * 2.5f;
                VRUIMenuObject.transform.forward = MainCamera.transform.forward;
                VRUIMenuObject.transform.eulerAngles = new Vector3(0, VRUIMenuObject.transform.eulerAngles.y, VRUIMenuObject.transform.eulerAngles.z);
                VRUIMenuObject.SetActive(true);
                */

                GameObject CameraRig = Camera.main.transform.parent.parent.gameObject;
                GameObject Left = CameraRig.transform.GetChild(0).gameObject;
                GameObject Right = CameraRig.transform.GetChild(1).gameObject;
                GameObject Neck = CameraRig.transform.GetChild(2).gameObject;


            }
        }
    }
}
