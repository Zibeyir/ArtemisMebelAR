using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

public class GLTFObject : MonoBehaviour
{
    public GameObject GetGLTF;
    public MeshRenderer[] meshRenderers;
    public List<Texture> textures;
    public Texture texture;
    public string uploadURL;

    [System.Obsolete]
    void Start()
    {
        textures = new List<Texture>();
        // ImportImage();
        ImportExample();
        StartCoroutine(ImportImage());
    }

    [System.Obsolete]
    IEnumerator ImportImage()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(uploadURL);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("gno");
            texture = DownloadHandlerTexture.GetContent(www);
        }
    }
    public void ImportExample()
    {
       
       // texture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Downlands/DuckCM.png", typeof(Texture));
    }
    public void GetGLTFFunc(GameObject _GLTF)
    {
        meshRenderers = _GLTF.GetComponentsInChildren<MeshRenderer>();
        foreach (var item in meshRenderers)
        {
            textures.Add(item.material.mainTexture);
        }
        foreach (var item in meshRenderers)
        {
            item.material.mainTexture = texture;
        }
    }
    
}
