using System;
using System.Collections;
using System.Collections.Generic;
using UniGLTF;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;
using TriLibCore.Samples;

public class Mebel : MonoBehaviour
{

    public Texture[] MebelTextures;

    public Transform[] MebelParts;

    public GameObject MebelObject;
    static bool DownlandMebelBool = false;
    public static Transform _mebelPos;
    [SerializeField] Transform CameraPos;
    [SerializeField] Text MebelCameraPosText;
    public string addressableName;
    [SerializeField] LoadModelFromURLSample loadModelFromURLSample;
    private  void Start()
    {
        //AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(addressableName);
        //await handle.Task;
        //if (handle.Status == AsyncOperationStatus.Succeeded)
        //{
        //    GameObject go = handle.Result;
        //    // Do something with the loaded GameObject...
        //}
        //else
        //{
        //    Debug.LogError("Failed to load asset: " + handle.OperationException);
        //}
    }
    public void DownloadModel()
    {
        //StartCoroutine(downloadGLTF());
        loadModelFromURLSample.StartDownland();
    }
    IEnumerator downloadGLTF()
    {
        //   string url = "https://firebasestorage.googleapis.com/v0/b/unity-test-4a52d.appspot.com/o/metbex_mebeli.gltf?alt=media&token=59d0e7b0-0c4d-43c3-8be3-51aafae704a5";
        string url = "https://firebasestorage.googleapis.com/v0/b/unity-test-4a52d.appspot.com/o/robot_final.gltf?alt=media&token=33ed552c-24ae-4524-8c8b-ff8ff94e75c6";
        //string url = "https://firebasestorage.googleapis.com/v0/b/unity-test-4a52d.appspot.com/o/cottage_fbx.fbx?alt=media&token=1cc482a8-1c28-4e35-8f27-1fa0ffc353b1";
        var filePath = $"{Application.persistentDataPath}/Files/" + name + ".gltf";
        //   var progress = Progress.Create<float>(x => Progres(x, img));
        UnityWebRequest req = UnityWebRequest.Get(url); MebelCameraPosText.text = "Load1";

        req.downloadHandler = new DownloadHandlerFile(filePath); MebelCameraPosText.text = "Load2";
        yield return req.SendWebRequest();
        if (req.error != null)
        {
            Debug.Log(req.error);
            yield return null;
        }
        //UnityWebRequest uwr;
        //AssetBundle bundle;
        //MebelCameraPosText.text = filePath+" LoadStart";
        //uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
        //yield return uwr.SendWebRequest();

        //if (uwr.result != UnityWebRequest.Result.Success)
        //{
        //    Debug.Log("Error while downloading asset bundle: " + uwr.error);
        //    yield break;
        //}

        //bundle = DownloadHandlerAssetBundle.GetContent(uwr);
        //GameObject model = bundle.LoadAsset<GameObject>(bundle.GetAllAssetNames()[0]);
        //Instantiate(model);
        LoadModel(filePath);
        MebelCameraPosText.text = "LoadFinish";

    }
   
    private void Update()
    {
        if (DownlandMebelBool)
        {
            //MebelCameraPosText.text = "MebelPos " + _mebelPos.position + "Camera " + CameraPos.position; 
        }
    }
    private  void LoadModel(string path)
    {
        MebelCameraPosText.text = "LoadStart1";

      //  var context = gltfImporter.Load(path); MebelCameraPosText.text = "LoadStart2";
        var context = new ImporterContext(); MebelCameraPosText.text = "LoadStart8";

        context.Load(path); MebelCameraPosText.text = "LoadStart9";

        context.ShowMeshes(); MebelCameraPosText.text = "LoadStart10";

        context.EnableUpdateWhenOffscreen(); MebelCameraPosText.text = "LoadStart11";

        //  context.ShowMeshes();
    //    MebelCameraPosText.text = "LoadStart3";

        GameObject root = context.Root; MebelCameraPosText.text = "LoadStart4";

        _mebelPos = root.transform; MebelCameraPosText.text = "LoadStart5";

        root.transform.localScale = new Vector3(.1f, .1f, .1f);
        Vector3 origin = new Vector3(0f, 0f, 0f); MebelCameraPosText.text = "LoadStart6";

        Vector3 pos = origin;// + UnityEngine.Random.onUnitSphere * radius;
        root.transform.position = new Vector3(pos.x, 0, pos.z); MebelCameraPosText.text = "LoadStart7";

        // root.transform.LookAt(origin);
        // root.transform.SetParent(model.transform);
        DownlandMebelBool = true;
    }
}
