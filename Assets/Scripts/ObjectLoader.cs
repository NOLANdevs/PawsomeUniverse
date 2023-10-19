using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoader : MonoBehaviour
{

    public static GameObject LoadPrefabAsChild(GameObject prefab, GameObject parent)
    {
        // Instantiate the prefab model
        GameObject loadedPrefab = Instantiate(prefab);
        // Set position to be the same as parent
        loadedPrefab.transform.parent = parent.transform;
        // Re-set position and scale
        loadedPrefab.transform.localPosition = prefab.transform.localPosition;
        loadedPrefab.transform.localScale = prefab.transform.localScale;
        return loadedPrefab;
    }
}
