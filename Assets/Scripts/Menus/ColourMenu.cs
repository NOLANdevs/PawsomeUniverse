using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourMenu : MonoBehaviour
{
    public Animal animal;
    [SerializeField]
    List<Button> colours = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < colours.Count; i++)
        {
            int cacheIndex = i; // we have to cache i to have the right value
            colours[i].onClick.AddListener(() => ColourPicked(cacheIndex));
        }
    }

    public void Show()
    {
        if (!GameLogic.isPaused)
        {
            gameObject.SetActive(true);
            GameLogic.PauseGame();
        }
    }

    public void Hide()
    {
        GameLogic.UnpauseGame();
        gameObject.SetActive(false);
    }

    public void ColourPicked(int index)
    {
        animal.assignColour(index);
        Hide();
    }
}
