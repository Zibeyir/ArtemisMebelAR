using System;
using System.Collections;
using System.Collections.Generic;
using UniGLTF;
using UnityEngine;
using UnityEngine.Networking;

public class Mebel : MonoBehaviour
{

    public Texture[] MebelTextures;

    public Transform[] MebelParts;

    public GameObject MebelObject;

    void Start()
    {
        //MebelParts = MebelObject.GetComponentsInChildren<Transform>();
     //   StartCoroutine(downloadGLTF());
    }

    IEnumerator downloadGLTF()
    {
        string url = "https://firebasestorage.googleapis.com/v0/b/unity-test-4a52d.appspot.com/o/metbex_mebeli.gltf?alt=media&token=59d0e7b0-0c4d-43c3-8be3-51aafae704a5";
        var filePath = $"{Application.persistentDataPath}/Files/" + name + ".gltf";
        //   var progress = Progress.Create<float>(x => Progres(x, img));
        UnityWebRequest req = UnityWebRequest.Get(url);
        req.downloadHandler = new DownloadHandlerFile(filePath);
        yield return req.SendWebRequest();
        if (req.error != null)
        {
            Debug.Log(req.error);
            yield return null;
        }
        LoadModel(filePath);
    }
    public static void LoadModel(string path)
    {
        print(path);
        var context = gltfImporter.Load(path);
        context.ShowMeshes();
        GameObject root = context.Root;
        root.transform.localScale = new Vector3(1f, 1f, 1f);
        Vector3 origin = new Vector3(0f, 0f, 0f);
        Vector3 pos = origin;// + UnityEngine.Random.onUnitSphere * radius;
        root.transform.position = new Vector3(pos.x, 0, pos.z);
        // root.transform.LookAt(origin);
        // root.transform.SetParent(model.transform);
    }
}
