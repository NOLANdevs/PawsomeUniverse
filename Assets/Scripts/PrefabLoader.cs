using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLoader : MonoBehaviour
{

    [System.Serializable]
    public struct AnimalModels
    {
        public Animal.Species species;
        public GameObject prefab;
    }

    public AnimalModels[] animalModels;

    public GameObject LoadAnimalAsChild(Animal.Species species, GameObject parent)
    {
        return LoadPrefabAsChild(findAnimalPrefab(species), parent);
    }

    public GameObject LoadPrefabAsChild(GameObject prefab, GameObject parent)
    {
        // Instantiate the prefab model
        GameObject loadedPrefab = Instantiate(prefab);
        // Set position to be the same as parent
        loadedPrefab.transform.SetParent(parent.transform);
        // Re-set position and scale
        loadedPrefab.transform.localPosition = prefab.transform.localPosition;
        loadedPrefab.transform.localScale = prefab.transform.localScale;
        return loadedPrefab;
    }

    private GameObject findAnimalPrefab(Animal.Species species)
    {
        foreach (AnimalModels data in this.animalModels)
        {
            if (data.species == species)
            {
                return data.prefab;
            }
        }
        return null;
    }
}
