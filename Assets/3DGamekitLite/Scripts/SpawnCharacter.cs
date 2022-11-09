using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] AssetReference  _character;
    [SerializeField] AssetReference  _enviromet;
    [SerializeField] Transform _characterSpawnPoint;
    private AsyncOperationHandle<GameObject> myEnviroment;
    private AsyncOperationHandle<GameObject> myCharacter;
    private GameObject tempObject;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log($"{Addressables.BuildPath}");
            Debug.Log($"{Addressables.RuntimePath}");
            COR_LoadAssets();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            relaseData();
        }
    }

    void COR_LoadAssets()
    {   
       _enviromet.InstantiateAsync().Completed+=SpawnCharacterNow;
    }

    private void SpawnCharacterNow(AsyncOperationHandle<GameObject> obj)
    {
        myCharacter= _character.InstantiateAsync(_characterSpawnPoint);   
    }

    void relaseData()
    {
        _character.ReleaseInstance(myCharacter.Result);
        _enviromet.ReleaseInstance(myEnviroment.Result);
    }
}
