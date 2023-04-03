using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadRemoteAddressables : MonoBehaviour
{
    private GameObject _mMyGameObject;
    public string key;
    public void InstantiateGameobjectUsingAssetReference( )
    {
        Addressables.InstantiateAsync(key).Completed += OnLoadDone;
    }

    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        _mMyGameObject = obj.Result;
    }

    public void ReleaseGameobjectUsingAssetReference()
    {
        Addressables.Release(_mMyGameObject);
    }


}