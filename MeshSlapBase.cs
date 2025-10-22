using MSCLoader;
using UnityEngine;

namespace MeshSlapBase
{
    public class MeshSlapBase : Mod
    {
        public override string ID => "MeshSlapBase"; // change it
        public override string Name => "MSB"; // change it
        public override string Author => "steelberg"; // change it
        public override string Version => "1.0"; //Version
        public override string Description => ""; //Short description of your mod

        private GameObject slap;
        private GameObject msb;
        private GameObject ms_obj;

        public override void ModSetup()
        {
            SetupFunction(Setup.OnLoad, Mod_OnLoad);
        }

        private void Mod_OnLoad()
        {
            AssetBundle ab = LoadAssets.LoadBundle(this, "msb.unity3d"); // change name if you need
            GameObject go = ab.LoadAsset<GameObject>("msb.prefab"); // change name if you need

            this.msb = GameObject.Instantiate(go);

            ab.Unload(false);
            this.slap = GameObject.Find("urnamehere"); // add .transform.Find(".../..."); if you need it
            this.msb.transform.parent = slap.transform;
            this.msb.transform.localPosition = new Vector3(0, 0, 0);
            this.msb.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.msb.transform.localScale = new Vector3(1, 1, 1);

            // change variables values if your object doesn't fits properly.

            MeshRenderer.Destroy(slap.GetComponent<MeshRenderer>()); // destroys the old mesh of slapping obj

            this.ms_obj = slap.transform.Find("msb(Clone)").gameObject; // change name. it'll be like {your_prefab_name}(Clone)
            this.ms_obj.AddComponent<MeshRenderer>(); // adding meshrenderer back
        }
    }
}
